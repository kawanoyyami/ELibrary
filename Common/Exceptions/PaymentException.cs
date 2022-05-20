using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class PaymentException : ApiException
    {
        public override HttpStatusCode Code => HttpStatusCode.RequestedRangeNotSatisfiable;
        public PaymentException(string message) : base(message)
        {

        }
    }
}
