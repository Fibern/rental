using rental.Model;
using rental.Stores;
using rental.ViewModel;
using System;
using System.Collections.Generic;

namespace rental.Commands
{
    public class MoreCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly UserStore _userStore;
        private CarStore _carStore;

        public MoreCommand(NavigationStore navigationStore, UserStore userStore, CarStore carStore)
        {
            _navigationStore = navigationStore;
            _carStore = carStore;
            _userStore = userStore;
        }

        public override void Execute(object parameter)
        {

            var ID = parameter;
            if(ID == null)
            {
                List<Rent> rents = ResourcesStore.Rents;
                foreach(var rent in rents)
                {
                    if (_userStore.User.Id == rent.UserId)
                    {
                        ID = rent.CarId;
                        break;
                    }
                }
            }

            if (ID != null)
            {
                ID = ID.ToString();
                List<Car> cars = ResourcesStore.Cars;
                foreach(Car car in cars)
                {
                    if(car.Id.ToString() == ID.ToString())
                    { 
                        _carStore.Car = car;
                        break;
                    }
                }
            }
            else
            {
                _carStore.Car = null;
            }
            _navigationStore.SelectedRight = new CarDetailsViewModel(_navigationStore, _userStore, _carStore);
        }
    }
}
