﻿using System;
using System.Collections.Generic;

namespace ClassLibraryKhasanovUP;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Add> Adds { get; set; } = new List<Add>();
}
