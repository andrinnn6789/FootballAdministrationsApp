using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FootballAdministrationApp.Model;
using FootballAdministrationApp.ViewModel.ViewInterfaces;

namespace FootballAdministrationApp.ViewModel.Commands
{
    public class ModifyTeamCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public ModifyTeamCommand(MainWindowViewModel viewModel)
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
                IOpenWindowService dialog = _viewModel.View;
                dialog.CreateNewTeamWindow(_viewModel.TeamWindowView, _viewModel.Teams, _viewModel.Team);
                _viewModel.Team = _viewModel.Teams.LastOrDefault();
                OnCanExecuteChanged();
            }
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
