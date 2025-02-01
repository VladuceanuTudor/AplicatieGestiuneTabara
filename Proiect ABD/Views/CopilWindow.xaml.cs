using System.Windows;
using TabaraDeVaraApp.ViewModels;

namespace TabaraDeVaraApp.Views
{
    public partial class CopilWindow : Window
    {
        public CopilWindow(CopilViewModel copilVM)
        {
            InitializeComponent();
            DataContext = copilVM;
        }

        
        private void BackToMainButton_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }
    }
}
