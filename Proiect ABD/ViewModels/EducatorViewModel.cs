using Proiect_ABD;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TabaraDeVaraApp.Commands;
using TabaraDeVaraApp.ViewModels;
using TabaraDeVaraApp.Views;


namespace TabaraDeVaraApp.ViewModels
{
    public class EducatorViewModel : INotifyPropertyChanged
    {

        public ICommand AddParinteCommand { get; }
        public ICommand EditParinteCommand { get; }
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

        private Parinte _selectedParinte;
        public Parinte SelectedParinte
        {
            get => _selectedParinte;
            set
            {
                //MessageBox.Show("Hello, World1!");
                _selectedParinte = value;
                OnPropertyChanged();
            }
        }

        private void ShowAddParinteWindow(AddParinteWindowViewModel viewModel)
        {
            var window = new AddParinteWindow
            {
                DataContext = viewModel
            };
            window.ShowDialog();
        }

        private Proiect_ABD.Parinte ConvertToDatabaseParinte(TabaraDeVaraApp.Models.Parinte appParinte)
        {
            return new Proiect_ABD.Parinte
            {
                //ParinteID = appParinte.ParinteID,
                Nume = appParinte.Nume,
                Prenume = appParinte.Prenume,
                Email = appParinte.Email,
                Parola = appParinte.Parola,
                NumarTel = appParinte.NumarTel
                // Map other properties as needed
            };
        }

        private TabaraDeVaraApp.Models.Parinte ConvertToAppParinte(Proiect_ABD.Parinte dbParinte)
        {
            return new TabaraDeVaraApp.Models.Parinte
            {
                //ParinteID = dbParinte.ParinteID,
                Nume = dbParinte.Nume,
                Prenume = dbParinte.Prenume,
                Email = dbParinte.Email,
                NumarTel = dbParinte.NumarTel,
                Parola = dbParinte.Parola
                // Map other properties as needed
            };
        }


        private void AddParinte()
        {
            var newParinte = new TabaraDeVaraApp.Models.Parinte(); // Ensure the correct class is used
            var viewModel = new AddParinteWindowViewModel(newParinte, () =>
            {
                var dbParinte = ConvertToDatabaseParinte(newParinte);
                using (var db = new DataClasses1DataContext())
                {
                    db.Parintes.InsertOnSubmit(dbParinte);
                    db.SubmitChanges();

                    Parinti.Add(dbParinte);
                }
            });

            ShowAddParinteWindow(viewModel);
        }

        private void EditParinte()
        {
            if (SelectedParinte == null) return;

            // Convert database Parinte to application Parinte
            var appParinte = ConvertToAppParinte(SelectedParinte);

            var viewModel = new AddParinteWindowViewModel(appParinte, () =>
            {
                using (var db = new DataClasses1DataContext())
                {
                    // Find the corresponding Parinte in the database
                    var parinteInDb = db.Parintes.Single(p => p.ParinteID == SelectedParinte.ParinteID);
                    parinteInDb.Nume = appParinte.Nume;
                    parinteInDb.Prenume = appParinte.Prenume;
                    parinteInDb.Email = appParinte.Email;
                    parinteInDb.NumarTel = appParinte.NumarTel;
                    parinteInDb.Parola = appParinte.Parola;

                    db.SubmitChanges();
                }

                // Refresh UI
                var index = Parinti.IndexOf(SelectedParinte);
                Parinti[index] = ConvertToDatabaseParinte(appParinte);
            });

            ShowAddParinteWindow(viewModel);
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

                AddParinteCommand = new RelayCommand(_ => AddParinte());
                EditParinteCommand = new RelayCommand(_ => EditParinte());
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