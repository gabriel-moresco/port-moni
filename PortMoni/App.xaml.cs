using System;
using System.Windows;
using PortMoni.UTIL;
using PortMoni.Views;

namespace PortMoni
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                new ShellView().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxCustom.Show("Ops!", "Fatal Error:\n", ex);
            }

            base.OnStartup(e);
        }
    }
}
