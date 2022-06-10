using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FootballAdministrationApp.Model;
using FootballAdministrationApp.View;
using FootballAdministrationApp.ViewModel.Commands;
using Prism.Mvvm;

namespace FootballAdministrationApp.ViewModel
{
    public class PlayerAssignViewModel : BindableBase
    {
        private Team _team;
        private readonly PlayerAssign _view;

        public Team Team
        {
            get { return _team; }
            set { SetProperty(ref _team, value); }
        }

        public PlayerAssignViewModel(Team team, PlayerAssign view)
        {
            _team = team;
            _view = view ?? throw new ArgumentNullException(nameof(view));
            CloseWindow = new CloseWindow(view);
        }

        public ICommand CloseWindow { get; }
    }
}
