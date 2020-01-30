using MahApps.Metro.Controls;
using PortMoni.VIEWMODEL;

namespace PortMoni
{
    public partial class MainWindow : MetroWindow
    {
        MainWindowVM myViewModel;

        public MainWindow()
        {
            InitializeComponent();

            myViewModel = new MainWindowVM();

            this.DataContext = myViewModel;
        }
    }
}
