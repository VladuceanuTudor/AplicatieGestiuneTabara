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
    public class AddCopilWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Copil _copil;

        public Copil Copil
        {
            get => _copil;
            set
            {
                _copil = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<int> _parentIDs = new ObservableCollection<int>();

        public ObservableCollection<int> ParentIDs
        {
            get => _parentIDs;
            set
            {
                _parentIDs = value;
                OnPropertyChanged();
            }
        }

        public Action OnSave { get; private set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public AddCopilWindowViewModel(Copil copil,  Action onSave)
        {
            Copil = copil ?? throw new ArgumentNullException(nameof(copil));
            OnSave = onSave ?? throw new ArgumentNullException(nameof(onSave));

            SaveCommand = new RelayCommand(_ => Save());
            CancelCommand = new RelayCommand(_ => Cancel());
        }

        private void Save()
        {
            OnSave?.Invoke();
            CloseWindow();
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
