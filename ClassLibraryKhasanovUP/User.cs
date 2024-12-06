using System;
using System.Collections.Generic;

namespace ClassLibraryKhasanovUP;

public partial class User
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Add> Adds { get; set; } = new List<Add>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Order> OrderBuyerNavigations { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderSallerNavigations { get; set; } = new List<Order>();
}
