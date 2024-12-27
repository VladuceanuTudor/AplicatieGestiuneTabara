using System.Windows;
using TabaraDeVaraApp.ViewModels;

namespace TabaraDeVaraApp.Views
{
    public partial class EducatorWindow : Window
    {
        public EducatorWindow(EducatorViewModel educatorVM)
        {
            InitializeComponent();
            DataContext = educatorVM;
        }
    }
}
