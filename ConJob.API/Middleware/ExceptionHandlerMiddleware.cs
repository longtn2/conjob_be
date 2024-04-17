using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace ConJob.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.LogInformation($"Currently in use Of Exception Handler");
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex.GetType()}");
                
                if(ex is DbUpdateException)
                {
                    ResponseErrorAsync(context, ex.Message, 400);
            }
                else
            {
                    ResponseErrorAsync(context, "Internal Server Error", 500);
                }
            }
            
            }
        private async void ResponseErrorAsync(HttpContext context, string msg, int status_code)
        {
            
            context.Response.StatusCode = status_code;
            context.Response.ContentType = "application/json";
            var response = new
            {
                message = msg
            };
            var jsonResponse = JsonConvert.SerializeObject(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
