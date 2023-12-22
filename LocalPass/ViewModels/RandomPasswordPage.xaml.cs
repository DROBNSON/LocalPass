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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class RandomPasswordPage : Page
    {
        public RandomPasswordPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clipboardImage.Source = new BitmapImage(new Uri("../img/copy-icon.png", UriKind.Relative));

            RandomPasswordCreator randomPassowrd = new RandomPasswordCreator();


            randomPassowrd.CreatePassword();
            rndPwdTB.Text = randomPassowrd.DisplayedPassword.ToString(); ;

            if (!customPasswordPage.IsNullOrEmpty(rndPwdTB.Text))
            {
                this.copyImageToClipBoard.Visibility = Visibility.Visible;
            }

          

        }

        private void CopyToClipboard(object sender, RoutedEventArgs e)
        {

            clipboardImage.Source = new BitmapImage(new Uri("../img/copied-icon.png",UriKind.Relative));
            Clipboard.SetText(rndPwdTB.Text);


        }

        private void PreviousPage(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Homepage());
           
        }
    }
}
