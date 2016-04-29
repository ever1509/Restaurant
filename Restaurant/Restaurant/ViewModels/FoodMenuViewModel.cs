using Restaurant.Core.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.ViewModels
{
    public class FoodMenuViewModel
    {
        public FoodMenuViewModel()
        {

        }
        public FoodMenuViewModel(FoodMenu item)
        {
            FoodName = item.FoodName;
            Description = item.DescriptionFood;
            PreparationTime = item.PreparationTime;
            Status = item.FoodStatus;
        }
        public String FoodName { get; set; }
        public String Description { get; set; }
        public DateTime? PreparationTime { get; set; }
        public Boolean? Status { get; set; }
    }
}