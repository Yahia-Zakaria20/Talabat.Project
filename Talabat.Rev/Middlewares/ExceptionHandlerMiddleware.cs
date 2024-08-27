using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using Talabat.Rev.Errors;

namespace Talabat.Rev.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly IHostEnvironment _environment;

        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlerMiddleware> logger , IHostEnvironment environment )
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
            _environment = environment;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var Response =_environment.IsDevelopment() ? new ApiExceptionResponse((int)HttpStatusCode.InternalServerError,
                    ex.StackTrace.ToString()
                    /*,ex.Message*/) :
                     new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);

                var json = JsonSerializer.Serialize(Response);

                 await context.Response.WriteAsync(json);
            }
        }
    }
}
