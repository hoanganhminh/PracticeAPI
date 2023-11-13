using AutoMapper;
using MediatR;
using PracticeAPI.Features.Category.Commands.UpdateCategory;
using PracticeAPI.Helpers.UnitOfWork;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Features.Customer.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, CustomerResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoginQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<CustomerResponseDTO> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            if (request.Email is null || request.Password is null)
            {
                throw new ArgumentNullException("Email or Password can not be null");
            }
            var customer = await _unitOfWork.CustomerRepository.Login(request.Email, request.Password);
            return _mapper.Map<CustomerResponseDTO>(customer);
        }
    }
}
