using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace TabaraDeVaraApp.ViewModels
{
    public class ActivitateViewModel : INotifyPropertyChanged
    {
        private int _activitateID;
        private string _denumire;
        private DateTime _data;
        private int _educatorID;
        private string _prezenta;
        private string _descriere;
        private string _observatii;
        private int _durata;
        

        // The ID of the activity
        public int ActivitateID
        {
            get => _activitateID;
            set { _activitateID = value; OnPropertyChanged(); }
        }

        // The name or title of the activity
        public string Denumire
        {
            get => _denumire;
            set { _denumire = value; OnPropertyChanged(); }
        }

        // The date and time of the activity
        public DateTime Data
        {
            get => _data;
            set { _data = value; OnPropertyChanged(); }
        }


        // The ID of the educator responsible for the activity
        public int EducatorID
        {
            get => _educatorID;
            set { _educatorID = value; OnPropertyChanged(); }
        }
        public int Durata
        {
            get => _durata;
            set { _durata = value; OnPropertyChanged(); }
        }

        public string Prezenta
        {
            get => _prezenta;
            set { _prezenta = value; OnPropertyChanged(); }
        }

        public string Observatii
        {
            get => _observatii;
            set { _observatii = value; OnPropertyChanged(); }
        }
        public string Descriere
        {
            get => _descriere;
            set { _descriere = value; OnPropertyChanged(); }
        }

        // The associated educator for this activity
        //public Educator Educator { get; set; }

        // Constructor that maps the Activitate entity to this ViewModel

        
        public ActivitateViewModel(Proiect_ABD.Activitate activitate)
        {
            ActivitateID = activitate.ActivitateID;
            Denumire = activitate.Nume;
            Data = activitate.Data;
            //MessageBox.Show($" {Data}");
            Data = Data.Add(activitate.Ora);
            //MessageBox.Show($" {Data}");
            Durata = activitate.Durata;
            EducatorID = activitate.EducatorID;
            Descriere = activitate.Descriere;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Notifies when a property changes so the UI can be updated
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
