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
        }

        private void userNameInputOneSave_Click(object sender, RoutedEventArgs e)
        {


            if (userNameInput == null || userNameInput.Text == "")
            {

                invalidInputException.Foreground = Brushes.Red;

            }
            else
            {
                invalidInputException.Foreground = Brushes.White;
                string userName = userNameInput.Text;
                userNameInputSave.Content = "Saved!";
                userNameInputSave.Focus();
            }

        }
    }
}
