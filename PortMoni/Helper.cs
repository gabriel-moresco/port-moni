using PortMoni.Views;

namespace PortMoni
{
    public class Helper
    {
        static LoadingView _loadingView;

        public static void OpenLoadingView()
        {
            _loadingView = new LoadingView();
            _loadingView.Show();
        }

        public static void CloseLoadingView()
        {
            _loadingView.Hide();
        }
    }
}
