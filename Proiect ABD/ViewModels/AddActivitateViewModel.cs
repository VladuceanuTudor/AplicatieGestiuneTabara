using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TabaraDeVaraApp.Commands;
using TabaraDeVaraApp.Models;

namespace TabaraDeVaraApp.ViewModels
{
    public class AddActivitateViewModel : INotifyPropertyChanged
    {
        private Activitate _activitate;
        public Activitate Activitate
        {
            get => _activitate;
            set
            {
                _activitate = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Copil> _copii;
        public ObservableCollection<Copil> Copii
        {
            get => _copii;
            set
            {
                _copii = value;
                OnPropertyChanged();
            }
        }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly Action _onSave;

        public AddActivitateViewModel(Activitate activitate, Action onSave, ObservableCollection<Copil> copii)
        {
            _activitate = activitate;
            _onSave = onSave;
            Copii = copii ?? throw new ArgumentNullException(nameof(copii));
            SaveCommand = new RelayCommand(_ =>
            {
                _onSave?.Invoke();
                CloseWindow();
            });
            CancelCommand = new RelayCommand(_ => Cancel());
        }
        private void Cancel()
        {
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
