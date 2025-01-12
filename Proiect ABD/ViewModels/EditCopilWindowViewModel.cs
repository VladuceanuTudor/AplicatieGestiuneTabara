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
        public ObservableCollection<CopilActivitate> CopilActivitates { get; set; }
        public ObservableCollection<Activitate> Activitates { get; set; }

        public ObservableCollection<CopilActivitateWithActivitate> ComboCCA { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public Action CloseAction { get; }
        public Action OnSave { get; private set; }

        public EditCopilWindowViewModel(Copil copil, ObservableCollection<CopilActivitate> copilActivitates, ObservableCollection<Activitate> activitates, Action onSave)
        {
            Copil = copil ?? throw new ArgumentNullException(nameof(copil));
            CopilActivitates = copilActivitates ?? new ObservableCollection<CopilActivitate>();
            Activitates = activitates ?? new ObservableCollection<Activitate>();
            OnSave = onSave ?? throw new ArgumentNullException(nameof(onSave));
            int i = 0;
            ComboCCA = new ObservableCollection<CopilActivitateWithActivitate>(
                CopilActivitates.Select(ca => new CopilActivitateWithActivitate
                {
                    CopilActivitate = ca,
                    Activitate = Activitates[i++]
                })
            );

            //DisplayCopilActivitateNames();

            SaveCommand = new RelayCommand(_ => {
                MessageBox.Show($"nume0: {Copil.Nume}");
                copilActivitates = new ObservableCollection<CopilActivitate>(
                ComboCCA.Select(caWithActivitate => caWithActivitate.CopilActivitate)
                );
                activitates = new ObservableCollection<Activitate>(
                ComboCCA.Select(caWithActivitate => caWithActivitate.Activitate)
                );
                Save();
            });
            CancelCommand = new RelayCommand(_ => CloseWindow());
        }

        private void DisplayCopilActivitateNames()
        {
            var names = string.Join(Environment.NewLine, ComboCCA.Select(ca => ca.Activitate?.Denumire ?? "Unknown Activitate"));
            MessageBox.Show(names, "Copil Activitate Names", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Save()
        {
            OnSave?.Invoke();
            CloseWindow();
        }
        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
