using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FootballAdministrationApp.Model;
using FootballAdministrationApp.View;
using FootballAdministrationApp.ViewModel.ViewInterfaces;

namespace FootballAdministrationApp.ViewModel.Commands
{
    public class PlayerAssignCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public PlayerAssignCommand(MainWindowViewModel viewModel)
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
            if (_viewModel.Team != null && _viewModel.BasicTeam.GetPlayers().Count > 0)
            {
                IOpenWindowService dialog = _viewModel.View;
                dialog.CreateNewPlayerAssignWindow(_viewModel.PlayerAssignView, _viewModel.BasicTeam, _viewModel.Team);
                _viewModel.Player = _viewModel.Players.FirstOrDefault();
                OnCanExecuteChanged();
            }
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
