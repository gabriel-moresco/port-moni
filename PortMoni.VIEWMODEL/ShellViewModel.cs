using PortMoni.MVVM;

namespace PortMoni.VIEWMODEL
{
    public class ShellViewModel : ObjectNotification
    {
        object _currentViewModel; public object CurrentViewModel { get { return _currentViewModel; } set { _currentViewModel = value; OnPropertyChanged(); } }

        public ShellViewModel ThisViewModel { get { return this; } }
        public MainViewModel MainViewModel { get; set; }
        public LoginViewModel LoginViewModel { get { return new LoginViewModel(GoToMainView, GoToRegisterView); } }
        public RegisterUserViewModel RegisterUserViewModel { get { return new RegisterUserViewModel(GoToLoginView, GoToMainView); } }
        public NewOperationViewModel NewOperationViewModel { get { return new NewOperationViewModel(GoToMainView, MainViewModel.SaveNewOperation); } }

        public ShellViewModel()
        {
            CurrentViewModel = LoginViewModel;
        }

        public void GoToMainView(string userName)
        {
            if (MainViewModel == default || (!string.IsNullOrWhiteSpace(userName) && MainViewModel.LoggedUserName != userName))
            {
                MainViewModel = new MainViewModel(userName, GoToNewOperationView);
            }

            CurrentViewModel = MainViewModel;
        }

        public void GoToRegisterView()
        {
            CurrentViewModel = RegisterUserViewModel;
        }

        public void GoToLoginView()
        {
            CurrentViewModel = LoginViewModel;
        }

        public void GoToNewOperationView()
        {
            CurrentViewModel = NewOperationViewModel;
        }
    }
}
