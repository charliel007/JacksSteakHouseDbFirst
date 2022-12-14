using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JacksSteakHouse_API.DTOs
{
    public class MenuItemEdit
    {
        [Required]
        [DisplayName("Meal Name")]
        [MaxLength(150, ErrorMessage ="Meal Name cannot be that long, more than 150 characters.")]
        public string MealName { get; set; } = null!;

        [Required]
        [DisplayName("Meal Description")]
        public string MealDescription { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }
    }
}