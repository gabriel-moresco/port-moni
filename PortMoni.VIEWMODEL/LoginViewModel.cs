using PortMoni.MODEL;
using PortMoni.MVVM;
using PortMoni.SERVICES;
using PortMoni.UTIL;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;

namespace PortMoni.VIEWMODEL
{
    public class LoginViewModel : ObjectNotification
    {
        bool _rememberInThisComputerChecked; public bool RememberInThisComputerChecked { get { return _rememberInThisComputerChecked; } set { _rememberInThisComputerChecked = value; OnPropertyChanged(); } }
        bool _loginEnabled; public bool LoginEnabled { get { return _loginEnabled; } set { _loginEnabled = value; OnPropertyChanged(); } }
        string _userName; public string UserName { get { return _userName; } set { _userName = value.ToLowerInvariant(); OnPropertyChanged(); } }

        public ICommand GoToRegisterViewCommand => new DelegateCommand(GoToRegisterView);
        public ICommand LoginCommand => new DelegateCommand(Login);
        public ICommand TextChangedCommand => new DelegateCommand(CheckIfLoginCanBeEnabled);

        Action<string> GoToMainViewAction;
        Action GoToRegisterViewAction;

        public LoginViewModel(Action<string> goToMainViewAction, Action goToRegisterViewAction)
        {
            GoToMainViewAction = goToMainViewAction;
            GoToRegisterViewAction = goToRegisterViewAction;

            User cacheUser = GetCredentialsOnCache();

            if (cacheUser != null)
            {
                GoToMainView(cacheUser.UserName);
            }
        }

        void Login(object parameter)
        {
            try
            {
                string password = (parameter as PasswordBox).Password;

                User user = GetUser(UserName);

                if (user != null)
                {
                    if (user.Password == password)
                    {
                        if (RememberInThisComputerChecked)
                        {
                            SaveCredentialsOnCache(user);
                        }

                        GoToMainView(user.UserName);
                    }
                    else
                    {
                        throw new Exception("Usuário ou senha incorretos.");
                    }
                }
                else
                {
                    throw new Exception("Usuário não existe.");
                }
            }
            catch (Exception ex)
            {
                MessageBoxCustom.Show("Ops!", "Erro ao logar:\n" + ex.Message, MessageBoxCustom.Images.Info, MessageBoxCustom.ButtonOptions.Ok);
            }
        }

        User GetCredentialsOnCache()
        {
            User cacheUser = null;

            try
            {
                if (File.Exists(GetTempCredentialsXmlFilePath()))
                {
                    cacheUser = Util.DeserializeXml<User>(GetTempCredentialsXmlFilePath());
                }
            }
            catch (Exception) { }

            return cacheUser;
        }

        void SaveCredentialsOnCache(User user)
        {
            try
            {
                string xmlUser = Util.SerializeXml(user);

                File.WriteAllText(GetTempCredentialsXmlFilePath(), xmlUser);
            }
            catch (Exception) { }
        }

        string GetTempCredentialsXmlFilePath()
        {
            return Path.Combine(Path.GetTempPath(), "portmonicachecred.xml");
        }

        void GoToMainView(string userName)
        {
            GoToMainViewAction(userName);
        }

        User GetUser(string userName)
        {
            return DataBaseUserServices.GetUserByUserName(userName);
        }

        void GoToRegisterView(object parameter)
        {
            GoToRegisterViewAction();
        }

        void CheckIfLoginCanBeEnabled(object parameter)
        {
            LoginEnabled = !string.IsNullOrEmpty(UserName) && (parameter as PasswordBox).Password.Length > 6;
        }
    }
}
