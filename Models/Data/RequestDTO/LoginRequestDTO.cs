using System;
using System.Collections.Generic;

namespace PracticeAPI.Models.Data.RequestDTO;

public class LoginRequestDTO
{
    public string Email { get; set; }

    public string Password { get; set; }
}
