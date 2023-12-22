using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LocalPass
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                // Log or display the exception details
                Exception exception = (Exception)args.ExceptionObject;
                MessageBox.Show($"Unhandled exception: {exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            };

            // Your existing startup code
            // ...
        }
    }
}
