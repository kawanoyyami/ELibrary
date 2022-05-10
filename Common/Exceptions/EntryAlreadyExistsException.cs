using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class EntryAlreadyExistsException : ApiException
    {
        public override HttpStatusCode Code => HttpStatusCode.BadRequest;
        public EntryAlreadyExistsException(string message) : base( message)
        {
        }
    }
}