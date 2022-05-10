using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class NotFoundException : ApiException
    {

        public override HttpStatusCode Code => HttpStatusCode.NotFound;

        public NotFoundException(string message) : base(message)
        {
        }
    }
}