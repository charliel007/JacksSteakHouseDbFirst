using System;
using System.Collections.Generic;

namespace JacksSteakHouse_API.Models.DB;

public partial class MenuItem
{
    public int Id { get; set; }

    public string MealName { get; set; } = null!;

    public string MealDescription { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<CustomerOrder> CustomerOrders { get; } = new List<CustomerOrder>();
}
