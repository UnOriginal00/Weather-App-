using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Weather_App
{
    public class GetLocationApi
    {
        readonly string key = "AIzaSyC2wy16rPLNeCuaKcMXVKDxivMl353AAYI";
        readonly string url = "https://api.ipgeolocation.io/ipgeo?apiKey=0ab66ccb272e4606922bd92c03d3646b";


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
