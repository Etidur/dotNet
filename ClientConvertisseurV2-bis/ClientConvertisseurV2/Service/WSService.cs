using ClientConvertisseurV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Service
{
    /// <summary>
    /// Classe permettant de se connecter à l'API
    /// </summary>
    class WSService
    {
        static HttpClient client = new HttpClient();
        static WSService wsService = null;

        private WSService()
        {
            client.BaseAddress = new Uri("http://localhost:1702/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        /// <summary>
        /// Fourni un singleton
        /// </summary>
        /// <returns></returns>
        public static WSService GetInstance()
        {
            if (wsService == null)
            {
                wsService = new WSService();
            }

            return wsService;
        }

        /// <summary>
        /// Récupère la list de toutes les devises présentes dans l'API
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<List<Devise>> GetAllDevisesAsync(string path)
        {
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
