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
    public class LoginViewModel: BaseViewModel
    {
        public ICommand LoginCommand { get; set; }

        private AuthenticationStore _authenticationStore;
        public string Password 
        { 
            get => _authenticationStore.Password;
            set => _authenticationStore.Password = value; 
        }
        public string Login 
        {
            get => _authenticationStore.Login;
            set => _authenticationStore.Login = value;
        }

        public LoginViewModel(NavigationStore navigationStore)
        {
            _authenticationStore = new AuthenticationStore();
            LoginCommand = new LoginCommand<UserMenuViewModel, UserMainViewModel>(navigationStore, () => new UserMenuViewModel(), () => new UserMainViewModel(), _authenticationStore);
        }

    }
}
