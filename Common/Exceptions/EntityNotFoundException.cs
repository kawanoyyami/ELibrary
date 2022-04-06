using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string PublicMessage { get; }

        public int ReturnStatusCode { get; }

        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message, string publicMessage, int returnStatusCode = StatusCodes.Status404NotFound) : base(message)
        {
            PublicMessage = publicMessage;
            ReturnStatusCode = returnStatusCode;
        }

        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
