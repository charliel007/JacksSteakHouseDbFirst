using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JacksSteakHouse_API.DTOs
{
    public class LocationListItem
    {
        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public List<EmployeeListItem>? Employees { get; set; }

    }
}