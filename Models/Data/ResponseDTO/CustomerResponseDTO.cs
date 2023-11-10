using System;
using System.Collections.Generic;

namespace PracticeAPI.Models.Data.ResponseDTO;

public class CustomerResponseDTO
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; }

    public string Email { get; set; }
}
