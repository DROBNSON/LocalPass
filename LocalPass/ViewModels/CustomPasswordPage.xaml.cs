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
using LocalPass.Controls;

namespace LocalPass
{
    /// <summary>
    /// Interaction logic for customPasswordPage.xaml
    /// </summary>
    public partial class customPasswordPage : Page
    {
         public static int PasswordLength;
         new public static string Name;
         public static string Keyword;
        public static string Code;
      
        public customPasswordPage()
        {
            InitializeComponent();
        }

        public static bool IsNullOrEmpty(string text)
        {
            return text == null || !text.Any() || text.Any(c => c == '\u0000' || c == ' ');
        }

        private void PreviousPage(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Homepage());
            
        }

        private void CreatePwd(object sender, RoutedEventArgs e)
        {
            int passwordLen = pwdLength.Value ?? 0;

           if(passwordLen != 0 || passwordLen > 0)
            {
                PasswordLength = passwordLen;
                Name = ctmPwdName.Text;
                Keyword = ctmPwdKeyword.Text;
                Code = ctmPwdCode.Text;

                CustomPasswordCreator customPassword = new CustomPasswordCreator(Name, PasswordLength, Keyword, Code);
                customPassword.CreateCustomPassword();
           

            }
            else
            {
                ctmPwdErrorLabel.Content = "*Password length cannot be null or zero*";
            }

           //Displays the custom password in the CustomPasswordPage password Textblock
            ctmPwd.Text = CustomPasswordCreator.DisplayedPassword;


            if (!IsNullOrEmpty(ctmPwd.Text))
            {
                copyImageToClipBoard.Visibility = Visibility.Visible;
            }

        }

        private void ClearAll(object sender, RoutedEventArgs e)
        {
            pwdLength.Value = 0;
            ctmPwdName.Text = null;
            ctmPwdKeyword.Text = null;
            ctmPwdCode.Text = null;
            ctmPwd.Text = null; 

        }

        private void CopyToClipboard(object sender, RoutedEventArgs e) 
        {
            clipboardImage.Source = new BitmapImage(new Uri("../img/copied-icon.png", UriKind.Relative));
            Clipboard.SetText(ctmPwd.Text);
            
        }
    }
}
