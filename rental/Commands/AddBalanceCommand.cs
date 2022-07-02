using rental.Stores;
using rental.ViewModel.Right;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Commands
{
    internal class AddBalanceCommand : CommandBase
    {
        private readonly UserStore _userStore;
        private readonly NavigationStore _navigationStore;
        private readonly string _balance;
        public AddBalanceCommand(UserStore userStore, NavigationStore navigationStore, string balance)
        {
            _userStore = userStore;
            _navigationStore = navigationStore;
            _balance = balance;
        }

        public override bool CanExecute(object parameter)
        {
            decimal _;
            if (_balance is null) return false;
            if (!Decimal.TryParse(_balance, out _)) return false;
            if (_ <= 0) return false;

            string tmp = String.Format("{0:0.00}", _);
            if (_ - Decimal.Parse(tmp) != 0) return false;

            return true;
        }
        public override void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            decimal _ = Decimal.Parse(_balance);
            _userStore.User.Balance += _;
            ResourcesStore.ChangeBalance(_userStore.User.Id, _userStore.User.Balance);
            _navigationStore.SelectedRight = new AccountViewModel(_navigationStore, _userStore);

        }
    }
}
