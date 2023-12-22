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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LocalPass
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Page
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Authentification());
        }

        private void signInExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void signInAccount_Click(object sender, RoutedEventArgs e)
        {
                   var errorColor = Brushes.Red;

                     if (PasswordCreatorServices.UserExists(signInUsername.Text, Authentification.HashPassword(signInPassword.Password)))
                     {
                         var currentUser = PasswordCreatorServices.GetUser(signInUsername.Text, Authentification.HashPassword(signInPassword.Password));
                         PasswordCreatorServices.SetCurrentUser(currentUser);
                         NavigationService.Navigate(new Homepage());
                     }
                     else
                     {
                         signInErrorMessage.Text = "Username or Password incorrect or does not exist";
                         signInPassword.BorderBrush = errorColor;
                         signInUsername.BorderBrush = errorColor;
                     }
        }
    }
}
