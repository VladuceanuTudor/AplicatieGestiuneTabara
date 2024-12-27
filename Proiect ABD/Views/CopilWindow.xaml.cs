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
    }
}
