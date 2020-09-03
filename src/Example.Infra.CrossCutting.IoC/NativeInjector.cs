using Example.Application.Example.Repository;
using Example.Application.Example.Services;
using Example.Domain.SeedWork;
using Example.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Infra.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void Setup(IServiceCollection services)
        {
            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IExampleService, ExampleService>();
            services.AddScoped<INotification, Notification>();
            services.AddScoped<IExampleRepository, ExampleRepository>();
        }
    }
}
