using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JacksSteakHouse_API.DTOs
{
    public class LocationEdit
    {
        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(15)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [DisplayName("Grand Opening")]
        public DateTime GrandOpening { get; set; }
    }
}