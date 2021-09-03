using AcademyF.Week7.Prova7.Core.BL;
using AcademyF.Week7.Prova7.Core.Interfaces;
using AcademyF.Week7.Prova7.EF.Context;
using AcademyF.Week7.Prova7.EF.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AcademyF.Week7.Prova7.WebAPI
{
    public class Startup
    {
        public readonly string ApplicationName =
            Assembly.GetEntryAssembly().GetName().Name;
        public readonly string ApplicationVersion =
            $"v{Assembly.GetEntryAssembly().GetName().Version.Major}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Minor}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Build}";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = ApplicationName,
                    Version = ApplicationVersion
                });

                //string file = $"{typeof(Startup).Assembly.GetName().Name}.xml";
                //string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
                //c.IncludeXmlComments(xmlPath);
            });

            // DI Configuration
            // MainBusinessLayer => EFEmployeeRepository => EmployeeContext
            services.AddTransient<IMainBusinessLayer, MainBusinessLayer>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddTransient<ICustomerRepository, EFCustomerRepository>();

            services.AddDbContext<CommerceDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("E-CommerceDb"));
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint(
                    "v1/swagger.json",
                    $"{ApplicationName} {ApplicationVersion}"
                );
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
