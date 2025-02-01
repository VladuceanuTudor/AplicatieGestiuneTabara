using Proiect_ABD;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace TabaraDeVaraApp.ViewModels
{
    public class CopilViewModel : INotifyPropertyChanged
    {
        private int _copilID;
        private string _nume;
        private string _prenume;
        private int _varsta;

        private ObservableCollection<ActivitateViewModel> _selectedCopilActivitati;

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

        public ObservableCollection<ActivitateViewModel> SelectedCopilActivitati
        {
            get => _selectedCopilActivitati;
            set { _selectedCopilActivitati = value; OnPropertyChanged(); }
        }



        public CopilViewModel(Copil copil)
        {

            _prenume = copil.Prenume;
            _varsta = copil.Varsta;
            _copilID = copil.CopilID;
            _nume = copil.Nume;

            //MessageBox.Show(_prenume);
            // Assuming _copilID is properly set somewhere before this logic is run
            using (var db = new TabaraDeVaraEntities())
            {
                var activitati = db.CopilActivitates
                    .Where(ca => ca.CopilID == _copilID)
                    .Select(ca => ca.Activitate)
                    .ToList();

                var prezenta = db.CopilActivitates
                    .Where(ca => ca.CopilID == _copilID)
                    .Select(ca => ca.Prezenta)
                    .ToList();

                var observatii = db.CopilActivitates
                    .Where(ca => ca.CopilID == _copilID)
                    .Select(ca => ca.Observatii)
                    .ToList();

                // Map Proiect_ABD.Activitate to ActivitateViewModel
                var activitateViewModels = activitati.Select(a => new ActivitateViewModel(a)).ToList();

                for (int i = 0; i < activitateViewModels.Count; i++)
                {
                    activitateViewModels[i].Observatii = observatii[i];
                    if (prezenta[i])
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
