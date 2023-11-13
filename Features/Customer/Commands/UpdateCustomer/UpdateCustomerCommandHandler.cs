using AutoMapper;
using MediatR;
using PracticeAPI.Helpers.UnitOfWork;

namespace PracticeAPI.Features.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            request.Id = request.CustomerRequestDTO.CustomerId;
            var customer = _mapper.Map<Models.Customer>(request.CustomerRequestDTO);
            _unitOfWork.CustomerRepository.UpdateCustomer(customer);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
