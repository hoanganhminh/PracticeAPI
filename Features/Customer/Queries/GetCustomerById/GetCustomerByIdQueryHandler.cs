using AutoMapper;
using MediatR;
using PracticeAPI.Models.Data.ResponseDTO;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : BaseService, IRequestHandler<GetCustomerByIdQuery, CustomerResponseDTO>
    {
        public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<CustomerResponseDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetById(request.CustomerId);
            return _mapper.Map<CustomerResponseDTO>(customer);
        }
    }
}
