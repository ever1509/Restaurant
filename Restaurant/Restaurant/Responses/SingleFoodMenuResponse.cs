using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Core.EntityLayer;
using System.Runtime.Serialization;
namespace Restaurant.Responses
{
    public class SingleFoodMenuResponse:Response
    {
        public SingleFoodMenuResponse()
        {

        }
        [DataMember(Name = "model")]
        public FoodMenu Model { get; set; }
    }
}