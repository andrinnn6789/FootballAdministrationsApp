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
        private readonly IDialogService _dialogService;
        private readonly PlayerAssignViewModel _viewModel;

        public SafeWindowPlayerAssign(PlayerAssignViewModel viewModel ,IDialogService dialogService)
        {
            _dialogService = dialogService;
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
            _dialogService.CloseWindow();
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
