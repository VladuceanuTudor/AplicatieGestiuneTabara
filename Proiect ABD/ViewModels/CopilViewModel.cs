using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TabaraDeVaraApp.ViewModels
{
    public class CopilViewModel : INotifyPropertyChanged
    {
        private int _copilID;
        private string _nume;
        private string _prenume;
        private int _varsta;

        public int CopilID
        {
            get => _copilID;
            set { _copilID = value; OnPropertyChanged(); }
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

        public int Varsta
        {
            get => _varsta;
            set { _varsta = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
