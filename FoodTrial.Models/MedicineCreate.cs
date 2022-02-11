using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Models
{
    public class MedicineCreate
    {
        public int MedicineId { get; set; }
        public int? TrialId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Dose { get; set; }
        public int Frequency { get; set; }
        public string Comment { get; set; }
    }
}
