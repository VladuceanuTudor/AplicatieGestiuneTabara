using System.Windows;
using System.Windows.Controls;
using TabaraDeVaraApp.ViewModels;

namespace TabaraDeVaraApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(); // Make sure MainViewModel is set as DataContext
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Access the PasswordBox and bind the password to the ViewModel
            var passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                var viewModel = DataContext as MainViewModel;
                if (viewModel != null)
                {
                    viewModel.Password = passwordBox.Password; // Set the ViewModel's Password property
                }
            }
        }
    }
}
