using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
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
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Page
    {

        public Homepage() 
        {
            InitializeComponent();

        }


        private void randomPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new RandomPasswordPage());

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void customPasswordClick(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new customPasswordPage());
        }

        private void pastPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new PastPasswords());
        }


        private void viewCurrentUser(object sender, RoutedEventArgs e)
        {
           userSettings.IsOpen = true;
            var accountUserObj = PasswordCreatorServices.CurrentUser();
            accountUser.Text = accountUserObj.Username;
        }

        private void goBackToUserSettings(object sender, RoutedEventArgs e)
        {
            deleteUserConfirmation.Visibility = Visibility.Collapsed;
            userDisplay.Visibility = Visibility.Visible;
        }

        private void deleteUser(object sender, RoutedEventArgs e)
        {
            userDisplay.Visibility = Visibility.Collapsed;
            deleteUserConfirmation.Visibility = Visibility.Visible;
        }

        private void deleteUserConfirmed(object sender, RoutedEventArgs e)
        {
            PasswordCreatorServices.DeleteUser(PasswordCreatorServices.CurrentUser());
            userSettings.IsOpen = false;
            MainFrame.NavigationService.Navigate(new LandingPage());
        }

        private void closeUserSettings(object sender, RoutedEventArgs e)
        {
            userSettings.IsOpen = false;
        }

        private void previousPageHomePage(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new LandingPage());
        }
    }
}
