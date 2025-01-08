using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TabaraDeVaraApp.Commands;
using TabaraDeVaraApp.Models;

namespace TabaraDeVaraApp.ViewModels
{
    public class AddParinteWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Parinte _parinte;

        public Parinte Parinte
        {
            get => _parinte;
            set
            {
                _parinte = value;
                OnPropertyChanged();
            }
        }

        public Action OnSave { get; private set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public AddParinteWindowViewModel(Parinte parinte, Action onSave)
        {
            Parinte = parinte ?? throw new ArgumentNullException(nameof(parinte));
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
