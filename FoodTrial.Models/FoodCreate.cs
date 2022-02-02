using FoodTrial.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Models
{
    public class FoodCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        public AllergenGroup AllergenGroup { get; set; }
        [Required]
        public FoodGroup FoodGroup { get; set; }
        public string Description { get; set; }
    }
}
