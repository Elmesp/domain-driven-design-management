namespace Emerging.Account.WebApi
{
    using System;
    using Emerging.Account.DomainModel.Repositories;
    using Emerging.Account.DomainModel.Services;
    using Emerging.Account.PostgresRepository;
    using Emerging.Account.WebApi.Services.Auth0;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private Auth0Config Auth0Config { get { return GetAuth0Configuration(); } }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHttpClient()
                .AddAuth0(Auth0Config)
                .AddTransient<Auth0Service>()
                .AddDbContext<AccountContext>(o => o.UseNpgsql(Environment.GetEnvironmentVariable("EMERGING_ACCOUNT_CONNECTIONSTRING")))
                .AddTransient<AccountRepository, PostgresRepository>()
                .AddTransient<AccountService>()
                .AddCors(setup => setup.AllowAll("AllowAll"))
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app
                .UseCors("AllowAll")
                .UseHttpsRedirection()
                .UseMvc();
        }

        private Auth0Config GetAuth0Configuration()
        {
            return new Auth0Config
            {
                ClientId = Environment.GetEnvironmentVariable("EMERGING_ACCOUNT_AUTH0_CLIENTID"),
                Connection = Environment.GetEnvironmentVariable("EMERGING_AUTH0_CONNECTION"),
                SignupUrl = Environment.GetEnvironmentVariable("EMERGING_AUTH0_SIGNUPURL")
            };
        }
    }
}
