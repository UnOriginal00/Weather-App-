using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Weather_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.inizialiseClient();
            greetUserText.Text = $"Greetings , {UserNameInfo.UserName}";
            getWeatherData();
        }

        WeatherApi weatherApi = new WeatherApi();

        public async void getWeatherData()
        {

            WeatherModel weatherModel = await weatherApi.getWeatherData();
            double temp = weatherModel.hourly.temperature_2m[0];
            int humidity = weatherModel.hourly.relative_humidity_2m[0];
            tempretureDisplay.Text = $" {temp}°C";
            humidityDisplay.Text = $" {humidity}%";

            if (temp <= 5 ) 
            {
                summary.Text = " Why is it so \n old!!";
            }
            else if (temp <= 15) 
            {
                summary.Text = " A littly chilly, could \n be worse!";
            }

        }












    }
}