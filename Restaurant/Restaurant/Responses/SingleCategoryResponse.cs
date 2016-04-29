using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Core.EntityLayer;
using System.Runtime.Serialization;
namespace Restaurant.Responses
{
    public class SingleCategoryResponse:Response
    {
        public SingleCategoryResponse()
        {

        }
        [DataMember(Name = "model")]
        public Categories Model { get; set; }
    }
}