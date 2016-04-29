using Restaurant.Core.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Restaurant.Responses
{
    public class CategoriesResponse:Response
    {
        public CategoriesResponse()
        {

        }
        [DataMember(Name = "model")]
        public List<Categories> Model { get; set; }
    }
}