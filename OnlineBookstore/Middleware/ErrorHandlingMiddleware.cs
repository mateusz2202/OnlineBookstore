using OnlineBookstore.Exceptions;

namespace OnlineBookstore.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (ForbidException e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(e.Message);
            }
            catch(NotFoundException e)
            {
                _logger.LogInformation(e, e.Message);
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }
            catch(BadLoginException e)
            {
                _logger.LogInformation(e, e.Message);
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode=500;
                await context.Response.WriteAsync("Error, coś poszło nie tak ");
            }
        }
    }
}
