using Microsoft.Extensions.DependencyInjection;

namespace LA.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLAServices(this IServiceCollection service)
        {
            service.AddScoped<INumberProvider, NumberProviderMock>();

            return service;
        }
    }
}
