using AutoMapper;
using MediatR;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : BaseService, IRequestHandler<CreateCustomerCommand, Unit>
    {
        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Models.Customer>(request.CustomerRequestDTO);
            _unitOfWork.CustomerRepository.Add(customer);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}