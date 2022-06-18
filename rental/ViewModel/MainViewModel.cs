using rental.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        public BaseViewModel SelectedLeft => _navigationStore.SelectedLeft;
        public BaseViewModel SelectedRight => _navigationStore.SelectedRight;
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.SelectedLeftChanged += OnSelectedLeftChanged;
            _navigationStore.SelectedRightChanged += OnSelectedRightChanged;
        }

        private void OnSelectedRightChanged()
        {
            OnPropertyChanged(nameof(SelectedRight));
        }

        private void OnSelectedLeftChanged()
        {
            OnPropertyChanged(nameof(SelectedLeft));
        }
    }
}
