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
    public class SaveWindowPlayerWindow : ICommand
    {
        private readonly IPlayerWindowService _playerAssignService;
        private readonly PlayerWindowViewModel _viewModel;

        public SaveWindowPlayerWindow(PlayerWindowViewModel viewModel , IPlayerWindowService playerAssignService)
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
            if (_viewModel.CurrentPlayer == null)
            {
                _viewModel.TargetTeam.AddPlayer(new Player(_viewModel.FirstName, _viewModel.LastName, _viewModel.Age, _viewModel.WeightInKg, _viewModel.SizeInCm, _viewModel.MarketValue));
            }
            else
            {
                _viewModel.CurrentPlayer.FirstName = _viewModel.FirstName;
                _viewModel.CurrentPlayer.LastName = _viewModel.LastName;
                _viewModel.CurrentPlayer.Age = _viewModel.Age;
                _viewModel.CurrentPlayer.WeightInKg = _viewModel.WeightInKg;
                _viewModel.CurrentPlayer.SizeInCm = _viewModel.SizeInCm;
                _viewModel.CurrentPlayer.MarketValue = _viewModel.MarketValue;
                _viewModel.TargetTeam.AddPlayer(_viewModel.CurrentPlayer);
                _viewModel.TargetTeam.RemoveOnePlayerById(_viewModel.CurrentPlayer.Id);
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
