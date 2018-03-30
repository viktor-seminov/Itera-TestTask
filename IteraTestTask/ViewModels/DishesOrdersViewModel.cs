using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IteraTestTask.Models;

namespace IteraTestTask.ViewModels
{
    public class DishesOrdersViewModel
    {
        public IEnumerable<FoodOrder> FoodOrders { get; set; }
        public string DishNameFilter { get; set; }
        public int? CountFilter { get; set; }
    }
}