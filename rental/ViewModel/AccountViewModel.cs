using rental.Commands;
using rental.Stores;
using System.Windows.Input;

namespace rental.ViewModel
{
    public class AccountViewModel : BaseViewModel
    {
        public ICommand AddBalanceCommand { get; set; }
        public string Username { get => "Login: " + _userStore.User.Username; }
        public string Balance { get => "Saldo: " + _userStore.User.Balance.ToString(); }
        private UserStore _userStore;
        private NavigationStore _navigationStore;
        public AccountViewModel(NavigationStore navigationStore, UserStore userStore)
        {
            _navigationStore = navigationStore;
            _userStore = userStore;
            AddBalanceCommand = new NavigateRightCommand<AddBalanceViewModel>(_navigationStore, () => new AddBalanceViewModel(_userStore, _navigationStore));
        }
    }
}
