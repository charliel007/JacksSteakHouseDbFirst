using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JacksSteakHouse_API.DTOs
{
    public class CustomerEdit
    {   
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = null!;
        
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = null!;

    }
}