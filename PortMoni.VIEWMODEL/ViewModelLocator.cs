using System.Linq;

namespace PortMoni.VIEWMODEL
{
    public class ViewModelLocator
    {
        private ShellViewModel _shellViewModel;
        public ShellViewModel ShellViewModel
        {
            get
            {
                if (_shellViewModel == null)
                {
                    _shellViewModel = new ShellViewModel();
                }

                return _shellViewModel;
            }
        }

        public MainViewModel MainViewModel
        {
            get
            {
                if (!ShellViewModel.ViewModels.Any(o => o is MainViewModel))
                {
                    ShellViewModel.ViewModels.Add(new MainViewModel());
                }

                return ShellViewModel.ViewModels.FirstOrDefault(o => o is MainViewModel) as MainViewModel;
            }
        }

        public LoginViewModel LoginViewModel
        {
            get
            {
                if (!ShellViewModel.ViewModels.Any(o => o is LoginViewModel))
                {
                    ShellViewModel.ViewModels.Add(new LoginViewModel());
                }

                return ShellViewModel.ViewModels.FirstOrDefault(o => o is LoginViewModel) as LoginViewModel;
            }
        }

        public RegisterUserViewModel RegisterUserViewModel
        {
            get
            {
                if (!ShellViewModel.ViewModels.Any(o => o is RegisterUserViewModel))
                {
                    ShellViewModel.ViewModels.Add(new RegisterUserViewModel());
                }

                return ShellViewModel.ViewModels.FirstOrDefault(o => o is RegisterUserViewModel) as RegisterUserViewModel;
            }
        }

        public NewOperationViewModel NewOperationViewModel
        {
            get
            {
                if (!ShellViewModel.ViewModels.Any(o => o is NewOperationViewModel))
                {
                    ShellViewModel.ViewModels.Add(new NewOperationViewModel());
                }

                return ShellViewModel.ViewModels.FirstOrDefault(o => o is NewOperationViewModel) as NewOperationViewModel;
            }
        }
    }
}
