using rental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Stores
{
    public class NavigationStore
    {
        public event Action SelectedLeftChanged;
        public event Action SelectedRightChanged;

        private BaseViewModel _selectedLeft;
        public BaseViewModel SelectedLeft {
            get => _selectedLeft; 
            set
            {
                _selectedLeft = value;
                OnSelectedLeftChanged();
            }
        }

        private BaseViewModel _selectedRight;
        public BaseViewModel SelectedRight {
            get => _selectedRight; 
            set
            {
                _selectedRight = value;
                OnSelectedRightChanged();
            }
        }

        private void OnSelectedLeftChanged()
        {
            SelectedLeftChanged?.Invoke();
        }
        private void OnSelectedRightChanged()
        {
            SelectedRightChanged?.Invoke();
        }

    }
}
