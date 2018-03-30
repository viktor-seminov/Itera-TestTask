using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IteraTestTask.Models
{
    public enum SortState
    {
        IdAsc,    // Name asc
        IdDesc,   // Name desc
        DishNameAsc, // по возрасту по возрастанию
        DishNameDesc,    // по возрасту по убыванию
        CountAsc, // по компании по возрастанию
        CountDesc // по компании по убыванию
    }
}