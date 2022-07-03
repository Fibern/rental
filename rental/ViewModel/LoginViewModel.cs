using rental.Commands;
using rental.Stores;
using System.Windows.Input;

namespace rental.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }

        private AuthenticationStore _authenticationStore;
        public string Login
        {
            get => _authenticationStore.Login;
            set => _authenticationStore.Login = value;
        }

        public LoginViewModel(NavigationStore navigationStore)
        {
            _authenticationStore = new AuthenticationStore();
            UserStore userStore = new UserStore();
            LoginCommand = new LoginCommand<UserMenuViewModel, UserMainViewModel>(navigationStore, userStore,
                () => new UserMenuViewModel(navigationStore, userStore),
                () => new UserMainViewModel(navigationStore, userStore),
                _authenticationStore);
        }

    }
}
