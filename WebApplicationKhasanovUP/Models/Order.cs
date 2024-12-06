using System;
using System.Collections.Generic;

namespace WebApplicationKhasanovUP.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int Buyer { get; set; }

    public int Saller { get; set; }

    public int AddId { get; set; }

    public DateOnly DateOfOrder { get; set; }

    public string Status { get; set; } = null!;

    public virtual Add Add { get; set; } = null!;

    public virtual User BuyerNavigation { get; set; } = null!;

    public virtual User SallerNavigation { get; set; } = null!;
}
