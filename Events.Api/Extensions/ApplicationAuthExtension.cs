using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Events.Api.Extensions
{
    public static class ApplicationAuthExtension
    {
        public static IServiceCollection AddAuthentificate(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://localhost:7233";
                    options.Audience = "eventsApi";
                    options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
                });
            return services;    
        }
    }
}
