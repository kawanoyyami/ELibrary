using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Common.Exceptions
{
    public class NoAccessException : ApiException
    {
        public NoAccessException() : base(HttpStatusCode.Forbidden, "You don't have permission to access this resource.")
        {

        }
    }
}
