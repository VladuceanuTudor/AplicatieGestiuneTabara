using Proiect_ABD;
using System;
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
        public ICommand AddCopilCommand { get; }
        public ICommand EditCopilCommand { get; }



        public Copil SelectedCopil { get; set; }
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
                using (var db = new TabaraDeVaraEntities())
                {
                    db.Parintes.Add(dbParinte);
                    db.SaveChanges();

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

                            db.CopilParintes.Add(copilParinte);
                        }
                    }

                    db.SaveChanges();
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

            using (var db = new TabaraDeVaraEntities())
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
                using (var db = new TabaraDeVaraEntities())
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
                    foreach (var copilParinte in existingCopilParintes)
                    {
                        db.CopilParintes.Remove(copilParinte); // Remove each entry
                    }

                    db.SaveChanges(); // Commit the changes to the database


                    foreach (var copilID in CopiiIDs)
                    {
                        if (copilID != 0)
                        {
                            var copilParinte = new CopilParinte
                            {
                                CopilID = copilID,
                                ParinteID = SelectedParinte.ParinteID
                            };
                            db.CopilParintes.Add(copilParinte);
                        }
                    }

                    db.SaveChanges();
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

            // Load CopilActivitate relationships for the current Activitate
            using (var db = new TabaraDeVaraEntities())
            {
                var copiiWithFlags = new ObservableCollection<TabaraDeVaraApp.Models.CopilWithFlag>(
                    Copii.Select(c => new TabaraDeVaraApp.Models.CopilWithFlag
                    {
                        Copil = ConvertToAppCopil(c),
                        IsChecked = false // Initially unchecked, since this is a new activity
                    })
                );

                var viewModel = new AddActivitateViewModel(newActivitate, () =>
                {
                    using (var innerDb = new TabaraDeVaraEntities()) // Renamed from `db` to `innerDb`
                    {
                        // Create a new database entity
                        var dbActivitate = new Proiect_ABD.Activitate
                        {
                            Nume = newActivitate.Denumire,
                            Descriere = newActivitate.Descriere,
                            EducatorID = E.EducatorID, // Make sure this is properly set
                            Data = newActivitate.DataOra
                        };

                        // Insert the database model into the database
                        innerDb.Activitates.Add(dbActivitate);
                        innerDb.SaveChanges(); // Commit the new activity to the database

                        // Convert the inserted database model to the application model and add it to the collection
                        Activitati.Add(dbActivitate); // Use the conversion method to add it to the UI collection

                        // Now handle CopilActivitate relationships based on checkbox selections
                        foreach (var copilWithFlag in copiiWithFlags)
                        {
                            if (copilWithFlag.IsChecked)
                            {
                                // Add relationship for checked children
                                innerDb.CopilActivitates.Add(new CopilActivitate
                                {
                                    ActivitateID = dbActivitate.ActivitateID, // New activity ID
                                    CopilID = copilWithFlag.Copil.CopilID
                                });
                            }
                        }

                        innerDb.SaveChanges(); // Commit the CopilActivitate changes to the database
                    }
                }, copiiWithFlags);

                ShowAddActivitateWindow(viewModel);
            }
        }


        private void EditActivitate()
        {
            if (SelectedActivitate == null) return;

            var appActivitate = ConvertToAppActivitate(SelectedActivitate);

            // Load CopilActivitate relationships for the current Activitate
            using (var db = new TabaraDeVaraEntities())
            {
                var connectedCopiiIds = db.CopilActivitates
                    .Where(ca => ca.ActivitateID == SelectedActivitate.ActivitateID)
                    .Select(ca => ca.CopilID)
                    .ToHashSet();

                var copiiWithFlags = new ObservableCollection<TabaraDeVaraApp.Models.CopilWithFlag>(
                    Copii.Select(c => new TabaraDeVaraApp.Models.CopilWithFlag
                    {
                        Copil = ConvertToAppCopil(c),
                        IsChecked = connectedCopiiIds.Contains(c.CopilID)
                    })
                );
                if (SelectedActivitate == null) MessageBox.Show("Hello, World1!");
                var viewModel = new AddActivitateViewModel(appActivitate, () =>
                {
                    using (var innerDb = new TabaraDeVaraEntities()) // Renamed from `db` to `innerDb`
                    {
                        var dbActivitate = innerDb.Activitates.Single(a => a.ActivitateID == SelectedActivitate.ActivitateID);
                        dbActivitate.Nume = appActivitate.Denumire;
                        dbActivitate.Descriere = appActivitate.Descriere;
                        dbActivitate.Data = appActivitate.DataOra;

                        innerDb.SaveChanges();
                        if (SelectedActivitate == null) MessageBox.Show("Hello, World2!");
                        // Refresh the activity in the UI
                        //var index = Activitati.IndexOf(SelectedActivitate);
                        //Activitati[index] = dbActivitate;
                        
                        // Update CopilActivitate table based on checkbox changes
                        foreach (var copilWithFlag in copiiWithFlags)
                        {
                            if (copilWithFlag.IsChecked && !connectedCopiiIds.Contains(copilWithFlag.Copil.CopilID))
                            {
                                if (SelectedActivitate == null) MessageBox.Show("Hello, World3!");
                                // Add relationship
                                innerDb.CopilActivitates.Add(new CopilActivitate
                                {
                                    ActivitateID = SelectedActivitate.ActivitateID,
                                    CopilID = copilWithFlag.Copil.CopilID
                                });
                            }
                            else if (!copilWithFlag.IsChecked && connectedCopiiIds.Contains(copilWithFlag.Copil.CopilID))
                            {
                                // Remove relationship
                                var relationship = innerDb.CopilActivitates.SingleOrDefault(ca =>
                                    ca.ActivitateID == SelectedActivitate.ActivitateID &&
                                    ca.CopilID == copilWithFlag.Copil.CopilID);

                                if (relationship != null)
                                {
                                    innerDb.CopilActivitates.Remove(relationship);
                                }
                            }
                        }

                        innerDb.SaveChanges();
                        var activitati = innerDb.Activitates
                            .Where(ac => ac.EducatorID == _educator.EducatorID)
                            .Select(ac => ac)
                            .ToList();

                        Activitati = new ObservableCollection<Activitate>(activitati);
                    }
                }, copiiWithFlags);

                ShowAddActivitateWindow(viewModel);
            }
        }

        private void ShowAddCopilWindow(AddCopilWindowViewModel viewModel)
        {
            var window = new AddCopilWindow
            {
                DataContext = viewModel
            };
            window.ShowDialog();
        }

        private void AddCopil()
        {
            var newCopil = new TabaraDeVaraApp.Models.Copil(); // Create a new Copil model

            var viewModel = new AddCopilWindowViewModel(newCopil, () =>
            {
                using (var db = new TabaraDeVaraEntities())
                {
                    var dbCopil = new Proiect_ABD.Copil
                    {
                        Nume = newCopil.Nume,
                        Prenume = newCopil.Prenume,
                        Varsta = newCopil.Varsta,
                        Parola = newCopil.Parola,
                        EducatorID = E.EducatorID // Ensure the new Copil is associated with the current educator
                    };

                    // Insert the new Copil into the database
                    db.Copils.Add(dbCopil);
                    db.SaveChanges();

                    // Add the new Copil to the ObservableCollection so it updates the UI
                    Copii.Add(dbCopil);
                }
            });

            ShowAddCopilWindow(viewModel);
        }

        private ObservableCollection<CopilActivitate> FetchCopilActivitates(int copilId)
        {
            using (var db = new TabaraDeVaraEntities())
            {
                var result = db.CopilActivitates
                    .Where(ca => ca.CopilID == copilId)
                    .Select(ca => new
                    {
                        ActivitateID = ca.ActivitateID,
                        CopilID = ca.CopilID,
                        ca.Prezenta,
                        ca.Observatii
                    })
                    .ToList();

                // Now map the result to CopilActivitate if needed
                var copilActivitates = new ObservableCollection<CopilActivitate>(
                    result.Select(r => new CopilActivitate
                    {
                        Activitate = new Activitate { ActivitateID = r.ActivitateID },
                        CopilID = r.CopilID,
                        Prezenta = r.Prezenta,
                        Observatii = r.Observatii
                    })
                );

                return copilActivitates;
            }
        }
        
        private ObservableCollection<CopilActivitate> FetchActivitates(int copilId)
        {
            using (var db = new TabaraDeVaraEntities())
            {
                var result = db.CopilActivitates
                    .Where(ca => ca.CopilID == copilId)
                    .Select(ca => new
                    {
                        ActivitateID = ca.ActivitateID,
                    })
                    .ToList();

                // Extract the ActivitateIDs from the result
                var activitateIds = result.Select(r => r.ActivitateID).ToList();

                // Second query: Get the Activitate Nume for each ActivitateID
                var activitateNames = db.Activitates
                    .Where(ac => activitateIds.Contains(ac.ActivitateID))
                    .Select(ac => new
                    {
                        ac.ActivitateID,
                        ac.Nume
                    })
                    .ToList();

                // Now map the result to CopilActivitate and include Activitate Nume
                var Activitates = new ObservableCollection<CopilActivitate>(
                    result.Select(r => new CopilActivitate
                    {
                        Activitate = new Activitate
                        {
                            Nume = activitateNames
                                .FirstOrDefault(an => an.ActivitateID == r.ActivitateID)?.Nume // Get the Nume based on ActivitateID
                        },
                    })
                );

                return Activitates;
            }

        }
        private void RefreshCopii()
        {
            using (var db = new TabaraDeVaraEntities())
            {
                Copii = new ObservableCollection<Copil>(
                    db.Copils.Where(cp => cp.EducatorID == _educator.EducatorID).ToList());
            }
        }

        private bool CanEditCopil(object parameter)
        {
            return SelectedCopil != null;
        }

        private TabaraDeVaraApp.Models.Copil MapCopil(Proiect_ABD.Copil copil)
        {
            return new TabaraDeVaraApp.Models.Copil
            {
                CopilID = copil.CopilID,
                Nume = copil.Nume,
                Varsta = copil.Varsta,
                Parola = copil.Parola,
                Prenume = copil.Prenume,

            };
        }

        private ObservableCollection<TabaraDeVaraApp.Models.CopilActivitati> MapCopilActivitateCollection(ObservableCollection<Proiect_ABD.CopilActivitate> copilActivitati)
        {
            return new ObservableCollection<TabaraDeVaraApp.Models.CopilActivitati>(
                copilActivitati.Select(ca => new TabaraDeVaraApp.Models.CopilActivitati
                {
                    ActivitateID = ca.ActivitateID,
                    CopilID = ca.CopilID,
                    Observatii = ca.Observatii,
                    Prezenta = ca.Prezenta,
                    
                })
            );
        }
        private ObservableCollection<TabaraDeVaraApp.Models.Activitate> MapCopilActivitateToActivitateCollection(ObservableCollection<Proiect_ABD.CopilActivitate> copilActivitateCollection)
        {
            return new ObservableCollection<TabaraDeVaraApp.Models.Activitate>(
                copilActivitateCollection.Select(ca => new TabaraDeVaraApp.Models.Activitate
                {
                    ActivitateID = ca.ActivitateID,
                    Denumire = ca.Activitate?.Nume,      
                })
            );
        }



        private void OpenEditCopilWindow(object parameter)
        {
            if (!CanEditCopil(parameter))  // `parameter` will be the SelectedCopil
            {
                MessageBox.Show("Invalid selection or no child selected.");
                return;
            }

            var selectedCopil = parameter as Copil;
            if (selectedCopil == null)
            {
                MessageBox.Show("Invalid selection.");
                return;
            }

            var mappedCopil = MapCopil(selectedCopil);
            var copilActivitates = FetchCopilActivitates(selectedCopil.CopilID);
            var activitati = FetchActivitates(selectedCopil.CopilID);
            var mappedCopilActivitates = MapCopilActivitateCollection(copilActivitates);
            var activitateCollection = MapCopilActivitateToActivitateCollection(activitati);

            var editWindow = new EditCopilWindow
            {
                DataContext = new EditCopilWindowViewModel(mappedCopil, mappedCopilActivitates, activitateCollection, () =>
                {
                    using (var innerDb = new TabaraDeVaraEntities()) 
                    {
                        
                        if (SelectedCopil != null)
                        {
                            // Update the existing Copil record in the database
                            var dbCopil = innerDb.Copils.Single(cp => cp.CopilID == mappedCopil.CopilID);
                            dbCopil.Nume = mappedCopil.Nume; // Update Nume
                            //MessageBox.Show($"nume1: {mappedCopil.Nume}");
                            //MessageBox.Show($"nume2: {dbCopil.Nume}");
                            dbCopil.Prenume = mappedCopil.Prenume; // Update Prenume
                            dbCopil.Varsta = mappedCopil.Varsta; // Update Varsta
                            dbCopil.Parola = mappedCopil.Parola; // Update Parola
                           // MessageBox.Show("SelectedCopil up!");

                            // Commit the changes for Copil
                            innerDb.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("SelectedCopil is null!");
                            return;
                        }

                        foreach (var copilWithFlag in mappedCopilActivitates)
                        {
                            //MessageBox.Show($"ActivitateID: {copilWithFlag.CopilID}");
                            if (copilWithFlag.CopilID != 0)
                            {
                                // Fetch the existing relationship from the database
                                var existingRelationship = innerDb.CopilActivitates.SingleOrDefault(ca =>
                                    ca.ActivitateID == copilWithFlag.ActivitateID &&
                                    ca.CopilID == copilWithFlag.CopilID);

                                if (existingRelationship != null)
                                {
                                    // Update Prezenta and Observatii if changed
                                    if (existingRelationship.Prezenta != copilWithFlag.Prezenta)
                                    {
                                        existingRelationship.Prezenta = copilWithFlag.Prezenta;
                                    }


                                        existingRelationship.Observatii = copilWithFlag.Observatii;
                                        //MessageBox.Show($"obs: {copilWithFlag.Observatii}");
                                    
                                }
                            }
                        }

                        innerDb.SaveChanges();
                        var copii = innerDb.Copils
                            .Where(cp => cp.EducatorID == _educator.EducatorID)
                            .Select(cp => cp)
                            .ToList();

                        Copii = new ObservableCollection<Copil>(copii);
                    }
                })
            };
            editWindow.ShowDialog();
        }



        public EducatorViewModel(Educator Edu)
        {

            _educator = Edu;
            

            using (var db = new TabaraDeVaraEntities())
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

                var copilIds = copii.Select(c => c.CopilID).ToList(); // Get the list of CopilIDs from copii

                var parinti = db.CopilParintes
                    .Where(cpp => copilIds.Contains(cpp.CopilID)) // Use the list of CopilIDs for filtering
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
                AddCopilCommand = new RelayCommand(_ => AddCopil());
                EditCopilCommand = new RelayCommand(OpenEditCopilWindow, CanEditCopil);

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}