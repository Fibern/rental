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
        private readonly UserStore _userStore;
        private readonly Func<TViewModel> _createViewModel;
        private CarStore _carStore;

        public MoreCommand(NavigationStore navigationStore, UserStore userStore, CarStore carStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _carStore = carStore;
            _userStore = userStore;
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
