using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using FootballAdministrationApp.ViewModel.ViewInterfaces;

namespace FootballAdministrationApp.ViewModel.Commands
{
    public class ModifyAvailablePlayerCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public ModifyAvailablePlayerCommand(MainWindowViewModel viewModel)
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
            if (_viewModel.AvailablePlayer != null)
            {
                IOpenWindowService dialog = _viewModel.View;
                dialog.CreateNewPlayerWindow(_viewModel.PlayerWindowView, _viewModel.BasicTeam, _viewModel.AvailablePlayer);
                _viewModel.RefreshAvailablePlayers();
                OnCanExecuteChanged();
            }
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
