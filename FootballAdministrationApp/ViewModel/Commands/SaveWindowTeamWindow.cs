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
                var newTeam = new Team()
                {
                    Id = _viewModel.CurrentTeam.Id,
                    Name = _viewModel.Name,
                    Country = _viewModel.Country
                };
                foreach (var player in _viewModel.CurrentTeam.GetPlayers())
                {
                   newTeam.AddPlayer(player); 
                }
                _viewModel.Teams.Add(newTeam);
                _viewModel.Teams.Remove(_viewModel.CurrentTeam);
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
