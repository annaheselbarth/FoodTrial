using FoodTrial.Data;
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
        public int FoodId { get; set; }

       // [Display(Name ="Food Name Trialed")]
       // [Required]
       // public string Name { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public bool IsSafe { get; set; }
        public bool MedicalIntervention { get; set; }
        public List<Symptoms> Symptoms { get; set; }
        public TypeOfReaction ReactionType { get; set; }

    }
}
