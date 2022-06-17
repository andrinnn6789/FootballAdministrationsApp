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
    public class CloseWindowTeamWindow : ICommand
    {
        private readonly ITeamWindowService _playerWindowService;

        public CloseWindowTeamWindow(ITeamWindowService playerWindowService)
        {
            _playerWindowService = playerWindowService;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _playerWindowService.CloseWindow();
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
