using System.Windows.Input;
using System;
using TabaraDeVaraApp.Commands;

public class AddCopilWindowViewModel
{
    public TabaraDeVaraApp.Models.Copil Copil { get; }
    public ICommand SaveCommand { get; }

    public AddCopilWindowViewModel(TabaraDeVaraApp.Models.Copil copil, Action saveAction)
    {
        Copil = copil;
        SaveCommand = new RelayCommand(_ => saveAction());
    }
}
