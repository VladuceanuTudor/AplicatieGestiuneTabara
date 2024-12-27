using Proiect_ABD;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System;

namespace TabaraDeVaraApp.ViewModels
{
    public class ParinteViewModel : INotifyPropertyChanged
    {
        // Properties for Parinte attributes
        private int _parinteID;
        private string _nume;
        private string _prenume;
        private string _email;
        private string _numarTel;

        public int ParinteID
        {
            get { return _parinteID; }
            set { _parinteID = value; OnPropertyChanged(); }
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

        public string NumarTel
        {
            get => _numarTel;
            set { _numarTel = value; OnPropertyChanged(); }
        }

        // Properties for Copii and Activitati
        private ObservableCollection<Copil> _copii;
        private ObservableCollection<ActivitateViewModel> _selectedCopilActivitati;
        private ObservableCollection<bool> _prezenta;
        private Copil _selectedCopil;

        public ObservableCollection<Copil> Copii
        {
            get => _copii;
            set { _copii = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ActivitateViewModel> SelectedCopilActivitati
        {
            get => _selectedCopilActivitati;
            set { _selectedCopilActivitati = value; OnPropertyChanged(); }
        }

        public ObservableCollection<bool> Prezenta
        {
            get => _prezenta;
            set { _prezenta = value; OnPropertyChanged(); }
        }
        public Copil SelectedCopil
        {
            get => _selectedCopil;
            set
            {
                _selectedCopil = value;
                OnPropertyChanged();
                LoadActivitatiForSelectedCopil();
            }
        }

        // Parameterless constructor for design-time support
        public ParinteViewModel()
        {
        }

        // Constructor for runtime initialization
        public ParinteViewModel(Parinte parinte)
        {
            ParinteID = parinte.ParinteID;
            Nume = parinte.Nume;
            Prenume = parinte.Prenume;
            Email = parinte.Email;
            NumarTel = parinte.NumarTel;

            using (var db = new DataClasses1DataContext())
            {
                var copii = db.CopilParintes
                    .Where(cp => cp.ParinteID == parinte.ParinteID)
                    .Select(cp => cp.Copil)
                    .ToList();
                
                Copii = new ObservableCollection<Copil>(copii);
            }
        }

        private void LoadActivitatiForSelectedCopil()
        {
            
            if (SelectedCopil != null)
            {
                using (var db = new DataClasses1DataContext())
                {
                    var activitati = db.CopilActivitates
                        .Where(ca => ca.CopilID == SelectedCopil.CopilID)
                        .Select(ca => ca.Activitate)
                        .ToList();

                    Prezenta = new ObservableCollection<bool>( db.CopilActivitates
                        .Where(ca => ca.CopilID == SelectedCopil.CopilID)
                        .Select (ca => ca.Prezenta)
                        .ToList());

                    // Map Proiect_ABD.Activitate to ActivitateViewModel
                    var activitateViewModels = activitati.Select(a => new ActivitateViewModel(a)
                    ).ToList();

                    
                    for (int i=0; i < activitateViewModels.Count; i++)
                    {
                        if(Prezenta[i])
                            activitateViewModels[i].Prezenta = "Prezent.";
                        else
                            activitateViewModels[i].Prezenta = "Absent.";
                        if (activitateViewModels[i].Data > DateTime.Now)
                        {
                            activitateViewModels[i].Prezenta = "Activitate viitoare.";
                        }
                    }

                    // Set the ObservableCollection to the ViewModel list
                    SelectedCopilActivitati = new ObservableCollection<ActivitateViewModel>(activitateViewModels);
                }
            }
            else
            {
                SelectedCopilActivitati = new ObservableCollection<ActivitateViewModel>();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
