using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    [Serializable]
    public class ApiException : Exception
    {
        public HttpStatusCode Code { get; } = HttpStatusCode.InternalServerError;

        public ApiException(HttpStatusCode code, string message) : base(message)
        {
            Code = code;
        }
    }
}
