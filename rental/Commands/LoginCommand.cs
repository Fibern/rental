using rental.Stores;
using rental.ViewModel.Left;
using rental.ViewModel.Right;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Commands
{
    public class LoginCommand: CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public LoginCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.SelectedLeft = new UserMenuViewModel();
            _navigationStore.SelectedRight = new UserMainViewModel();
        }

    }
}
