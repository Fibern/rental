using rental.Stores;
using rental.ViewModel;
using System;

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
