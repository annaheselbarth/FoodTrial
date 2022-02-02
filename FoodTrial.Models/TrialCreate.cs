using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Models
{
    public class TrialCreate
    {
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        
    }
}
