﻿using rental.Commands;
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
        public string Username { get => _userstore.User.Username; }
        private UserStore _userstore;
        private CarStore _carStore;
        public UserMenuViewModel(NavigationStore navigationStore, UserStore userStore)
        {
            _userstore = userStore;
            _carStore = new CarStore();
            LogoutCommand = new LogoutCommand<SideMenuViewModel, LoginViewModel>(navigationStore, 
                () => new SideMenuViewModel(navigationStore), () => new LoginViewModel(navigationStore));
            ProfileCommand = new NavigateRightCommand<AccountViewModel>(navigationStore,
                () => new AccountViewModel(navigationStore, userStore));
            RentedCommand = new MoreCommand<CarDetailsViewModel>(navigationStore,
                () => new CarDetailsViewModel(navigationStore, userStore, 0));
            RentCommand = new NavigateRightCommand<UserMainViewModel>(navigationStore,
                () => new UserMainViewModel(navigationStore, userStore));
        }
    }
}
