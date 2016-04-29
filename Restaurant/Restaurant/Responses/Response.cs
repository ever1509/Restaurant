using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Responses
{
    public class Response:IResponse
    {
        [JsonProperty]
        public Boolean? DidError { get; set; }
        [JsonProperty]
        public String ErrorMessage { get; set; }
        [JsonProperty]
        public String Message { get; set; }
    }
}