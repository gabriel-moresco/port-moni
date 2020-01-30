using System;
using System.Windows;

namespace PortMoni
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                new MainWindow().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal Error: " + ex.Message, "Ops!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            base.OnStartup(e);
        }
    }
}
