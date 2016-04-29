using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Core.EntityLayer;
using System.Runtime.Serialization;
namespace Restaurant.Responses
{
    public class SingleOrderResponse:Response
    {
        public SingleOrderResponse()
        {

        }
        [DataMember(Name = "model")]
        public Orders Model { get; set; }
    }
}