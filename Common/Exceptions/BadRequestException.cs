using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class BadRequestException : ApiException
    {
        public override HttpStatusCode Code => HttpStatusCode.BadRequest;
        public BadRequestException(string message) : base( message)
        {
        }
    }
}