using System.Data.Entity.Infrastructure;

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
            catch (DbUpdateException e)
            {
                _logger.LogError($"Conflict DB: {e}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex}");
            }
            
        }
    }
}
