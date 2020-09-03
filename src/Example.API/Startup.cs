using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.Swagger;
using Microsoft.ApplicationInsights.Extensibility;

namespace Example.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connectionString = Configuration.GetSection("DefaultConnection").Value;

            services.AddScoped<IUnitOfWork>(x =>
            {
                var connection = new DbContextOptionsBuilder<ExampleContext>();

                //TODO: gerar log para development
                //if (IsDevelopment)
                //{
                //    connection.UseLoggerFactory(LoggerFactory);
                //}

                return new UnitOfWork(
                    new ExampleContext(
                        connection
                        .UseLazyLoadingProxies()
                        .UseSqlServer(connectionString, builder =>
                        {
                            //TODO: está obsleto, ver nova opção
                            //builder.UseRowNumberForPaging();
                        }).Options));
            });

            NativeInjector.Setup(services);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {

                        Title = "Raízen - CSCustomer",
                        Version = "v1",
                        Description = "API responsável por informações do usuário",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Raízen CSOnline",
                        }
                    });
            });

            services.AddApplicationInsightsTelemetry(new Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions()
            {
                EnableAdaptiveSampling = false
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            var configuration = app.ApplicationServices.GetService<TelemetryConfiguration>();

            var builder = configuration.DefaultTelemetrySink.TelemetryProcessorChainBuilder;

            builder.UseSampling(100);

            builder.Build();

            app.UseCors("AllowAllOrigins");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Raízen - CSCustomer V1");
            });
        }
    }
}
