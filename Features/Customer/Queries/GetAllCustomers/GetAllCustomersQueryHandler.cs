using AutoMapper;
using MediatR;
using PracticeAPI.Models.Data.ResponseDTO;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : BaseService, IRequestHandler<GetAllCustomersQuery, List<CustomerResponseDTO>>
    {
        public GetAllCustomersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<List<CustomerResponseDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _unitOfWork.CustomerRepository.GetAll();
            return _mapper.Map<List<CustomerResponseDTO>>(customers);
        }
    }
}
