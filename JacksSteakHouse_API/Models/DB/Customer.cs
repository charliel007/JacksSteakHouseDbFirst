using System;
using System.Collections.Generic;

namespace JacksSteakHouse_API.Models.DB;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<CustomerOrder> CustomerOrders { get; } = new List<CustomerOrder>();
}
