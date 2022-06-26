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
    public class UserMenuViewModel : BaseViewModel
    {
        public ICommand LogoutCommand { get; set; }
        public ICommand RentCommand { get; set; }
        public ICommand RentedCommand { get; set; }
        public ICommand ProfileCommand { get; set; }
        public string Username { get; set; }
        public UserStore userstore{ get; set; }
        public UserMenuViewModel(NavigationStore navigationStore, UserStore userStore)
        {
            userstore = userStore;
            Username = userStore.User.Username;
            LogoutCommand = new LogoutCommand<SideMenuViewModel, LoginViewModel>(navigationStore, () => new SideMenuViewModel(navigationStore), () => new LoginViewModel(navigationStore));
            ProfileCommand = new NavigateRightCommand<AccountViewModel>(navigationStore, () => new AccountViewModel());
            RentedCommand = new NavigateRightCommand<RentedViewModel>(navigationStore, () => new RentedViewModel());
            RentCommand = new NavigateRightCommand<UserMainViewModel>(navigationStore, () => new UserMainViewModel());
        }
    }
}
