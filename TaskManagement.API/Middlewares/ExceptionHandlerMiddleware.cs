namespace TaskManagement.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        readonly ILogger<ExceptionHandlerMiddleware> logger;
        readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();

                logger.LogError(ex,$"{errorId} : {ex.Message}");
                
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                
                var error = new
                {
                    Id = errorId,
                    Message = "An unexpected error occurred. Please try again later."
                };
                
                await context.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
