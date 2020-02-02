using PortMoni.MVVM;
using System.Windows.Input;

namespace PortMoni.VIEWMODEL
{
    public class LoginViewModel : ObjectNotification
    {
        public ICommand OpenRegisterWindowCommand { get; set; }

        public LoginViewModel()
        {
            OpenRegisterWindowCommand = new DelegateCommand(OpenRegisterWindow);
        }

        private void OpenRegisterWindow(object parameter)
        {
            
        }
    }
}
