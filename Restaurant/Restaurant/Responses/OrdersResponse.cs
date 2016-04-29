using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Core.EntityLayer;
using System.Runtime.Serialization;
namespace Restaurant.Responses
{
    public class OrdersResponse:Response
    {
        public OrdersResponse()
        {

        }
        [DataMember(Name = "model")]
        public List<Orders> Model { get; set; }
    }
}