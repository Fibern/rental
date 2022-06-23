﻿using rental.Stores;
using rental.ViewModel;
using rental.ViewModel.Left;
using rental.ViewModel.Right;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Commands
{
    public class NavigateRightCommand<TViewModel> : CommandBase
        where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigateRightCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }


        public override void Execute(object parameter)
        {
            _navigationStore.SelectedRight = _createViewModel();
        }
    }
}