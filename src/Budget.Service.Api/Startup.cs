using Budget.Service.Api.Extensions;
using Budget.Service.Api.Middlewares;
using Budget.Service.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Budget.Service.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.PrepareAndAddSwagger();
            services.AddMediators();
            services.AddDbContext(new DatabaseOptions
            {
                Address = "localhost",
                Port = 5432,
                DatabaseName = "family_planner",
                Username = "application_user",
                Password = "application_user"
            });
            services.AddRepositories();

            services.AddMvc()
                .AddMvcOptions(c =>
               {
                   c.EnableEndpointRouting = false;
               })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.PrepareAndUseSwagger(env);
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseMvcWithDefaultRoute();
        }
    }
}
