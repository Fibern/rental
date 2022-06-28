using rental.Commands;
using rental.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace rental.ViewModel.Right
{
    public class CarDetailsViewModel : BaseViewModel
    {
        public String Name { get; set; }
        
        private string _date;
        public string Date { 
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
                RentCommand = new RentCommand(_userStore, _carStore, _naviagationStore);
                OnPropertyChanged(nameof(RentCommand));
            } 
        }
        public Visibility IsVisible { get; set; }
        public Visibility IsNotVisible { get; set; }
        public Visibility Visibility { get; set; }
        public Visibility Nvisibility { get; set; }

        private NavigationStore _naviagationStore;
        private UserStore _userStore;
        private CarStore _carStore;
        public string StartDate { get => DateTime.Now.AddDays(1).ToString("yyyy.MM.dd"); }
        public ICommand RentCommand { get; set; }
        public ICommand ReturnCommand { get; set; }

        public CarDetailsViewModel(NavigationStore naviagationStore, UserStore userStore, CarStore carStore)
        {
            _naviagationStore = naviagationStore;
            _userStore = userStore;
            _carStore = carStore;

            RentCommand = new RentCommand(_userStore, _carStore, _naviagationStore);
            ReturnCommand = new ReturnCommand(_carStore, _naviagationStore, _userStore);

            if (carStore.Car is null)
            {
                IsNotVisible = Visibility.Visible;
                IsVisible = Visibility.Collapsed;
                Visibility = Visibility.Collapsed;
                Nvisibility = Visibility.Collapsed;
            }
            else
            {
                Name = carStore.Car.Name;
                if (ResourcesStore.HaveRent(_userStore.User.Id) || !_carStore.Car.IsRented)
                {
                    IsVisible = Visibility.Visible;
                    IsNotVisible = Visibility.Collapsed;
                }
                else
                {
                    IsVisible = Visibility.Collapsed;
                    IsNotVisible = Visibility.Visible;
                }

                if (carStore.Car.IsRented)
                {
                    Visibility = Visibility.Collapsed;
                    Nvisibility = Visibility.Visible;
                }
                else
                {
                    Visibility = Visibility.Visible;
                    Nvisibility = Visibility.Collapsed;
                }
            }
        }
    }
}
