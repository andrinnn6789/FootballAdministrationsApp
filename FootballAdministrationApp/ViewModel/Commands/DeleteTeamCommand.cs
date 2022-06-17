using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using FootballAdministrationApp.ViewModel.ViewInterfaces;

namespace FootballAdministrationApp.ViewModel.Commands
{
    public class DeleteTeamCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public DeleteTeamCommand(MainWindowViewModel viewModel)
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
            if (_viewModel.Team != null)
            {
                _viewModel.Teams.Remove(_viewModel.Team);
                _viewModel.Players = null;
                _viewModel.TeamCountry = null;
                _viewModel.TeamName = null;
            }
            
            _viewModel.Team = _viewModel.Teams.FirstOrDefault();

            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
