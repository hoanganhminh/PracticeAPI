using AutoMapper;
using MediatR;
using PracticeAPI.Features.Category.Commands.UpdateCategory;
using PracticeAPI.Helpers.UnitOfWork;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<List<CustomerResponseDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllCustomers();
            return _mapper.Map<List<CustomerResponseDTO>>(customers);
        }
    }
}
