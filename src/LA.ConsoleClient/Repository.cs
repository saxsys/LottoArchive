using LA.Domain;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace LA.ConsoleClient
{
    public class Repository : IRepository
    {
        private readonly HttpClient httpClient;

        private readonly DataContractJsonSerializer serializer;

        private const string RemoteUrl = "http://lawebapi.azurewebsites.net/";

        public Repository(HttpClient httpClient, DataContractJsonSerializer serializer)
        {
            this.httpClient = httpClient;
            this.serializer = serializer;

            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            this.httpClient.DefaultRequestHeaders.Add("User-Agent", "Lotto Archive Console Client");
        }

        public async Task<Drawing[]> Values(DateRange dateRange)
        {
            const string dateFormat = "yyyy-MM-dd";
            var from = dateRange.From.ToString(dateFormat);
            var to = dateRange.To.ToString(dateFormat);

            var httpResult = await this.httpClient.GetStreamAsync($"{RemoteUrl}/values?from={from}&to={to}");
            var value = this.serializer.ReadObject(httpResult) as ValueRepresentation;

            return value == null ? new Drawing[0] : value.Values;
        }
    }
}
