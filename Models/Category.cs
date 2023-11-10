﻿using System;
using System.Collections.Generic;

namespace PracticeAPI.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public virtual ICollection<Product>? Products { get; set; }
}
