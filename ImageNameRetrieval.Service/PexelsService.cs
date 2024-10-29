using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using ImageNameRetrieval.Service.Models;

namespace ImageNameRetrieval.Service
{
    public class PexelsService
    {
        /// <summary>
        /// Pexel api url
        /// </summary>
        private readonly string _url = "https://api.pexels.com/v1/";
        private readonly HttpClient _httpClient;

        public string API_KEY = "";// Environment.GetEnvironmentVariable("API_KEY");
                                          // Azure export this as a function and store key in keyvault. 
        public PexelsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pexels> GetImages(string query, int count)
        {
            try
            {
                // If adding more, consider adding endpoints to it's own library.
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_url}search?query={query}&per_page={count}");
                // Utilizing built-in API result count, cuts down on resource load compared to grabbing all and using LINQ.

                request.Headers.Add("Authorization", API_KEY);

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Pexels>();
            }
            // Can add specific exceptions for logging here.. We'll go generic with an empty response.
            catch (Exception ex)
            {
                return new Pexels { Photos = new List<Photo>() };
            }
        }
    }
}
