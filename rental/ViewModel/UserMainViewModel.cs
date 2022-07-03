using Caliburn.Micro;
using rental.Commands;
using rental.Model;
using rental.Stores;
using System.Windows.Input;

namespace rental.ViewModel
{
    public class UserMainViewModel : BaseViewModel
    {
        public ICommand MoreCommand { get; set; }
        public BindableCollection<Car> cars { get; set; }
        private CarStore _carStore;
        public UserMainViewModel(NavigationStore navigationStore, UserStore userStore)
        {
            _carStore = new CarStore();
            cars = ResourcesStore.GetAvaliableCars();
            MoreCommand = new MoreCommand(navigationStore, userStore, _carStore);
        }
    }
}
