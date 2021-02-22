using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WowApplication.API.Models.InstanceModelsAPI;
using WowApplication.API.Models.SharedModelsAPI;

namespace WowApplication.API.Functions
{
    class InstanceRepoAPI
    {
        public const string baseURL = "https://eu.api.blizzard.com/";
        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Call the instance index directly
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="requiredNamespace">The required namespace.</param>
        /// <param name="locale">The locale.</param>
        /// <returns>The creature types</returns>
        public static async Task<RootIndexInstance> GetInstanceIndex(string requiredNamespace, string locale)
        {
            Console.WriteLine("Début de la récupération des index des instances");
            UriBuilder uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Path = $"data/wow/journal-instance/index";
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["namespace"] = requiredNamespace;
            query["locale"] = locale;
            uriBuilder.Query = query.ToString();

            var request = AuthentificationRepoAPI.CreateHttpRequest(HttpMethod.Get, uriBuilder.Uri);

            var response = httpClient.SendAsync(request).Result;

            var content = await response.Content.ReadAsStringAsync();

            if (content != null)
            {
                RootIndexInstance result = JsonConvert.DeserializeObject<RootIndexInstance>(content);
                if (result.instances != null && result.instances.Count > 0)
                {
                    Console.WriteLine("Récupération des index des instances OK");
                    return result;
                }
            }

            Console.WriteLine("Récupération des index des instances KO");
            return null;
        }


        /// <summary>
        /// Gets the instance by identifier.
        /// </summary>
        /// <param name="requiredNamespace">The required namespace.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="instanceId">The creature identifier.</param>
        /// <returns></returns>
        public static async Task<RootInstance> GetInstanceById(string requiredNamespace, string locale, int instanceId)
        {
            Console.WriteLine("Début de la recherche d'une instance via son ID");
            UriBuilder uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Path = $"data/wow/journal-instance/" + instanceId.ToString();
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["namespace"] = requiredNamespace;
            query["locale"] = locale;
            uriBuilder.Query = query.ToString();

            var request = AuthentificationRepoAPI.CreateHttpRequest(HttpMethod.Get, uriBuilder.Uri);

            var response = httpClient.SendAsync(request).Result;

            var content = await response.Content.ReadAsStringAsync();

            if (content != null)
            {
                RootInstance result = JsonConvert.DeserializeObject<RootInstance>(content);
                if (result != null)
                {
                    Console.WriteLine("Récupération de l'instance OK");
                    return result;
                }
            }

            Console.WriteLine("Récupération de l'instance KO");
            return null;
        }


        /// <summary>
        /// Gets the media instance by identifier.
        /// </summary>
        /// <param name="requiredNamespace">The required namespace.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="instanceId">The creature identifier.</param>
        /// <returns></returns>
        public static async Task<RootMedia> GetMediaInstanceById(string requiredNamespace, string locale, int instanceId)
        {
            Console.WriteLine("Début de la recherche du media d'une instance via son ID");
            UriBuilder uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Path = $"data/wow/media/journal-instance/" + instanceId.ToString();
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["namespace"] = requiredNamespace;
            query["locale"] = locale;
            uriBuilder.Query = query.ToString();

            var request = AuthentificationRepoAPI.CreateHttpRequest(HttpMethod.Get, uriBuilder.Uri);

            var response = httpClient.SendAsync(request).Result;

            var content = await response.Content.ReadAsStringAsync();

            if (content != null)
            {
                RootMedia result = JsonConvert.DeserializeObject<RootMedia>(content);
                if (result != null)
                {
                    Console.WriteLine("Récupération du media de l'instance OK");
                    return result;
                }
            }

            Console.WriteLine("Récupération du media de l'instance KO");
            return null;
        }


    }
}
