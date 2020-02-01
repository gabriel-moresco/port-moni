using MahApps.Metro.Controls;
using PortMoni.VIEWMODEL;

namespace PortMoni.Views
{
    public partial class MainView : MetroWindow
    {
        MainViewModel myViewModel;

        public MainView()
        {
            InitializeComponent();

            myViewModel = new MainViewModel();

            this.DataContext = myViewModel;
        }
    }
}
