using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using Microsoft.Extensions.DependencyInjection;

namespace LA.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<HttpClient>();
            services.AddSingleton(new DataContractJsonSerializer(typeof(ValueRepresentation)));
            services.AddScoped<IRepository, Repository>();

            Console.ReadKey();
        }
    }
}
