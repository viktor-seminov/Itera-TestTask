using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IteraTestTask.Models
{
    public class FoodOrder
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field Dish must be not empty")]
        [Display(Name = "Dish")]
        [StringLength(255)]
       // [RegularExpression(@"[A-Za-z]+", ErrorMessage ="Field dish must contain only alphabetic chars")]
        public string DishName { get; set; }
        [Required(ErrorMessage = "Field Count must be not empty")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Count { get; set; }
    }
}