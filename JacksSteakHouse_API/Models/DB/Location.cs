using System;
using System.Collections.Generic;

namespace JacksSteakHouse_API.Models.DB;

public partial class Location
{
    public int Id { get; set; }

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateTime GrandOpening { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
