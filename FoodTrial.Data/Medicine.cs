using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Data
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [ForeignKey(nameof(Trial))]
        public int? TrialId { get; set; }
        public virtual  Trial Trial { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Dose { get; set; }
        [Required]
        public int Frequency { get; set; }
        public string Comment { get; set; }
    }
}
