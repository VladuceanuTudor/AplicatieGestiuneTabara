using System.Windows;
using TabaraDeVaraApp.ViewModels;


namespace TabaraDeVaraApp.Views
{
    public partial class ParinteWindow : Window
    {
        public ParinteWindow(ParinteViewModel parinteVM)
        {
            InitializeComponent();
            DataContext = parinteVM;
        }
    }
}
