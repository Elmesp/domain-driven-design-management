namespace Emerging.Account.WebApi.Services.Auth0
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    public static class Auth0StartupExtensions
    {
        public static IServiceCollection AddAuth0(this IServiceCollection services, Auth0Config config)
        {
            if (string.IsNullOrWhiteSpace(config.ClientId))
            {
                throw new ArgumentNullException(nameof(config.ClientId), "The Auth0 client ID is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(config.Connection))
            {
                throw new ArgumentNullException(nameof(config.Connection), "The Auth0 connection is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(config.SignupUrl))
            {
                throw new ArgumentNullException(nameof(config.SignupUrl), "The Auth0 signup URL is null or empty.");
            }

            return services.AddTransient<Auth0Config>(_ => new Auth0Config
            {
                ClientId = config.ClientId,
                Connection = config.Connection,
                SignupUrl = config.SignupUrl
            });
        }
    }
}
