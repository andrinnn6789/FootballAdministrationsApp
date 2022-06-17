using System;
using System.Windows;
using System.Windows.Input;
using FootballAdministrationApp.ViewModel.ViewInterfaces;

namespace FootballAdministrationApp.ViewModel.Commands
{
    public class RemovePlayerCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public RemovePlayerCommand(MainWindowViewModel viewModel)
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
            if (_viewModel.Player != null)
            {
                _viewModel.basicTeam.AddPlayer(_viewModel.Player);
                _viewModel.Team.RemoveOnePlayerById(_viewModel.Player.Id);
            }  
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
