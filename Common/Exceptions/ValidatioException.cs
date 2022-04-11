using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class ValidatioException : ApiException
    {
        public ValidatioException(string message) : base(HttpStatusCode.NotFound, message)
        {

        }
    }
}
