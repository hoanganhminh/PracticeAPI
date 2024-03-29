﻿using MediatR;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Features.Customer.Queries.Login
{
    public class LoginQuery : IRequest<LoginResponseDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}