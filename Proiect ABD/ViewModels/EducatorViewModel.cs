using Proiect_ABD;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
        public ICommand AddActivitateCommand { get; }

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

        private ObservableCollection<int> _copiiIDs = new ObservableCollection<int>();
        public ObservableCollection<int> CopiiIDs
        {
            get => _copiiIDs;
            set
            {
                _copiiIDs = value;
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
            var newParinte = new TabaraDeVaraApp.Models.Parinte();
            var viewModel = new AddParinteWindowViewModel(newParinte, CopiiIDs, () =>
            {
                var dbParinte = ConvertToDatabaseParinte(newParinte);
                using (var db = new DataClasses1DataContext())
                {
                    db.Parintes.InsertOnSubmit(dbParinte);
                    db.SubmitChanges();

                    Parinti.Add(dbParinte);

                    foreach (var copilID in CopiiIDs)
                    {
                        if (copilID != 0)
                        {
                            var copilParinte = new CopilParinte
                            {
                                CopilID = copilID,
                                ParinteID = dbParinte.ParinteID
                            };

                            db.CopilParintes.InsertOnSubmit(copilParinte);
                        }
                    }

                    db.SubmitChanges();
                }
            });

            ShowAddParinteWindow(viewModel);
        }

        private TabaraDeVaraApp.Models.Copil ConvertToAppCopil(Proiect_ABD.Copil dbCopil)
        {
            return new TabaraDeVaraApp.Models.Copil
            {
                CopilID = dbCopil.CopilID,
                Nume = dbCopil.Nume,
                Prenume = dbCopil.Prenume,
                Varsta = dbCopil.Varsta,
               
            };
        }

        private void EditParinte()
        {
            if (SelectedParinte == null) return;

            // Convert database Parinte to application Parinte
            var appParinte = ConvertToAppParinte(SelectedParinte);

            using (var db = new DataClasses1DataContext())
            {
                // Populate CopiiIDs with child IDs associated with the selected parent
                var copiiId = db.CopilParintes
                                .Where(cp => cp.ParinteID == SelectedParinte.ParinteID)
                                .Select(cp => cp.CopilID)
                                .ToList();
                CopiiIDs = new ObservableCollection<int>(copiiId);
            }

            var viewModel = new AddParinteWindowViewModel(appParinte, CopiiIDs, () =>
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

                    // Update CopilParintes for this parent
                    var existingCopilParintes = db.CopilParintes
                                                  .Where(cp => cp.ParinteID == SelectedParinte.ParinteID)
                                                  .ToList();
                    db.CopilParintes.DeleteAllOnSubmit(existingCopilParintes);

                    foreach (var copilID in CopiiIDs)
                    {
                        if (copilID != 0)
                        {
                            var copilParinte = new CopilParinte
                            {
                                CopilID = copilID,
                                ParinteID = SelectedParinte.ParinteID
                            };
                            db.CopilParintes.InsertOnSubmit(copilParinte);
                        }
                    }

                    db.SubmitChanges();
                }

                // Refresh UI
                var index = Parinti.IndexOf(SelectedParinte);
                Parinti[index] = ConvertToDatabaseParinte(appParinte);
            });

            ShowAddParinteWindow(viewModel);
        }

        private void ShowAddActivitateWindow(AddActivitateViewModel viewModel)
        {
            var window = new AddActivitateWindow
            {
                DataContext = viewModel
            };
            window.ShowDialog();
        }

        private TabaraDeVaraApp.Models.Activitate ConvertToAppActivitate(Proiect_ABD.Activitate dbActivitate)
        {
            return new TabaraDeVaraApp.Models.Activitate
            {
                // Assuming these are the properties
                ActivitateID = dbActivitate.ActivitateID,
                Denumire = dbActivitate.Nume,
                Descriere = dbActivitate.Descriere,
                EducatorID = dbActivitate.EducatorID,
                DataOra = dbActivitate.Data
                // Map other properties as needed
            };
        }

        private Activitate _selectedActivitate;
        public Activitate SelectedActivitate
        {
            get => _selectedActivitate;
            set
            {
                _selectedActivitate = value;
                OnPropertyChanged();
            }
        }

        public ICommand EditActivitateCommand { get; }


        private void AddActivitate()
        {
            var newActivitate = new TabaraDeVaraApp.Models.Activitate(); // Use application model

            var viewModel = new AddActivitateViewModel(newActivitate, () =>
            {
                using (var db = new DataClasses1DataContext())
                {
                    //var copiiId = db.Copils
                    //            .Where(cp => cp.EducatorID == E.EducatorID)
                    //            .Select(cp => cp.CopilID)
                    //            .ToList();
                    //CopiiIDs = new ObservableCollection<int>(copiiId);


                    var dbActivitate = new Proiect_ABD.Activitate
                    {
                        Nume = newActivitate.Denumire,
                        Descriere = newActivitate.Descriere,
                        EducatorID = E.EducatorID,
                        Data = newActivitate.DataOra
                        // Map other properties if needed
                    };

                    // Insert the database model into the database
                    db.Activitates.InsertOnSubmit(dbActivitate);
                    db.SubmitChanges();

                    // Convert the inserted database model to the application model and add it to the collection
                    Activitati.Add(dbActivitate); // Use the conversion method
                }
            }, new ObservableCollection<TabaraDeVaraApp.Models.Copil>(
                Copii.Select(c => ConvertToAppCopil(c))
             ));

            ShowAddActivitateWindow(viewModel);
        }

        private void EditActivitate()
        {
            if (SelectedActivitate == null) return;

            var appActivitate = ConvertToAppActivitate(SelectedActivitate);

            var viewModel = new AddActivitateViewModel(appActivitate, () =>
            {
                using (var db = new DataClasses1DataContext())
                {
                    var dbActivitate = db.Activitates.Single(a => a.ActivitateID == SelectedActivitate.ActivitateID);
                    dbActivitate.Nume = appActivitate.Denumire;
                    dbActivitate.Descriere = appActivitate.Descriere;
                    dbActivitate.Data = appActivitate.DataOra;

                    db.SubmitChanges();

                    // Refresh the activity in the UI
                    var index = Activitati.IndexOf(SelectedActivitate);
                    Activitati[index] = dbActivitate;
                }
            }, new ObservableCollection<TabaraDeVaraApp.Models.Copil>(
                Copii.Select(c => ConvertToAppCopil(c))
             ));

            ShowAddActivitateWindow(viewModel);
        }


        public EducatorViewModel(Educator Edu)
        {

            _educator = Edu;
            

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
                AddActivitateCommand = new RelayCommand(_ => AddActivitate());
                EditActivitateCommand = new RelayCommand(_ => EditActivitate());

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}