using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeDotNetAPI.Database;
using FakeDotNetAPI.Services;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace FakeDotNetAPI
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                // setupAction.OutputFormatters.Add(
                //     new XmlDataContractSerializerOutputFormatter()
                // );
            }).AddXmlDataContractSerializerFormatters();
            services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();
            //services.AddSingleton
            //services.AddScoped
            services.AddDbContext<AppDbContext>(option =>
            {
                // option.UseSqlServer("server=local; Database=FakeXiechengDb; User Id=sa; Password=PaSSword12!");
                option.UseSqlServer(Configuration["DbContext:ConnectionString"]);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/test", async context =>
                // {
                //     await context.Response.WriteAsync("This is test");
                // });
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!");
                // });

                endpoints.MapControllers();
            });
        }
    }
}
