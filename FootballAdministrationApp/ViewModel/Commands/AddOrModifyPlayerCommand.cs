using System;
using System.Windows;
using System.Windows.Input;

namespace FootballAdministrationApp.ViewModel.Commands
{
    public class AddOrModifyPlayerCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public AddOrModifyPlayerCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
