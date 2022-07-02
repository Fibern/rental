using rental.Commands;
using rental.Stores;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace rental.ViewModel.Right
{
    public class CarDetailsViewModel : BaseViewModel
    {

        private NavigationStore _naviagationStore;
        private UserStore _userStore;
        private CarStore _carStore;

        public string Name { get => _carStore.Car.Name; }
        public string Price { get => _carStore.Car.Price.ToString() + " zł"; }
        public string Balance { get => _userStore.User.Balance.ToString() + " zł"; }
        public string Brand { get=> _carStore.Car.Brand; }
        public string Model { get => _carStore.Car.Model; }
        public string Year { get => _carStore.Car.Year.ToString(); }
        public string EngineCapacity { get => _carStore.Car.EngineCapacity.ToString() + " cm3"; }
        public string FuelType { get => _carStore.Car.FuelType; }
        public string Power { get => _carStore.Car.HorsePower.ToString() + " KM"; }
        public string FuelUsage { get => _carStore.Car.FuelUsage.ToString() + " l"; }
        public string Transmission { get => _carStore.Car.Transmission; }
        public string Drive { get => _carStore.Car.Drive; }
        public string BodyStyle { get => _carStore.Car.BodyStyle; }
        public string Seats { get => _carStore.Car.Seats.ToString(); }
        public string Colour { get=> _carStore.Car.Colour; }
        public string StartDate { get => DateTime.Now.AddDays(1).ToString("yyyy.MM.dd"); }
        
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
        public ICommand RentCommand { get; set; }
        public ICommand ReturnCommand { get; set; }
        public BitmapImage Image { get => new BitmapImage(new Uri(@"..\..\Resources\Images\" + _carStore.Car.Image, UriKind.Relative)); } 

        public CarDetailsViewModel(NavigationStore naviagationStore, UserStore userStore, CarStore carStore)
        {
            _naviagationStore = naviagationStore;
            _userStore = userStore;
            _carStore = carStore;

            RentCommand = new RentCommand(_userStore, _carStore, _naviagationStore);
            ReturnCommand = new ReturnCommand(_carStore, _naviagationStore, _userStore);

            if (carStore.Car is null)
            {
                carStore.GenerateEmptyCar();
                IsNotVisible = Visibility.Visible;
                IsVisible = Visibility.Collapsed;
                Visibility = Visibility.Collapsed;
                Nvisibility = Visibility.Collapsed;
            }
            else
            {
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
