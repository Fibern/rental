﻿using rental.Commands;
using rental.Stores;
using System.Windows.Input;

namespace rental.ViewModel
{
    public class UserMenuViewModel : BaseViewModel
    {
        public ICommand LogoutCommand { get; set; }
        public ICommand RentCommand { get; set; }
        public ICommand RentedCommand { get; set; }
        public ICommand ProfileCommand { get; set; }
        public string Username { get => _userstore.User.Username; }
        private UserStore _userstore;
        private CarStore _carStore;
        public UserMenuViewModel(NavigationStore navigationStore, UserStore userStore)
        {
            _userstore = userStore;
            _carStore = new CarStore();
            LogoutCommand = new LogoutCommand<SideMenuViewModel, LoginViewModel>(navigationStore,
                () => new SideMenuViewModel(navigationStore), () => new LoginViewModel(navigationStore));
            ProfileCommand = new NavigateCommand<AccountViewModel>(navigationStore,
                () => new AccountViewModel(navigationStore, userStore), false);
            RentedCommand = new MoreCommand(navigationStore, userStore, _carStore);
            RentCommand = new NavigateCommand<UserMainViewModel>(navigationStore,
                () => new UserMainViewModel(navigationStore, userStore), false);
        }
    }
}
