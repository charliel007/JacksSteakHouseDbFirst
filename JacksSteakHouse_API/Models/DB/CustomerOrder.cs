using System;
using System.Collections.Generic;

namespace JacksSteakHouse_API.Models.DB;

public partial class CustomerOrder
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public int CustomerId { get; set; }

    public int MenuItemId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual MenuItem MenuItem { get; set; } = null!;
}
