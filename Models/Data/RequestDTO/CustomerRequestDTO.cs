using System;
using System.Collections.Generic;

namespace PracticeAPI.Models.Data.RequestDTO;

public class CustomerRequestDTO
{
    public int CustomerId { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}
