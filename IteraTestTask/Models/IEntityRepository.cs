using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IteraTestTask.Models
{
    public interface IEntityRepository
    {
        IEnumerable<FoodOrder> List();
        FoodOrder Get(int? id);
        void Create(FoodOrder foodOrder);
        void Update(FoodOrder foodOrder);
        void Delete(FoodOrder foodOrer);
    }
}