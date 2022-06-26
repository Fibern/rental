using rental.Stores;
using rental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Commands
{
    public class MoreCommand<TViewModel> : CommandBase
        where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private CarStore _carStore;

        public MoreCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel, CarStore carStore)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _carStore = carStore;
        }

        public override void Execute(object parameter)
        {
            var ID = parameter;
            if(ID == null)
            {
                return;
            }
            string Id = ID.ToString();
            _navigationStore.SelectedRight = _createViewModel();
        }
    }
}
