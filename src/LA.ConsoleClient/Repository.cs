using System.Collections.Generic;
using LA.Domain;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LA.ConsoleClient
{
    public class Repository : IRepository
    {
        private readonly HttpClient httpClient;

        private const string RemoteUrl = "http://lawebapi.azurewebsites.net/";

        public Repository(HttpClient httpClient)
        {
            this.httpClient = httpClient;

            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            this.httpClient.DefaultRequestHeaders.Add("User-Agent", "Lotto Archive Console Client");
        }

        public async Task<List<DrawingAttribute>> Values(DateRange dateRange)
        {
            const string dateFormat = "yyyy-MM-dd";
            var from = dateRange.From.ToString(dateFormat);
            var to = dateRange.To.ToString(dateFormat);

            var httpResult = await this.httpClient.GetStringAsync($"{RemoteUrl}/values?from={from}&to={to}");
            var value = JsonConvert.DeserializeObject<ValuesAttribute>(httpResult);

            return value == null ? new List<DrawingAttribute>() : value.Values;
        }
    }
}
