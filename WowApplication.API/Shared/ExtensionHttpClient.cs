using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.API.Shared
{
    public static class HttpClientExtension
    {
        private const int maxRequestTries = 3;

        /// <summary>
        /// Envoie une requête GET à l'uri spécifiée de manière asynchrone.
        /// </summary>
        /// <param name="httpClient">Le client http utilisé pour la requête.</param>
        /// <param name="requestUri">L'uri de la requête.</param>
        /// <typeparam name="TReturn">Le type de retour.</typeparam>
        /// <returns>Retourne le résultat de la requête désérialisé en un objet de type <typeparamref name="TReturn" />.</returns>
        public static async Task<string> Retry(this HttpClient httpClient, HttpRequestMessage request)
        {
            var remainingTries = maxRequestTries;

            do
            {
                remainingTries--;
                var response = await httpClient.SendAsync(request).Result.Content.ReadAsStringAsync();

                if (response != null)
                {
                    return response;
                }
            }
            while (remainingTries > 0);


            // TODO : que faire dans ce cas ci?
            return null;
        }

    }
}
