namespace Cifcisinden.WebApi.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMaintenenceMode(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MaintenenceMiddleware>();
        }


        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
