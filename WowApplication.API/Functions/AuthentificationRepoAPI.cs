﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WowApplication.API.Models.AuthentificationModelsAPI;

namespace WowApplication.API.Functions
{
    public static class AuthentificationRepoAPI 
    {
        public static string token = "";
        public const string baseTokenURL = "https://eu.battle.net/oauth/token";

        /// <summary>
        /// Creates the HTTP request asynchronous.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// The http request message
        /// </returns>
        public static HttpRequestMessage CreateHttpRequest(HttpMethod method, Uri url)
        {
            var message = new HttpRequestMessage(method, url);

            if (string.IsNullOrEmpty(token)) // TODO : gérer le fait qu'il soit encore rempli mais qu'il ne soit plus valable
                InitializeAccessToken("b6b4ab532cb245c28315b1b2c606166b", "6Qw6ncBG8cQJBiPiuD2HihmrIbYUEzqE");

            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return message;
        }

        public static void InitializeAccessToken(string clientId, string clientSecret)
        {
            Console.WriteLine("Début de la récupération du token");
            var client = new RestClient(baseTokenURL);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id={clientId}&client_secret={clientSecret}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var tokenResponse = JsonConvert.DeserializeObject<AccessTokenResponse>(response.Content);

            Console.WriteLine("Fin de la récupération du token");
            token = tokenResponse.access_token;
        }
    }

    
}
