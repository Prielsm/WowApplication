using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WowApplication.API.Models.CreatureModelsAPI;
using WowApplication.API.Models.ItemModelsAPI;
using WowApplication.API.Models.MountModelsAPI;
using WowApplication.API.Models.SharedModelsAPI;

namespace WowApplication.API.Functions
{
    public class ItemRepoAPI
    {
        public const string baseURL = "https://eu.api.blizzard.com/";
        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Gets the item by identifier.
        /// </summary>
        /// <param name="requiredNamespace">The required namespace.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <returns></returns>
        public static async Task<RootItem> GetItemById(string requiredNamespace, string locale, int itemId)
        {
            Console.WriteLine("Début de la recherche d'un item via son ID");
            UriBuilder uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Path = $"data/wow/item/" + itemId.ToString();
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["namespace"] = requiredNamespace;
            query["locale"] = locale;
            uriBuilder.Query = query.ToString();

            var request = AuthentificationRepoAPI.CreateHttpRequest(HttpMethod.Get, uriBuilder.Uri);

            var response = httpClient.SendAsync(request).Result;

            var content = await response.Content.ReadAsStringAsync();

            if (content != null)
            {
                RootItem result = JsonConvert.DeserializeObject<RootItem>(content);
                if (result != null)
                {
                    Console.WriteLine("Récupération de l'item OK");
                    return result;
                }
            }

            Console.WriteLine("Récupération de l'item KO");
            return null;
        }

        /// <summary>
        /// Gets the media item by identifier.
        /// </summary>
        /// <param name="requiredNamespace">The required namespace.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="itemId">The creature identifier.</param>
        /// <returns></returns>
        public static async Task<RootMedia> GetMediaItemById(string requiredNamespace, string locale, int itemId)
        {
            Console.WriteLine("Début de la recherche du media d'une instance via son ID");
            UriBuilder uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Path = $"data/wow/media/item/" + itemId.ToString();
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
                    Console.WriteLine("Récupération du media de l'item OK");
                    return result;
                }
            }

            Console.WriteLine("Récupération du media de l'item KO");
            return null;
        }


        /// <summary>
        /// Call the mount by name directly
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="requiredNamespace">The required namespace.</param>
        /// <param name="locale">The locale.</param>
        /// <returns>The mount</returns>
        public static async Task<RootMount> SearchMount(string requiredNamespace, string locale, string name, string orderBy = "id", string sortOrder = "desc", int page = 1)
        {
            Console.WriteLine("Début de la recherche sur les montures");
            UriBuilder uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Path = $"data/wow/search/mount";
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["namespace"] = requiredNamespace;
            query["locale"] = locale;
            query["orderby"] = orderBy + ":" + sortOrder;
            query["_page"] = page.ToString();
            query["name.en_US"] = name;
            uriBuilder.Query = query.ToString();

            var request = AuthentificationRepoAPI.CreateHttpRequest(HttpMethod.Get, uriBuilder.Uri);

            var response = httpClient.SendAsync(request).Result;

            var content = await response.Content.ReadAsStringAsync();

            if (content != null)
            {
                RootMount result = JsonConvert.DeserializeObject<RootMount>(content);
                if (result.results != null && result.results.Count > 0)
                {
                    Console.WriteLine("Récupération des résultats de la recherche des montures OK");
                    return result;
                }
            }

            Console.WriteLine("Récupération des résultats de la recherche des montures KO");
            return null;
        }

        /// <summary>
        /// Call the creature by name directly
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="requiredNamespace">The required namespace.</param>
        /// <param name="locale">The locale.</param>
        /// <returns>The creature</returns>
        public static async Task<RootCreature> SearchCreature(string requiredNamespace, string locale, string name, string orderBy = "id", string sortOrder = "desc", int page = 1)
        {
            Console.WriteLine("Début de la recherche sur les créatures");
            UriBuilder uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Path = $"data/wow/search/creature";
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["namespace"] = requiredNamespace;
            query["locale"] = locale;
            query["orderby"] = orderBy + ":" + sortOrder;
            query["_page"] = page.ToString();
            query["name.en_US"] = name;
            uriBuilder.Query = query.ToString();

            var request = AuthentificationRepoAPI.CreateHttpRequest(HttpMethod.Get, uriBuilder.Uri);

            var response = httpClient.SendAsync(request).Result;

            var content = await response.Content.ReadAsStringAsync();

            if (content != null)
            {
                RootCreature result = JsonConvert.DeserializeObject<RootCreature>(content);
                if (result.results != null && result.results.Count > 0)
                {
                    Console.WriteLine("Récupération des résultats de la recherche des créatures OK");
                    return result;
                }
            }

            Console.WriteLine("Récupération des résultats de la recherche des créatures KO");
            return null;
        }

        /// <summary>
        /// Gets the media creature by identifier.
        /// </summary>
        /// <param name="requiredNamespace">The required namespace.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="creatureDisplayId">The creature display identifier.</param>
        /// <returns></returns>
        public static async Task<RootMedia> GetMediaCreatureById(string requiredNamespace, string locale, int creatureDisplayId)
        {
            Console.WriteLine("Début de la recherche du media d'une créature via son ID");
            UriBuilder uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Path = $"data/wow/media/creature-display/" + creatureDisplayId.ToString();
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
                    Console.WriteLine("Récupération du media de la créature OK");
                    return result;
                }
            }

            Console.WriteLine("Récupération du media de la créature KO");
            return null;
        }
    }
}
