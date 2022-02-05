using FoodTrial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Models
{
    public class FoodDetail
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public AllergenGroup AllergenGroup { get; set; }
        public FoodGroup FoodGroup { get; set; }
        public string Description { get; set; }
    }
}
