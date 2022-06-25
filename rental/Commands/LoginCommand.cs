﻿using rental.Services;
using rental.Stores;
using rental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Commands
{
    public class LoginCommand<TViewModelLeft, TViewModelRight> : CommandBase
        where TViewModelLeft : BaseViewModel
        where TViewModelRight : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModelLeft> _leftViewModel;
        private readonly Func<TViewModelRight> _rightViewModel;
        private AuthenticationStore _authenticationStore;

        public LoginCommand(NavigationStore navigationStore, Func<TViewModelLeft> left, Func<TViewModelRight> right, AuthenticationStore authenticationStore)
        {
            _navigationStore = navigationStore;
            _leftViewModel = left;
            _rightViewModel = right;
            _authenticationStore = authenticationStore;

        }

        public override void Execute(object parameter)
        {
            
            _navigationStore.SelectedLeft = _leftViewModel();
            _navigationStore.SelectedRight = _rightViewModel();
        }

    }
}
