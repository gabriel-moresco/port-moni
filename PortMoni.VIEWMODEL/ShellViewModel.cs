using PortMoni.MVVM;
using System.Collections.ObjectModel;
using System.Linq;

namespace PortMoni.VIEWMODEL
{
    public class ShellViewModel : ObjectNotification
    {
        ObservableCollection<object> _viewModels; public ObservableCollection<object> ViewModels { get { return _viewModels; } set { _viewModels = value; OnPropertyChanged(); } }
        object _currentViewModel; public object CurrentViewModel { get { return _currentViewModel; } set { _currentViewModel = value; OnPropertyChanged(); } }

        public ShellViewModel()
        {
            ViewModels = new ObservableCollection<object>();
            ViewModels.Add(new LoginViewModel());
            CurrentViewModel = ViewModels.FirstOrDefault(o => o is LoginViewModel);

            ViewModels.Add(new MainViewModel());
            CurrentViewModel = ViewModels.FirstOrDefault(o => o is MainViewModel);

            ViewModels.Add(new NewOperationViewModel());
            CurrentViewModel = ViewModels.FirstOrDefault(o => o is NewOperationViewModel);
        }
    }
}
