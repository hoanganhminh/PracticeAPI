using AutoMapper;
using MediatR;
using PracticeAPI.Features.Category.Commands.UpdateCategory;
using PracticeAPI.Helpers.UnitOfWork;
using PracticeAPI.Models.Data.ResponseDTO;
using PracticeAPI.Services.Contracts;

namespace PracticeAPI.Features.Customer.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public LoginQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._tokenService = tokenService;
        }

        public async Task<LoginResponseDTO> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            if (request.Email is null || request.Password is null)
            {
                throw new ArgumentNullException("Email or Password can not be null");
            }
            var customer = await _unitOfWork.CustomerRepository.Login(request.Email, request.Password);

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
