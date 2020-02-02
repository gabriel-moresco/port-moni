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
        string _userName; public string UserName { get { return _userName; } set { _userName = value; OnPropertyChanged(); } }

        public ICommand CreateNewUserCommand { get; set; }
        public ICommand BackToLoginViewCommand { get; set; }

        public RegisterUserViewModel()
        {
            CreateNewUserCommand = new DelegateCommand(CreateNewUser, CanCreateNewUser);
            BackToLoginViewCommand = new DelegateCommand(BackToLoginView);
        }

        void BackToLoginView(object parameter)
        {
        }

        bool CanCreateNewUser()
        {
            return !string.IsNullOrWhiteSpace(FullName) && !string.IsNullOrWhiteSpace(Email)
                && !string.IsNullOrWhiteSpace(UserName) && UserName.Length >= 6;
        }

        void CreateNewUser(object parameter)
        {
            try
            {
                PasswordBox passwordBox = parameter as PasswordBox;

                if (ValidatePassword(passwordBox.Password) && !CheckIfUserExist(UserName, Email))
                {
                    User newUser = new User(FullName, Email, UserName, passwordBox.Password);

                    DataBaseUserServices.InserNewUser(newUser);

                    MessageBoxCustom.Show("Usuário Criado!", "Usuário criado com sucesso.", MessageBoxCustom.Images.Checked, MessageBoxCustom.ButtonOptions.Ok);
                }
            }
            catch (Exception ex)
            {
                MessageBoxCustom.Show("Ops!", "Erro ao cadastrar novo usuário:\n", ex);
            }
        }

        bool CheckIfUserExist(string userName, string email)
        {
            User userByEmail = DataBaseUserServices.GetUserByEmail(email);
            User userByUserName = DataBaseUserServices.GetUserByUserName(userName);

            return userByEmail != null || userByUserName != null;
        }

        bool ValidatePassword(string password)
        {
            bool validation = true;

            if (password.Length < 6)
            {
                validation = false;
                MessageBoxCustom.Show("Ops!", "A senha deve conter no mínimo 6 caractéres.", MessageBoxCustom.Images.None, MessageBoxCustom.ButtonOptions.Ok);
            }

            return validation;
        }
    }
}
