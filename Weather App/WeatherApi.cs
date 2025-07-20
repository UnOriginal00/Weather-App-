using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Weather_App
{
    class WeatherApi
    {
        
        readonly string url = $"https://api.open-meteo.com/v1/forecast?latitude={Location.Latitude}&longitude={Location.Longitude}&hourly=temperature_2m,relative_humidity_2m";

        public async Task<WeatherModel> getWeatherData() 
        {

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url)) 
            {
                if (response.IsSuccessStatusCode) 
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    WeatherModel model = JsonSerializer.Deserialize<WeatherModel>(jsonString);
                    return model;

                }
                else 
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }

        }


    }
}
