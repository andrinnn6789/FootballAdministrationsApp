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
    public class AgonizePlayerCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public AgonizePlayerCommand(MainWindowViewModel viewModel)
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
            OnCanExecuteChanged();
            IOpenWindowService dialog = new MainWindow();
            dialog.CreateNewWindow(new PlayerAssign(), _viewModel.Teams[0]);
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
