using System;
using System.Collections.Generic;

namespace PracticeAPI.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}
