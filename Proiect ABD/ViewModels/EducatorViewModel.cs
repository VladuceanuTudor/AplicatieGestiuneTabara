using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TabaraDeVaraApp.ViewModels
{
    public class EducatorViewModel : INotifyPropertyChanged
    {
        private int _educatorID;
        private string _nume;
        private string _prenume;
        private string _email;

        public int EducatorID
        {
            get => _educatorID;
            set { _educatorID = value; OnPropertyChanged(); }
        }

        public string Nume
        {
            get => _nume;
            set { _nume = value; OnPropertyChanged(); }
        }

        public string Prenume
        {
            get => _prenume;
            set { _prenume = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
