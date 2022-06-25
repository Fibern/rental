using rental.Commands;
using rental.Stores;
using rental.ViewModel.Right;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace rental.ViewModel.Left
{
    public class SideMenuViewModel: BaseViewModel
    {
        public ICommand Register { get; set; }
        public ICommand Login { get; set; }
        public SideMenuViewModel(NavigationStore navigationStore)
        {
            Register = new NavigateRightCommand<RegisterViewModel>(navigationStore, () => new RegisterViewModel(navigationStore));
            Login = new NavigateRightCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }
    }
}
