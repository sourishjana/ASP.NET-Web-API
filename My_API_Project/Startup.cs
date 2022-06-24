using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using My_API_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_API_Project
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My_API_Project", Version = "v1" });
            });

            services.AddTransient<CustomMiddleware1>();

            // singleton service DI:--------------------------
            //services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

            // Scoped service DI:-------------------------
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();


            // when more than one Repository implement the same IRepository
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IEmployeeRepository, TestRepository>(); // 2nd declaration will override the 1st one


            // by using TryAddScoped we will not take similar registrations after the first registration
            services.TryAddScoped<IEmployeeRepository, EmployeeRepository>();
            services.TryAddScoped<IEmployeeRepository, TestRepository>(); // 2nd registration will be skipped

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Map() Method
            /*app.Use(async (context, next) => // creating a new middleware
            {
                await context.Response.WriteAsync("Hello from Use-1\n");
                await next(); // passing to next middleware
                await context.Response.WriteAsync("Hello from Use-1 after getting response from next\n");
            });

            app.UseMiddleware<CustomMiddleware1>();

            app.Map("/sourish",CustomCode);*/

            /*
            // Use() method
            app.Use(async (context,next) => // creating a new middleware
            {
                await context.Response.WriteAsync("Hello from Use-1\n");
                await next(); // passing to next middleware
                await context.Response.WriteAsync("Hello from Use-1 after getting response from next\n");
            });
            app.Use(async (context, next) => // creating a new middleware
            {
                await context.Response.WriteAsync("Hello from Use-2\n");
                await next(); // passing to next middleware
                await context.Response.WriteAsync("Hello from Use-2 after getting response from next\n");
            });
            app.Use(async (context, next) => // creating a new middleware
            {
                await context.Response.WriteAsync("Request complete\n");
            });
            */

            /*
            // Run() method
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from Run");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from Run 2");
            });*/

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My_API_Project v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        private void CustomCode(IApplicationBuilder app)
        {
            app.Use(async (context, next) => // creating a new middleware
            {
                await context.Response.WriteAsync("Hello from Sourish\n");
            });
        }
    }
}
