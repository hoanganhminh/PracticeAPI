using AutoMapper;
using MediatR;
using PracticeAPI.Repositories.Contracts;

namespace PracticeAPI.Features.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetById(request.Id);
            _unitOfWork.CustomerRepository.Remove(customer);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}