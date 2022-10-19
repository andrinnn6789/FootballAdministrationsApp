﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using FootballAdministrationApp.ViewModel.ViewInterfaces;

namespace FootballAdministrationApp.ViewModel.Commands
{
    public class AddAvailablePlayerCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public AddAvailablePlayerCommand(MainWindowViewModel viewModel)
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
            IOpenWindowService dialog = _viewModel.View;
            dialog.CreateNewPlayerWindow(_viewModel.PlayerWindowView, _viewModel.BasicTeam, null);
            _viewModel.AvailablePlayer = _viewModel.AvailablePlayers.FirstOrDefault();
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}