using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FootballAdministrationApp.Model;
using FootballAdministrationApp.View;
using FootballAdministrationApp.View.Interfaces;

namespace FootballAdministrationApp.ViewModel.Commands
{
    public class SafeWindowPlayerAssign : ICommand
    {
        private readonly IAgonizePlayerService _agonizePlayerService;
        private readonly PlayerAssignViewModel _viewModel;

        public SafeWindowPlayerAssign(PlayerAssignViewModel viewModel ,IAgonizePlayerService agonizePlayerService)
        {
            _agonizePlayerService = agonizePlayerService;
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
                _viewModel.targetTeam.AddPlayer(_viewModel.Player);
                _viewModel.SourceTeam.RemoveOnePlayerById(_viewModel.Player.Id);
            }
            _agonizePlayerService.CloseWindow();
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
