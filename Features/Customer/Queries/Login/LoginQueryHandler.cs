using AutoMapper;
using MediatR;
using PracticeAPI.Models.Data.ResponseDTO;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;
using PracticeAPI.Services.Contracts;

namespace PracticeAPI.Features.Customer.Queries.Login
{
    public class LoginQueryHandler : BaseService, IRequestHandler<LoginQuery, LoginResponseDTO>
    {
        private readonly ITokenService _tokenService;

        public LoginQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService) : base(unitOfWork, mapper)
        {
            this._tokenService = tokenService;
        }

        public async Task<LoginResponseDTO> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            if (request.Email is null || request.Password is null)
            {
                throw new ArgumentNullException("Email or Password can not be null");
            }
            var customer = await _unitOfWork.CustomerRepository.GetOneByProperties(request.Email, "Email", request.Password, "Password");

            var customerResponseDTO = _mapper.Map<CustomerResponseDTO>(customer);
            var token = _tokenService.CreateToken(customerResponseDTO);

            var loginResponseDTO = new LoginResponseDTO
            {
                CustomerResponseDTO = customerResponseDTO,
                Token = token
            };

            return loginResponseDTO;
        }
    }
}
