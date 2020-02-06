using MahApps.Metro.Controls;
using PortMoni.VIEWMODEL;

namespace PortMoni.Views
{
    public partial class ShellView : MetroWindow
    {
        public ShellView()
        {
            InitializeComponent();

            (this.DataContext as ShellViewModel).OpenLoadingViewAction = Helper.OpenLoadingView;
            (this.DataContext as ShellViewModel).CloseLoadingViewAction = Helper.CloseLoadingView;
        }
    }
}
