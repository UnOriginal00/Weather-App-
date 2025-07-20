using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Weather_App
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
            ApiHelper.inizialiseClient();
        }

        readonly public GetLocationApi getLocationApi = new GetLocationApi();

        private void preventInteraction(UIElement uIElement)
        {
            uIElement.IsEnabled = false;
        }


        private void userNameInputSave_Click(object sender, RoutedEventArgs e)
        {


            if (userNameInput == null || userNameInput.Text == "")
            {

                invalidInputException.Foreground = Brushes.Red;

            }
            else
            {
                invalidInputException.Foreground = Brushes.White;
                UserNameInfo.UserName = userNameInput.Text;
                preventInteraction(userNameInput);
                userNameInputSave.Content = "Saved!";
            }

            moveToMainWindow();

        }

        public async void userLocationInput_Click(object sender, RoutedEventArgs e)
        {

            LocationModel locationModel = await getLocationApi.getLocation();
            Location.Latitude = locationModel.latitude;
            Location.Longitude = locationModel.longitude;
            userLocationInput.Content = "Location Saved!";

        }

        private void userLocationInputSave_Click(object sender, RoutedEventArgs e)
        {
            if (Location.Latitude == null)
            {
                userLocationInput.Foreground = Brushes.Red;
                userLocationInput.Content = "Click here before saving";

            }
            else 
            {
                preventInteraction(userLocationInput);
                userLocationInputSave.Content = "Saved!";
                moveToMainWindow();
            }

        }



        public void moveToMainWindow()
        {
            if (userLocationInput.IsEnabled == false && userNameInput.IsEnabled == false)
            {
                var mainWindow = new MainWindow(); // Or whatever your next window class is
                mainWindow.Show();
                this.Close(); // Close current window if you wa
            }
        }

    }
}
