namespace WebAPI.Middlewares
{
    public class RequestLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private static int _currentRequestCount = 0;
        private readonly ParallelLimitConfig _parallelLimitConfig;

        public RequestLimitMiddleware(RequestDelegate next, ParallelLimitConfig parallelLimitConfig)
        {
            _next = next;
            _parallelLimitConfig = parallelLimitConfig;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (_currentRequestCount >= _parallelLimitConfig.ParallelLimit)
            {
                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                await context.Response.WriteAsync("Service Unavailable: Too many requests.");
            }
            else
            {
                _currentRequestCount++;

                try
                {
                    await _next(context);
                }
                finally
                {
                    _currentRequestCount--;
                }
            }
        }
    }
}
