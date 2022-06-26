using rental.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.ViewModel.Right
{
    public class CarDetailsViewModel : BaseViewModel
    {
        private NavigationStore _naviagationStore;
        private UserStore _userStore;
        private int _carId;

        public CarDetailsViewModel(NavigationStore naviagationStore, UserStore userStore, int carId)
        {
            _naviagationStore = naviagationStore;
            _userStore = userStore;
            _carId = carId;
        }
    }
}
