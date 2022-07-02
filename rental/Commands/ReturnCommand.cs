using rental.Stores;
using rental.ViewModel.Right;

namespace rental.Commands
{
    public class ReturnCommand: CommandBase
        {
        private CarStore _carStore;
        private NavigationStore _navigationStore;
        private UserStore _userStore;
        public ReturnCommand(CarStore carstore, NavigationStore navigationStore, UserStore userStore)
        {
            _carStore = carstore;
            _navigationStore = navigationStore;
            _userStore = userStore;
        }
        public override void Execute(object parameter)
        {
            ResourcesStore.ReturnCar(_carStore.Car.Id);
            _navigationStore.SelectedRight = new CarDetailsViewModel(_navigationStore, _userStore, _carStore);
        }
    }
}
