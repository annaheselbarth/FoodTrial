using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Models
{
    public class MedicineEdit
    {
        public int MedicineId { get; set; }
        public int? TrialId { get; set; }
        public string Name { get; set; }
        public string Dose { get; set; }
        public int Frequency { get; set; }
        public string Comment { get; set; }
    }
}
