using OtakuTrack.Services.Interfaces.LogError;
using System;
using System.Net;

namespace OtakuTrack.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IErrorLogService _errorLogService;

        public ErrorHandlingMiddleware(IErrorLogService errorLogService, RequestDelegate next)
        {
            _errorLogService = errorLogService;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            await _errorLogService.LogErrorAsync(ex.Message, ex.StackTrace);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = new { error = "An error occurred while processing your request." };
            await context.Response.WriteAsJsonAsync(result);
        }
    }
}
