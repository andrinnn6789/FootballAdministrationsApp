﻿using System;
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

        public SafeWindowPlayerAssign(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _dialogService.CloseWindow();
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
