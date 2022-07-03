using rental.Commands;
using rental.Stores;
using System.Windows.Input;

namespace rental.ViewModel
{
    class RegisterViewModel : BaseViewModel
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
            RegisterCommand = new RegisterCommand(navigationStore, _authenticationStore);
        }
    }
}
