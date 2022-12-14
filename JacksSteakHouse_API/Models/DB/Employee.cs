using System;
using System.Collections.Generic;

namespace JacksSteakHouse_API.Models.DB;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime? ApplicationSubmissionDate { get; set; }

    public DateTime HireDate { get; set; }

    public int? LocationId { get; set; }

    public virtual Location? Location { get; set; }
}
