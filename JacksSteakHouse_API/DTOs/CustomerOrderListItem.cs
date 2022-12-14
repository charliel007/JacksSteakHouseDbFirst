using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JacksSteakHouse_API.DTOs
{
    public class CustomerOrderListItem
    {
        public DateTime OrderDate { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public string? MealName { get; set; }
    }
}