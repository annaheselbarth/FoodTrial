using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Data
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public AllergenGroup AllergenGroup { get; set; }
        //public FoodGroup FoodGroup { get; set; }



    }
}
