using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace LA.ConsoleClient
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<HttpClient>();
            services.AddScoped<IRepository, Repository>();
            services.AddSingleton<UserInteraction>();

            var serviceProvider = services.BuildServiceProvider();
            var userInteraction = serviceProvider.GetService<UserInteraction>();

            await userInteraction.Run();
        }
    }
}