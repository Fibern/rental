using rental.Stores;
using rental.ViewModel;
using System;

namespace rental.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly bool _vm;

        public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel, bool vm)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _vm = vm;
        }


        public override void Execute(object parameter)
        {
            if (_vm)
                _navigationStore.SelectedLeft = _createViewModel();
            else
                _navigationStore.SelectedRight = _createViewModel();
        }
    }
}
