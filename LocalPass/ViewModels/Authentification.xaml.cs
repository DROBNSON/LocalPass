using Accessibility;
using Microsoft.EntityFrameworkCore;
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
using System.Security.Cryptography;


namespace LocalPass
{
    /// <summary>
    /// Interaction logic for Authentification.xaml
    /// </summary>
    public partial class Authentification : Page
    {

        public Authentification()
        {
            InitializeComponent();
  
        }


        public bool IsPasswordValid(string password)
        {
            // Check for null or empty string
            if (string.IsNullOrEmpty(password))
                return false;

            // Check for minimum length
            if (password.Length < 8)
                return false;

            // Check for at least one uppercase letter
            if (!password.Any(char.IsUpper))
                return false;

            // Check for at least one number
            if (!password.Any(char.IsDigit))
                return false;

            // Check for at least one symbol
            if (!password.Any(char.IsSymbol) && !password.Any(char.IsPunctuation))
                return false;

            return true;
        }



        public static string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(password);

            var hashedPassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedPassword); 
        }

 
        private void registerBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void createAccount_Click(object sender, RoutedEventArgs e)
        {
            var errorColor = Brushes.Red;
            var validColor = Brushes.Green;
            if (!string.IsNullOrEmpty(registrationUsername.Text) && !string.IsNullOrEmpty(registrationPassword.Text) && !string.IsNullOrEmpty(registrationPasswordConfirmation.Text))
            {
                if (registrationPassword.Text == registrationPasswordConfirmation.Text)
                {
                    if (IsPasswordValid(registrationPasswordConfirmation.Text) == true)
                    {
                        if (!PasswordCreatorServices.UserExists(registrationUsername.Text, HashPassword(registrationPasswordConfirmation.Text)))
                        {
                            registrationPassword.BorderBrush = validColor;
                            registrationPasswordConfirmation.BorderBrush = validColor;
                            registrationMessageLabel.Content = "User Created";


                            var HashedPwd = HashPassword(registrationPasswordConfirmation.Text);
                            var User = new User
                            {
                                Username = registrationUsername.Text,
                                UserPassword = HashedPwd,
                            };
                            PasswordCreatorServices.AddUser(User);
                            NavigationService.Navigate(new LandingPage());
                        }
                        else
                        {
                            registrationUsername.BorderBrush = errorColor;
                            registrationMessageLabel.Content = "*This Username already exists on your device*";
                        }
                    }
                    else
                    {
                        registrationPassword.BorderBrush = errorColor;
                        registrationPasswordConfirmation.BorderBrush = errorColor;
                        registrationMessageLabel.Content = "Password must be at least 8 characters and contain at least one symbol and capital letter";

                    }
                }
                else
                {
                    registrationPassword.BorderBrush = errorColor;
                    registrationPasswordConfirmation.BorderBrush = errorColor;
                    registrationMessageLabel.Content = "Passwords do not match";
                }
            }
            else
            {
                registrationUsername.BorderBrush = errorColor;
                registrationPassword.BorderBrush = errorColor;
                registrationPasswordConfirmation.BorderBrush = errorColor;
                registrationMessageLabel.Content = "*Please fill in all of the fields, and remmber, the username/password must not contain any spaces*";
            }
         
        }
    }
}
