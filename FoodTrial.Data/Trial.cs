using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Data
{
    public class Trial
    {
        public int TrialId { get; set; }
        public virtual Food Food { get; set; }
        public string Comment { get; set; }
        public DateTime DateTime { get; set; }
        public int NumberOfDays { get; set; }
        public bool MedicalIntervention { get; set; }
        //public Symptoms Symptoms { get; set; }
        //public TypeOfReaction ReactionType { get; set; }
        public bool IsSafe { get; set; }

    }
}
