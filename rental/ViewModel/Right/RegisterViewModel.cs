using rental.Commands;
using rental.Stores;
using rental.ViewModel.Left;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace rental.ViewModel.Right
{
    class RegisterViewModel: BaseViewModel
    {
        public ICommand RegisterCommand { get; set; }

        private AuthenticationStore _authenticationStore;
        public string Login
        {
            get => _authenticationStore.Login;
            set => _authenticationStore.Login = value;
        }

        public RegisterViewModel(NavigationStore navigationStore)
        {
            _authenticationStore = new AuthenticationStore();
            RegisterCommand = new RegisterCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore), _authenticationStore);
        }
    }
}
