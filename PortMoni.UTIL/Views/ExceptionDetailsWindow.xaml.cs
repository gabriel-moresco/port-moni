using System.Windows;
using System.Windows.Input;

namespace PortMoni.UTIL.Views
{
    public partial class ExceptionDetailsWindow : Window
    {
        public ExceptionDetailsWindow(string stackTrace)
        {
            InitializeComponent();

            txt_Content.Text = stackTrace;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
