using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.ViewModel.Left
{
    public class UserMenuViewModel : BaseViewModel
    {
        private List<string> _items = new List<string>() { "ajda", "adada" };
        public List<string> Items
        {
            get => _items;
            set
            {
                _items = value;
            }
        }
    }
}
