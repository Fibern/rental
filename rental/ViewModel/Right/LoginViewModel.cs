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
    public class LoginViewModel: BaseViewModel
    {
        public ICommand LoginCommand { get; }
        public LoginViewModel(NavigationStore navigationStore)
        {
            LoginCommand = new NavigateLeftCommand<UserMainViewModel>(navigationStore, () => new UserMainViewModel());
            LoginCommand = new NavigateRightCommand<UserMainViewModel>(navigationStore, () => new UserMainViewModel());
        }
    }
}
