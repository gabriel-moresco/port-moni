using System;
using System.Windows;
using PortMoni.UTIL;

namespace PortMoni
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                new Views.ShellView().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxCustom.Show("Ops!", "Fatal Error:\n" + ex.Message, ex);
            }

            base.OnStartup(e);
        }
    }
}
