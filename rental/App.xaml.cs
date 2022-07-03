using rental.Stores;
using rental.ViewModel;
using System.Windows;

namespace rental
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            NavigationStore navigationStore = new NavigationStore();
            navigationStore.SelectedLeft = new SideMenuViewModel(navigationStore);
            navigationStore.SelectedRight = new LoginViewModel(navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();


            base.OnStartup(e);
        }
    }
}
