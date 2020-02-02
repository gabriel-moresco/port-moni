using PortMoni.MVVM;
using System;
using System.Windows.Input;

namespace PortMoni.VIEWMODEL
{
    public class LoginViewModel : ObjectNotification
    {
        public ICommand OpenRegisterWindowCommand { get; set; }
        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            OpenRegisterWindowCommand = new DelegateCommand(OpenRegisterWindow);
            LoginCommand = new DelegateCommand(Login);
        }

        void Login(object parameter)
        {

        }

        private void OpenRegisterWindow(object parameter)
        {
            //TODO
        }
    }
}
