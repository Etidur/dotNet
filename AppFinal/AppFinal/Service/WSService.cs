using AppFinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppFinal.Service
{
    public class WSService
    {
        static HttpClient client = new HttpClient();
        static WSService wsService = null;

        private WSService()
        {
            client.BaseAddress = new Uri("http://localhost:1366/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }
        
        public static WSService GetInstance()
        {
            if (wsService == null)
            {
                wsService = new WSService();
            }

            return wsService;
        }
        
        public async Task<Compte> GetCompteByEmailAsync(string path)
        {
            //comptes/GetCompteByEmail/paul.durand@gmail.com
            Compte compte = new Compte();
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                compte = await response.Content.ReadAsAsync<Compte>();
            }

            return compte;
        }
    }
}