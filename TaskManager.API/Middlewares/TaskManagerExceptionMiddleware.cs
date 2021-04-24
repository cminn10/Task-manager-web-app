using System;
using System.Net;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TaskManager.API.Middlewares
{
    public class TaskManagerExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TaskManagerExceptionMiddleware> _logger;

        public TaskManagerExceptionMiddleware(ILogger<TaskManagerExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                _logger.LogError("Middleware is catching exception");
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            //_logger.LogError("Starting Logging for exception");
            var errorModel = new ErrorResponseModel()
            {
                ExceptionMessage = e.Message,
                ExceptionStackTrace = e.StackTrace,
                InnerExceptionMessage = e.InnerException?.Message
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            _logger.LogError("An error occurred: {ErrorMessage}", errorModel.ExceptionMessage);
            await httpContext.Response.WriteAsync(errorModel.ToString() ?? string.Empty);
        }
    }
    
    public static class TaskManagerExceptionMiddlewareExtensions
    {
        public static void UseTaskManagerExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<TaskManagerExceptionMiddleware>();
        }
    }
}