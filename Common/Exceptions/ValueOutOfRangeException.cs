using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class ValueOutOfRangeException : ApiException
    {
        public override HttpStatusCode Code => HttpStatusCode.RequestedRangeNotSatisfiable;
        public ValueOutOfRangeException(string message) : base(message)
        {

        }
    }
}
