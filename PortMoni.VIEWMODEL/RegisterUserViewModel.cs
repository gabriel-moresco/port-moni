using PortMoni.MODEL;
using PortMoni.MVVM;
using PortMoni.SERVICES;
using PortMoni.UTIL;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace PortMoni.VIEWMODEL
{
    public class RegisterUserViewModel : ObjectNotification
    {
        string _fullName; public string FullName { get { return _fullName; } set { _fullName = value; OnPropertyChanged(); } }
        string _email; public string Email { get { return _email; } set { _email = value; OnPropertyChanged(); } }
        string _userName; public string UserName { get { return _userName; } set { _userName = value.ToLowerInvariant(); OnPropertyChanged(); } }
        bool _createNewUserIsEnabled; public bool CreateNewUserIsEnabled { get { return _createNewUserIsEnabled; } set { _createNewUserIsEnabled = value; OnPropertyChanged(); } }

        public ICommand CreateNewUserCommand => new DelegateCommand(CreateNewUser);
        public ICommand BackToLoginViewCommand => new DelegateCommand(BackToLoginView);
        public ICommand TextChangedCommand => new DelegateCommand(CanCreateNewUser);

        void BackToLoginView(object parameter)
        {
            //TODO IMPLEMENTAR
        }

        void SwitchToMainView()
        {
            //TODO IMPLEMENTAR
        }

        void CanCreateNewUser(object parameter)
        {
            string password = (parameter as PasswordBox).Password;

            CreateNewUserIsEnabled = !string.IsNullOrWhiteSpace(FullName) && !string.IsNullOrWhiteSpace(Email)
                && !string.IsNullOrWhiteSpace(UserName) && UserName.Length >= 6 && password.Length >= 6;
        }

        void CreateNewUser(object parameter)
        {
            try
            {
                PasswordBox passwordBox = parameter as PasswordBox;

                if (ValidPassword(passwordBox.Password))
                {
                    if (!CheckIfUserNameExist(UserName))
                    {
                        if (!CheckIfEmailExist(Email))
                        {
                            User newUser = new User(FullName, Email, UserName, passwordBox.Password, DataBaseWalletServices.GetLasWalletId(UserName));

                            DataBaseUserServices.InserNewUser(newUser);

                            MessageBoxCustom.Show("Usuário Criado!", "Usuário criado com sucesso.", MessageBoxCustom.Images.Checked, MessageBoxCustom.ButtonOptions.Ok);

                            SwitchToMainView();
                        }
                        else
                        {
                            throw new Exception("E-mail já está sendo utilizado.");
                        }
                    }
                    else
                    {
                        throw new Exception("Úsuário já existe.");
                    }
                }
                else
                {
                    throw new Exception("A senha deve conter no mínimo 6 caractéres.");
                }
            }
            catch (Exception ex)
            {
                MessageBoxCustom.Show("Ops!", "Erro ao cadastrar novo usuário:\n" + ex.Message, MessageBoxCustom.Images.Info, MessageBoxCustom.ButtonOptions.Ok);
            }
        }

        bool CheckIfUserNameExist(string userName)
        {
            return DataBaseUserServices.GetUserByUserName(userName) != null;
        }

        bool CheckIfEmailExist(string email)
        {
            return DataBaseUserServices.GetUserByEmail(email) != null;
        }

        bool ValidPassword(string password)
        {
            bool validation = true;

            if (password.Length < 6)
            {
                validation = false;
            }

            return validation;
        }
    }
}
