using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Data
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public virtual  Trial Trial { get; set; }
        public string Name { get; set; }
        public string Dose { get; set; }
        public int Frequency { get; set; }
        public string Comment { get; set; }
    }
}
