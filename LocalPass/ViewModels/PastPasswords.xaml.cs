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
using System.Xml.Serialization;

namespace LocalPass
{
    /// <summary>
    /// Interaction logic for PastPasswords.xaml
    /// </summary>
    public partial class PastPasswords : Page
    {
        private static bool AllItemsSelected;

        List<Password> passwordList;

        public PastPasswords()
        {
            InitializeComponent();

            this.Loaded += filterSelectionChange;

        }
        private void filterSelectionChange(object sender, RoutedEventArgs e)
        {

            InitializeComponent();
            ComboBoxItem selectedItem = (ComboBoxItem)filter.SelectedItem;
            string chosenItem;
            if (selectedItem == null)
            {
                chosenItem = string.Empty;
            }
            else
            {
                chosenItem = ((string)selectedItem.Content).ToLower();

            }

            switch (chosenItem)
            {
                case "most recent":
                    passwordList = new List<Password>();
                    foreach (var pwd in PasswordCreatorServices.GetAllPasswords())
                    {

                        passwordList.Add(new Password { _password = pwd._password, PasswordDate = pwd.passwordDate });
                    }
                    break;
                case "oldest":
                    passwordList = new List<Password>();
                    foreach (var pwd in PasswordCreatorServices.OldestToNewestPassword())
                    {

                        passwordList.Add(new Password { _password = pwd._password, PasswordDate = pwd.passwordDate });
                    }
                    break;
                case "largest to smallest":
                    passwordList = new List<Password>();
                    foreach (var pwd in PasswordCreatorServices.LargestToSmallest())
                    {

                        passwordList.Add(new Password { _password = pwd._password, PasswordDate = pwd.passwordDate });
                    }
                    break;
                case "smallest to largest":
                    passwordList = new List<Password>();
                    foreach (var pwd in PasswordCreatorServices.SmallestToLargest())
                    {

                        passwordList.Add(new Password { _password = pwd._password, PasswordDate = pwd.passwordDate });
                    }
                    break;
                default:
                    passwordList = new List<Password>();
                    foreach (var pwd in PasswordCreatorServices.GetAllPasswords())
                    {

                        passwordList.Add(new Password { _password = pwd._password, PasswordDate = pwd.passwordDate });
                    }
                    break;

            }
            // Set the collection as the ItemsSource for the ListBox
            pastPasswordsList.ItemsSource = passwordList;
        }

        private void deletePassword(object sender, RoutedEventArgs e)
        {
            foreach (var item in pastPasswordsList.SelectedItems)
            {
                var dataItem = item as Password;
                if (dataItem != null)
                {
                    var password = PasswordCreatorServices.GetPassword(dataItem._password);
                    if (password != null)
                    {
                        passwordList.Remove(dataItem);
                        PasswordCreatorServices.DeletePassword(password);
                    }
                }
            }
            pastPasswordsList.Items.Refresh();
        }
        
        private void selectAllItems(object sender, RoutedEventArgs e)
        {
            if (AllItemsSelected == false) 
            {
                pastPasswordsList.SelectAll();
                AllItemsSelected = true;
            }
            else
            {
                pastPasswordsList.UnselectAll();
                AllItemsSelected = false;
            }
        }


        private void previousPagePastPasswords(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new Homepage());
        }
    }
}
