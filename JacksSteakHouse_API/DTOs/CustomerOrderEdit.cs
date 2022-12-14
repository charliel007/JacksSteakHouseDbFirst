using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JacksSteakHouse_API.DTOs
{
    public class CustomerOrderEdit
    {
        [Required]
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [DisplayName("Customer Id")]
        public int CustomerId { get; set; }

        [Required]
        [DisplayName("Menu Item Id")]
        public int MenuItemId { get; set; }
    }
}