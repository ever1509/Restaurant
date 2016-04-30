using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Core.EntityLayer;
using Restaurant.ViewModels;
using System.Runtime.Serialization;
namespace Restaurant.Responses
{
    public class FoodMenusResponse:Response
    {
        public FoodMenusResponse()
        {

        }
        [DataMember(Name = "model")]
        //public List<FoodMenuViewModel> Model { get; set; }
        public List<FoodMenu> Model { get; set; }
    }
}