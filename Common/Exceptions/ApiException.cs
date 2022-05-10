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
        public virtual HttpStatusCode Code { get; } = HttpStatusCode.BadRequest;

        public ApiException( string message) : base(message)
        {
            
        }
    }
}
