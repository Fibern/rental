using rental.DataTypes;
using rental.Stores;
using rental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace rental.Commands
{
    public class RegisterCommand<TViewModel> : CommandBase
        where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _viewModel;
        private readonly AuthenticationStore _authenticationStore;
        public RegisterCommand(NavigationStore navigationStore, Func<TViewModel> viewModel, AuthenticationStore authenticationStore)
        {
            _navigationStore = navigationStore;
            _viewModel = viewModel;
            _authenticationStore = authenticationStore;
        }
        public override bool CanExecute(object parameter)
        {
            List<User> users = ResourcesStore.Users;
            foreach (User u in users)
            {
                if(u.Login == _authenticationStore.Login)
                    return false; 
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            if (_authenticationStore.Login == "" || _authenticationStore.Password == "")
                return;
            List<User> users = ResourcesStore.Users;
            users.Add(new User(_authenticationStore.Login, _authenticationStore.Password, 0));
            ResourcesStore.Users = users;
            _navigationStore.SelectedRight = _viewModel();
        }
    }
}
