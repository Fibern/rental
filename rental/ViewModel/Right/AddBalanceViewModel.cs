using rental.Commands;
using rental.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace rental.ViewModel.Right
{
    class AddBalanceViewModel : BaseViewModel
    {
        private UserStore _userStore;
        private NavigationStore _navigationStore;
        private string _balance;
        public string Balance 
        { 
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
                AddBalanceCommand = new AddBalanceCommand(_userStore, _navigationStore, Balance);
            }
        }
        private ICommand _addBalanceCommand;
        public ICommand AddBalanceCommand 
        { 
            get => _addBalanceCommand;
            set
            {
                _addBalanceCommand = value;
                OnPropertyChanged(nameof(AddBalanceCommand));
            }
        }
        public AddBalanceViewModel(UserStore userStore, NavigationStore navigationStore)
        {
            AddBalanceCommand = new AddBalanceCommand(_userStore, _navigationStore, Balance);
            _userStore = userStore;
            _navigationStore = navigationStore;
        }
    }
}
