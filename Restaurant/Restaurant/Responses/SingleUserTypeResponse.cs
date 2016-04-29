using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Core.EntityLayer;
using System.Runtime.Serialization;
namespace Restaurant.Responses
{
    public class SingleUserTypeResponse:Response
    {
        public SingleUserTypeResponse()
        {

        }
        [DataMember(Name = "model")]
        public UserType Model { get; set; }
    }
}