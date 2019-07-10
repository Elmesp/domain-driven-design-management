namespace Emerging.Account.WebApi
{
    using Microsoft.AspNetCore.Cors.Infrastructure;

    public static class StartupExtensions
    {
        public static void AllowAll(this CorsOptions setup, string policyName)
        {
            setup.AddPolicy(policyName, policy => policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
        }
    }
}
