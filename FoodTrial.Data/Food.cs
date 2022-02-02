using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Data
{
    public enum AllergenGroup { latex, legume, treenut, pollen, histamine, medicine, citrus }
    public enum FoodGroup { fruit, protein, dairy, vegetables, carbohydrate, fats, oils}
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public AllergenGroup AllergenGroup { get; set; }
        [Required]
        public FoodGroup FoodGroup { get; set; }



    }
}
