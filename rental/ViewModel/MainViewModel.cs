using rental.Stores;

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
