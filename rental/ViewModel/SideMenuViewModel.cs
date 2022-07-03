using rental.Commands;
using rental.Stores;
using System.Windows.Input;

namespace rental.ViewModel
{
    public class SideMenuViewModel : BaseViewModel
    {
        public ICommand Register { get; set; }
        public ICommand Login { get; set; }
        public SideMenuViewModel(NavigationStore navigationStore)
        {
            Register = new NavigateCommand<RegisterViewModel>(navigationStore, () => new RegisterViewModel(navigationStore), false);
            Login = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore), false);
        }
    }
}
