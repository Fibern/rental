using rental.Stores;

namespace rental.ViewModel.Right
{
    public class AccountViewModel : BaseViewModel
    {
        public string Username { get => "Login: " + _userStore.User.Username; }
        public string Balance { get => "Saldo: " + _userStore.User.Balance.ToString(); }
        private UserStore _userStore;
        private NavigationStore _navigationStore;
        public AccountViewModel(NavigationStore navigationStore, UserStore userStore)
        {
            _navigationStore = navigationStore;
            _userStore = userStore;
        }
    }
}
