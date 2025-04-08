using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CarExpo.FilterException
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> _logger)
        {
            this._logger = _logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Unhandled Exception");

            var response = new
            {
                message = context.Exception.Message,
                exceptiontype = context.Exception.GetType().Name,
                stackTrace = context.Exception.StackTrace,
                time = DateTime.UtcNow
            };

            context.Result = new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };

            context.ExceptionHandled = true;
        }
    }
}
