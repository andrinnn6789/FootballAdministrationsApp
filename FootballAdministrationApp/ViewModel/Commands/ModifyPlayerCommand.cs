using System;
using System.Windows;
using System.Windows.Input;
using FootballAdministrationApp.ViewModel.ViewInterfaces;

namespace FootballAdministrationApp.ViewModel.Commands
{
    public class ModifyPlayerCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public ModifyPlayerCommand(MainWindowViewModel viewModel)
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
            IOpenWindowService dialog = _viewModel.View;
            dialog.CreateNewPlayerWindow(_viewModel.PlayerWindowView, _viewModel.teams[0], _viewModel.AvailablePlayer);
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
