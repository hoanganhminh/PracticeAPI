using AutoMapper;
using MediatR;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : BaseService, IRequestHandler<DeleteCustomerCommand, Unit>
    {
        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetById(request.Id);
            _unitOfWork.CustomerRepository.Remove(customer);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}