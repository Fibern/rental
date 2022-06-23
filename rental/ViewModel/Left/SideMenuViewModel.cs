using rental.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.ViewModel.Left
{
    public class SideMenuViewModel: BaseViewModel
    {
        private List<string> _items = new List<string> { "zaloguj", "zarejestruj" };
        public List<string> Items { get => _items; }
        public SideMenuViewModel(NavigationStore navigationStore)
        {
        }

        private string _selected;
        public string Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(_selected));
            }
        }

        
    }
}
