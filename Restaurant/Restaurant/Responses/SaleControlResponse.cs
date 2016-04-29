using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Core.EntityLayer;
using System.Runtime.Serialization;
namespace Restaurant.Responses
{
    public class SaleControlResponse:Response
    {
        public SaleControlResponse()
        {

        }
        [DataMember(Name = "model")]
        public List<SaleControl> Model { get; set; }
    }
}