using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class InvalidFormException: Exception
    {
        public string PublicMessage { get; }

        public int ReturnStatusCode { get; }
        public InvalidFormException(string message, string publicMessage, int returnStatusCode = StatusCodes.Status400BadRequest) : base(message)
        {
            PublicMessage = publicMessage;
            ReturnStatusCode = returnStatusCode;
        }
    }
}
