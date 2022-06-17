using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using FootballAdministrationApp.ViewModel.ViewInterfaces;

namespace FootballAdministrationApp.ViewModel.Commands
{
    public class DeleteAvailablePlayerCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public DeleteAvailablePlayerCommand(MainWindowViewModel viewModel)
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
                _viewModel.BasicTeam.RemoveOnePlayerById(_viewModel.AvailablePlayer.Id);
            _viewModel.AvailablePlayer = _viewModel.AvailablePlayers.FirstOrDefault();
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
