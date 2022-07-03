using rental.DataTypes;
using rental.Stores;
using rental.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Text;

namespace rental.Commands
{
    public class RegisterCommand<TViewModel> : CommandBase
        where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _viewModel;
        private readonly AuthenticationStore _authenticationStore;
        public RegisterCommand(NavigationStore navigationStore, Func<TViewModel> viewModel, AuthenticationStore authenticationStore)
        {
            _navigationStore = navigationStore;
            _viewModel = viewModel;
            _authenticationStore = authenticationStore;
        }
        public override bool CanExecute(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var sha1 = new SHA1CryptoServiceProvider();
            var hash = Convert.ToHexString(sha1.ComputeHash(Encoding.UTF8.GetBytes(passwordBox.Password)));
            
            _authenticationStore.Password = hash;
            List<User> users = ResourcesStore.Users;
            foreach (User u in users)
            {
                if (u.Username == _authenticationStore.Login)
                {
                    MessageBox.Show("Użytkownik o podanym loginie już istnieje");
                    return false;
                }
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            if (_authenticationStore.Login == "" || _authenticationStore.Password == "")
            {
                MessageBox.Show("Login i hasło nie mogą pozostać puste");
                return;
            }
            List<User> users = ResourcesStore.Users;
            users.Add(new User(users.Count, _authenticationStore.Login, _authenticationStore.Password, 0));
            ResourcesStore.Users = users;
            _navigationStore.SelectedRight = _viewModel();
        }
    }
}
