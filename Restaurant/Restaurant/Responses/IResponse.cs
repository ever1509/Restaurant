using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Responses
{
    public interface IResponse
    {
        Boolean? DidError { get; set; }
        String ErrorMessage { get; set; }
        String Message { get; set; }
    }
}
