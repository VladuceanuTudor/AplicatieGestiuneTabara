﻿using Proiect_ABD;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TabaraDeVaraApp.Views;
using TabaraDeVaraApp.Commands; // Include the RelayCommand class

namespace TabaraDeVaraApp.ViewModels
{
    public class MainViewModel
    {
        private readonly DataClasses1DataContext _db;

        public string Email { get; set; }
        public string Password { get; set; }

        // RelayCommand for the login action
        public ICommand LoginCommand { get; set; }

        public MainViewModel()
        {
            _db = new DataClasses1DataContext();
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        // Execute the login action
        private void ExecuteLogin(object parameter)
        {
            var user = Login(Email, Password);

            if (user != null)
            {
                // Open the appropriate window based on the user type
                if (user is ParinteViewModel parinteVM)
                {
                    var parinteWindow = new ParinteWindow(parinteVM);
                    parinteWindow.Show();
                }
                else if (user is CopilViewModel copilVM)
                {
                    var copilWindow = new CopilWindow(copilVM);
                    copilWindow.Show();
                }
                else if (user is EducatorViewModel educatorVM)
                {
                    var educatorWindow = new EducatorWindow(educatorVM);
                    educatorWindow.Show();
                }

                // Close the login window
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Email sau parolă incorectă.");
            }
        }

        // CanExecuteLogin logic to check if login can proceed
        private bool CanExecuteLogin(object parameter)
        {
            return !string.IsNullOrEmpty(Email);
            //return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
            //return true;
        }

        // Login method to check the user
        private object Login(string email, string password)
        {
            //MessageBox.Show($"The entered is: {email}");
            //MessageBox.Show($"The entered is: {password}");
            var parinte = _db.Parintes.FirstOrDefault(p => p.Email == email && p.Parola == password);
            //MessageBox.Show($"The entered is: {parinte}");
            if (parinte != null)
                return new ParinteViewModel(parinte); // Properly initialize the view model

            var copil = _db.Copils.FirstOrDefault(c => c.Parola == password && _db.Parintes.Any(p => p.Email == email));
            if (copil != null)
                return new CopilViewModel
                {
                    CopilID = copil.CopilID,
                    Nume = copil.Nume,
                    Prenume = copil.Prenume,
                    Varsta = copil.Varsta
                };

            var educator = _db.Educators.FirstOrDefault(e => e.Email == email && e.Parola == password);
            if (educator != null)
                return new EducatorViewModel
                {
                    EducatorID = educator.EducatorID,
                    Nume = educator.Nume,
                    Prenume = educator.Prenume,
                    Email = educator.Email
                };

            return null;
        }
    }
}