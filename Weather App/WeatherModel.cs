using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App
{

    public class WeatherModel
    {
        public Hourly hourly { get; set; }
    }

    public class Hourly
    {
        public List<double> temperature_2m { get; set; }
        public List<int> relative_humidity_2m { get; set; }
    }

}
