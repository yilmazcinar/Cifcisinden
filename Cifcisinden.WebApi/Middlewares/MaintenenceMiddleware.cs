using Cifcisinden.Business.Operations.Setting;

namespace Cifcisinden.WebApi.Middlewares
{
    public class MaintenenceMiddleware
    {
        private readonly RequestDelegate _next;
        

        public MaintenenceMiddleware(RequestDelegate next )
        {
            _next = next;
            
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var settingService = context.RequestServices.GetRequiredService(typeof(ISettingService)) as ISettingService;

            bool isMaintenenceMod = settingService.GetMaintenenceMode();
            
            if(context.Request.Path.StartsWithSegments("api/auth/login") || context.Request.Path.StartsWithSegments("api/setting"))
            {
                await _next(context);
                return;
            }
            
            if (isMaintenenceMod)
            {
                await context.Response.WriteAsync("Bakım modunda. Lütfen daha sonra tekrar deneyin.");
            }
            else
            {
                await _next(context);
            }
        }


    }
}
