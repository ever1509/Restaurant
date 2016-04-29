using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Core.EntityLayer;
using System.Runtime.Serialization;
namespace Restaurant.Responses
{
    public class SingleUserResponse:Response
    {
        public SingleUserResponse()
        {

        }
        [DataMember(Name = "model")]
        public User Model { get; set; }
    }
}