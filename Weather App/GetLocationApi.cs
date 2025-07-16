
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace Weather_App
{
    public class GetLocationApi
    {
        readonly string key;
        readonly string url;


        public GetLocationApi()
        {
            // Read the API key from environment variable
            key = Environment.GetEnvironmentVariable("IP_GEOLOCATION_API_KEY");

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new Exception("API key not found in environment variables.");
            }

            url = $"https://api.ipgeolocation.io/ipgeo?apiKey={key}";
        }


        public async Task<LocationModel> getLocation() 
        {

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode) 
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    LocationModel locationModel = JsonSerializer.Deserialize<LocationModel>(jsonString);
                    return locationModel;
                }
                else 
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }

        }
        

    }
}
