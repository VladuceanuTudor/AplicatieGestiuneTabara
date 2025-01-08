using Proiect_ABD;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;


namespace TabaraDeVaraApp.ViewModels
{
    public class EducatorViewModel : INotifyPropertyChanged
    {
        private Educator _educator;
        private ObservableCollection<Copil> _copii;
        private ObservableCollection<Activitate> _activitati;
        private ObservableCollection<Parinte> _parinti;
        private ObservableCollection<Educator> _educatori;

        public Educator E
        {
            get => _educator;
            set
            {
                _educator = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Copil> Copii
        {
            get => _copii;
            set
            {
                _copii = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Parinte> Parinti
        {
            get => _parinti;
            set
            {
                _parinti = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Educator> Educatori
        {
            get => _educatori;
            set
            {
                _educatori = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Activitate> Activitati
        {
            get => _activitati;
            set
            {
                _activitati = value;
                OnPropertyChanged();
            }
        }

        public EducatorViewModel(Educator Edu)
        {
            //MessageBox.Show("Hello, World1!");

            _educator = Edu;
            //_educator.EducatorID = Edu.EducatorID;
            //_educator.Nume = Edu.Nume;
            //_educator.Prenume = Edu.Prenume;
            //_educator.Email = Edu.Email;
            //_educator.NumarTel = Edu.NumarTel;

            //MessageBox.Show("Hello, World2!");

            using (var db = new DataClasses1DataContext())
            {
                var copii = db.Copils
                    .Where(cp => cp.EducatorID == _educator.EducatorID)
                    .Select(cp => cp)
                    .ToList();

                Copii = new ObservableCollection<Copil>(copii);

                var activitati = db.Activitates
                    .Where(ac => ac.EducatorID == _educator.EducatorID)
                    .Select(ac => ac)
                    .ToList();

                Activitati = new ObservableCollection<Activitate>(activitati);

                var parinti = db.CopilParintes
                    .Where(cpp => copii.Select(c => c.CopilID).Contains(cpp.CopilID)) // Filter by CopilIDs
                    .Select(cpp => cpp.Parinte) // Get the associated Parinte
                    .Distinct() // Ensure unique parents
                    .ToList();

                Parinti = new ObservableCollection<Parinte>(parinti);

                var allEducatori = db.Educators
                    .ToList(); // Fetch all educators from the database

                Educatori = new ObservableCollection<Educator>(allEducatori);

                //MessageBox.Show("Hello, World3!");
            }
        }

        //private void LoadEducatorData()
        //{
        //    using (var db = new DataClasses1DataContext())
        //    {
        //        // Fetch the first educator from the database
        //        var educator = db.Educators.FirstOrDefault();
        //        if (educator != null)
        //        {
        //            // Assign the educator data
        //            E = educator;

        //            // Fetch and assign related Copii (children)
        //            Copii = new ObservableCollection<Copil>(db.Copils
        //                .Where(c => c.EducatorID == educator.EducatorID)
        //                .ToList());

        //            // Fetch and assign related Activitati (activities)
        //            Activitati = new ObservableCollection<Activitate>(db.Activitates
        //                .Where(a => a.EducatorID == educator.EducatorID)
        //                .ToList());
        //        }
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}