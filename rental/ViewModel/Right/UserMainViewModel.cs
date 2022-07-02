using Caliburn.Micro;
using rental.Commands;
using rental.DataTypes;
using rental.Stores;
using System.Windows.Input;

namespace rental.ViewModel.Right
{
    public class UserMainViewModel: BaseViewModel
    {
        public ICommand MoreCommand { get; set; }
        public BindableCollection<Car> cars { get; set; }
        private CarStore _carStore;
        public UserMainViewModel(NavigationStore navigationStore, UserStore userStore)
        {
            _carStore = new CarStore();
            cars = ResourcesStore.GetAvaliableCars();
            MoreCommand = new MoreCommand<CarDetailsViewModel>(navigationStore, userStore, _carStore, 
                () => new CarDetailsViewModel(navigationStore, userStore, _carStore));
        }
    }
}
