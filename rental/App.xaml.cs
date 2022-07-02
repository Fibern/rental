using rental.DataTypes;
using rental.Stores;
using rental.ViewModel;
using rental.ViewModel.Left;
using rental.ViewModel.Right;
using System.Collections.Generic;
using System.Windows;

namespace rental
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            
            //Car car = new Car();
            //car.Id = 0;
            //car.Price = 100;
            //car.Brand = "Ford";
            //car.Model = "Focus";
            //car.Year = 2017;
            //car.EngineCapacity = 1498;
            //car.FuelType = "Diesel";
            //car.HorsePower = 120;
            //car.Transmission = "Manualna";
            //car.Drive = "na przednie koła";
            //car.FuelUsage = 5.6;
            //car.BodyStyle = "Kombi";
            //car.Seats = 5;
            //car.Colour = "czarny";
            //List<Car> cars = new List<Car>();
            //cars.Add(car);
            //ResourcesStore.Cars = cars;

            NavigationStore navigationStore = new NavigationStore();
            navigationStore.SelectedLeft = new SideMenuViewModel(navigationStore);
            navigationStore.SelectedRight = new LoginViewModel(navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();


            base.OnStartup(e);
        }
    }
}
