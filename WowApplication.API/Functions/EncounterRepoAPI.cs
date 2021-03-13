using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WowApplication.API.Models.EncounterModelsAPI;
using WowApplication.API.Models.SharedModelsAPI;

namespace WowApplication.API.Functions
{
    public class EncounterRepoAPI
    {
        public const string baseURL = "https://eu.api.blizzard.com/";
        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Call the encounter by name directly
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="requiredNamespace">The required namespace.</param>
        /// <param name="locale">The locale.</param>
        /// <returns>The encounter</returns>
        public static async Task<RootEncounter> SearchEncounter(string requiredNamespace, string locale, string name = null, string orderBy = "id", string sortOrder = "desc", int page = 1)
        {
            Console.WriteLine("Début de la recherche sur les boss");
            UriBuilder uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Path = $"data/wow/search/journal-encounter";
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["namespace"] = requiredNamespace;
            query["locale"] = locale;
            query["orderby"] = orderBy + ":" + sortOrder;
            query["_page"] = page.ToString();
            query["instance.name.en_US"] = name;
            uriBuilder.Query = query.ToString();

            var request = AuthentificationRepoAPI.CreateHttpRequest(HttpMethod.Get, uriBuilder.Uri);

            var response = httpClient.SendAsync(request).Result;

            var content = await response.Content.ReadAsStringAsync();

            if (content != null)
            {
                RootEncounter result = JsonConvert.DeserializeObject<RootEncounter>(content);
                if (result.results != null && result.results.Count > 0)
                {
                    Console.WriteLine("Récupération des résultats de la recherche des boss OK");
                    return result;
                }
            }

            Console.WriteLine("Récupération des résultats de la recherche des boss KO");
            return null;
        }

    }
}
