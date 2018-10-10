using ClientConvertisseurV1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV1.Service
{
    public class WSService
    {
        static HttpClient client = new HttpClient();
        static WSService wsService = null;

        private WSService()
        {
        }

        public static WSService GetInstance()
        {
            if (wsService == null)
            {
                wsService = new WSService();
            }

            return wsService;
        }

        public static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:1702/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public async Task<List<Devise>> GetAllDevisesAsync(string path)
        {
            await RunAsync();
            List<Devise> devises = new List<Devise>();
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                devises = await response.Content.ReadAsAsync<List<Devise>>();
            }

            return devises;
        }
    }
}
