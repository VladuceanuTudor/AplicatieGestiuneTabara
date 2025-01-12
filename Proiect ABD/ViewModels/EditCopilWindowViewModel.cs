using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TabaraDeVaraApp.Commands;
using TabaraDeVaraApp.Models;

namespace TabaraDeVaraApp.ViewModels
{
    public class EditCopilWindowViewModel : INotifyPropertyChanged
    {
        public class CopilActivitateWithActivitate
        {
            public CopilActivitate CopilActivitate { get; set; }
            public Activitate Activitate { get; set; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Copil Copil { get; }
        public ObservableCollection<CopilActivitate> CopilActivitates { get; }
        public ObservableCollection<Activitate> Activitates { get; }

        public ObservableCollection<CopilActivitateWithActivitate> ComboCCA { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public Action CloseAction { get; }

        public EditCopilWindowViewModel(Copil copil, ObservableCollection<CopilActivitate> copilActivitates, ObservableCollection<Activitate> activitates)
        {
            Copil = copil ?? throw new ArgumentNullException(nameof(copil));
            CopilActivitates = copilActivitates ?? new ObservableCollection<CopilActivitate>();
            Activitates = activitates ?? new ObservableCollection<Activitate>();
            int i = 0;
            ComboCCA = new ObservableCollection<CopilActivitateWithActivitate>(
                CopilActivitates.Select(ca => new CopilActivitateWithActivitate
                {
                    CopilActivitate = ca,
                    Activitate = Activitates[i++]
                })
            );

            //DisplayCopilActivitateNames();

            SaveCommand = new RelayCommand(_ => Save());
            CancelCommand = new RelayCommand(_ => Cancel());
        }

        private void DisplayCopilActivitateNames()
        {
            var names = string.Join(Environment.NewLine, ComboCCA.Select(ca => ca.Activitate?.Denumire ?? "Unknown Activitate"));
            MessageBox.Show(names, "Copil Activitate Names", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Save()
        {
            foreach (var copilActivitate in CopilActivitates)
            {
                UpdateCopilActivitateInDatabase(copilActivitate);
            }

            MessageBox.Show("Changes saved successfully!");
            CloseAction?.Invoke();
        }

        private void Cancel()
        {
            CloseAction?.Invoke();
        }

        private void UpdateCopilActivitateInDatabase(CopilActivitate copilActivitate)
        {
            // Implement database update logic here
            // Example: Update copilActivitate using Entity Framework or another ORM
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
