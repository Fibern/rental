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
        private CarStore _carStore;

        public CarDetailsViewModel(NavigationStore naviagationStore, UserStore userStore, CarStore carStore)
        {
            _naviagationStore = naviagationStore;
            _userStore = userStore;
            _carStore = carStore;
        }
    }
}
