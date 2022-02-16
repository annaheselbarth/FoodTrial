using FoodTrial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Models
{
    public class TrialListItem
    {
        public int TrialId { get; set; }
        public int FoodId { get; set; }
        public string Comment { get; set; }
        public DateTime DateTime { get; set; }
        public int NumberOfDays { get; set; }
        public bool MedicalIntervention { get; set; }
        public List<Symptoms> Symptoms { get; set; }
        public TypeOfReaction ReactionType { get; set; }
        public bool IsSafe { get; set; }
    }
}
