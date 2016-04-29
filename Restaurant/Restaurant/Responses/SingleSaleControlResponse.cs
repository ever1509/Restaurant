using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Core.EntityLayer;
using System.Runtime.Serialization;
namespace Restaurant.Responses
{
    public class SingleSaleControlResponse:Response
    {
        public SingleSaleControlResponse()
        {

        }
        [DataMember(Name = "model")]
        public SaleControl Model { get; set; }
    }
}