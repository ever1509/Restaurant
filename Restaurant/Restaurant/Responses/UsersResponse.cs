using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Core.EntityLayer;
using System.Runtime.Serialization;
namespace Restaurant.Responses
{
    public class UsersResponse:Response
    {
        public UsersResponse()
        {

        }
        [DataMember(Name = "model")]
        public List<User> Model { get; set; }
    }
}