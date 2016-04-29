﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Core.EntityLayer;
using System.Runtime.Serialization;
namespace Restaurant.Responses
{
    public class UserTypesResponse:Response
    {
        public UserTypesResponse()
        {

        }
        [DataMember(Name = "model")]
        public List<UserType> Model { get; set; }
    }
}