using rental.Stores;
using rental.ViewModel;
using System;

namespace rental.Commands
{
    public class RentCommand : CommandBase
    {
        private readonly UserStore _userStore;
        private readonly CarStore _carStore;
        private readonly NavigationStore _navigationStore;
        public RentCommand(UserStore userStore, CarStore carStore, NavigationStore navigationStore)
        {
            _userStore = userStore;
            _carStore = carStore;
            _navigationStore = navigationStore;
        }
        public override bool CanExecute(object parameter)
        {
            if(parameter is null)
                return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            if (ResourcesStore.HaveRent(_userStore.User.Id))
            {
                System.Windows.MessageBox.Show("Możesz wypożyczać tylko jeden samochód w danym momencie");
                return;
            }
            var str = parameter as string;
            DateTime date = Convert.ToDateTime(str, new System.Globalization.CultureInfo("en-US"));
            date = date.AddDays(1);
            date = date.AddSeconds(-1);
            int difference = (int)Math.Ceiling((date - DateTime.Now).TotalDays);
            if(difference * _carStore.Car.Price > _userStore.User.Balance)
            {
                System.Windows.MessageBox.Show("Niewystarczająca ilość środków na koncie");
                return;
            }

            ResourcesStore.RentCar(_carStore.Car.Id, _userStore.User.Id, date);
            ResourcesStore.ChangeBalance(_userStore.User.Id, _userStore.User.Balance - difference * _carStore.Car.Price);
            _userStore.User.Balance -= difference * _carStore.Car.Price;
            _carStore.Car.IsRented = true;
            _navigationStore.SelectedRight = new CarDetailsViewModel(_navigationStore, _userStore, _carStore);
        }
    }
}
