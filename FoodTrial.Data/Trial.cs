using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Data
{
    public enum Symptoms { hives, eczema, reflux, respiratory, diarhea, constipation, itchy, swelling, pulseDecrease, pulseIncrease, bloodPressureDrop, jointPain, behavioral, none }

    public enum TypeOfReaction { IgE, IgG, FPIES, MCAS, EOE, histamine, noReaction }
    public class Trial
    {
        public Trial()
        {
            this.Symptoms = new List<Symptoms>();
        }

        [Key]
        public int TrialId { get; set; }
        [ForeignKey(nameof(Food))]
        [Required]
        public int FoodId { get; set; }
        public virtual Food Food { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        [Required]
        public bool MedicalIntervention { get; set; }
        [Required]
        public List<Symptoms> Symptoms { get; set; }
        public TypeOfReaction ReactionType { get; set; }
        
        public bool IsSafe { get; set; }

    }
}
