using ICSApp.ActivityService.Application.Interfaces;
using ICSApp.ActivityService.Infra.Context;
using ICSApp.ActivityService.Infra.Repositories;
using ICSApp.ActivityService.Infra.UnitsOfWork;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http.Headers;

namespace ICSApp.ActivityService.WebClient
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("Connection");

            services.AddDbContext<DbContext, ActivityDbContext>(options =>
            {
                options.UseMySQL(connection, b => b.MigrationsAssembly("ICSApp.ActivityService.Infra"));
            });

            services.AddHttpClient("Incident Microservice", client =>
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri("https://localhost:44334/");
            });

            services.AddScoped<IUnitOfWork, ActivityUnitOfWork>();
            services.AddScoped<IUnitOfWork, SectionUnitOfWork>();
            services.AddScoped<IUnitOfWork, StatusUnitOfWork>();
            services.AddScoped<IRepository, ActivityRepository>();
            services.AddScoped<IRepository, SectionRepository>();
            services.AddScoped<IRepository, StatusRepository>();
            services.AddTransient<IActivityService, Application.Services.ActivityService>();
            services.AddTransient<ISectionService, Application.Services.SectionService>();
            services.AddTransient<IStatusService, Application.Services.StatusService>();

            services.AddControllers();

            services.AddAuthorization();
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:44310";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "ActivityMicroservice_ResourceApi";

                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
