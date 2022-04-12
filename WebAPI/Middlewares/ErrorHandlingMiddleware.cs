using Common.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace WebAPI.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlingMiddleware(RequestDelegate requestDelegate, ILoggerFactory loggerFactory)
        {
            _next = requestDelegate;
            _logger = loggerFactory.CreateLogger<ErrorHandlingMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch(NotFoundException notfoundex)
            {
                _logger.LogError(notfoundex, "An NotFoundException has occured");
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, notfoundex.Message);
            }
            catch(ValidatioException vex)
            {
                _logger.LogError(vex, "An ValidatioException has occured");
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, vex.Message);
            }
            catch(EntryAlreadyExistsException exx)
            {
                _logger.LogError(exx, "An EntryAlreadyExistsException has occured");
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, exx.Message);
            }
            catch(NoAccessException ex)
            {
                _logger.LogError(ex, "An NoAccessException has occured");
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch(ValueOutOfRangeException ex)
            {
                _logger.LogError(ex, "An ValueOutOfRangeException has occured");
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An exeption has occured");
                await HandleExceptionAsync(context);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, HttpStatusCode? code = null, string message = null)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                StatusCode = code ?? HttpStatusCode.InternalServerError,
                Message = message ?? "Internal server error. Please contact the development team."
            }));
        }
    }
}
