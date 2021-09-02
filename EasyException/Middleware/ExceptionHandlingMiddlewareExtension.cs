using Microsoft.AspNetCore.Builder;

namespace EasyException.Middleware
{
    public static class ExceptionHandlingMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
