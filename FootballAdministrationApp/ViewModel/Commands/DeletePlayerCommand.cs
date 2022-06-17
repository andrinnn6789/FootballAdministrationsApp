using System;
using System.Windows;
using System.Windows.Input;
using FootballAdministrationApp.ViewModel.ViewInterfaces;

namespace FootballAdministrationApp.ViewModel.Commands
{
    public class DeletePlayerCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public DeletePlayerCommand(MainWindowViewModel viewModel)
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
            _viewModel.teams[0].RemoveOnePlayerById(_viewModel.AvailablePlayer.Id);
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
