using AutoMapper;
using MediatR;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : BaseService, IRequestHandler<UpdateCustomerCommand,Unit>
    {
        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            request.Id = request.CustomerRequestDTO.CustomerId;
            var customer = _mapper.Map<Models.Customer>(request.CustomerRequestDTO);
            _unitOfWork.CustomerRepository.Update(customer);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
