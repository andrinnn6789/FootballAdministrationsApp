using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM_Vorlage.Models;
using MVVM_Vorlage.ViewModels;

namespace MVVM_Vorlage.HelpClasses
{
    public class ChangeName : ICommand
    {
        private readonly UserViewModel _viewModel;

        public ChangeName(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _viewModel.FormattedName.Length < 20;
        }

        public void Execute(object parameter)
        {
            var viewModel = new UserViewModel(new UserModel(_viewModel.FirstName,_viewModel.LastName));
            _viewModel.Users.Add(viewModel);
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
