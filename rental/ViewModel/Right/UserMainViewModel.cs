using Caliburn.Micro;
using rental.Commands;
using rental.DataTypes;
using rental.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace rental.ViewModel.Right
{
    public class UserMainViewModel: BaseViewModel
    {
        public ICommand MoreCommand { get; set; }
        public BindableCollection<Car> cars { get; set; }
        public UserMainViewModel(NavigationStore navigationStore, UserStore userStore)
        {
            cars = ResourcesStore.Cars;
            MoreCommand = new MoreCommand<CarDetailsViewModel>(navigationStore, userStore, new CarStore(), 
                () => new CarDetailsViewModel(navigationStore, userStore, new CarStore()));
        }
    }
}
