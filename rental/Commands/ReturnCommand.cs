using rental.Model;
using rental.Stores;
using rental.ViewModel;
using System;

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
            Rent rent = ResourcesStore.GetRent(_carStore.Car.Id);
            int difference = (int)Math.Floor((rent.Expire - DateTime.Now).TotalDays);
            ResourcesStore.ChangeBalance(_userStore.User.Id ,_userStore.User.Balance + difference * _carStore.Car.Price);
            ResourcesStore.ReturnCar(_carStore.Car.Id);
            _navigationStore.SelectedRight = new CarDetailsViewModel(_navigationStore, _userStore, _carStore);
            _userStore.User.Balance += difference * _carStore.Car.Price;
        }
    }
}
