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
    public class SaveWindowTeamWindow : ICommand
    {
        private readonly ITeamWindowService _playerAssignService;
        private readonly TeamWindowViewModel _viewModel;

        public SaveWindowTeamWindow(TeamWindowViewModel viewModel , ITeamWindowService playerAssignService)
        {
            _playerAssignService = playerAssignService;
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_viewModel.CurrentTeam == null)
            {
                _viewModel.Teams.Add(new Team(_viewModel.Name,_viewModel.Country));
            }
            else
            {
                _viewModel.Name = _viewModel.CurrentTeam.Name;
                _viewModel.Country = _viewModel.CurrentTeam.Country;
            }
            _playerAssignService.CloseWindow();
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
