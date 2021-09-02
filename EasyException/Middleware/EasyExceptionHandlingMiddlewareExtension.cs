using Microsoft.AspNetCore.Builder;

namespace EasyException.Middleware
{
    public static class EasyExceptionHandlingMiddlewareExtension
    {
        public static IApplicationBuilder UseEasyExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<EasyExceptionHandlingMiddleware>();
        }
    }
}
