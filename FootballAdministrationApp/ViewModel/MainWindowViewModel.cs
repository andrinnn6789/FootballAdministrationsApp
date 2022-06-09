using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FootballAdministrationApp.Model;
using FootballAdministrationApp.ViewModel.Commands;
using Prism.Mvvm;

namespace FootballAdministrationApp.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private LinkedList<Player> _players;
        private LinkedList<Team> _teams;

        public MainWindowViewModel(LinkedList<Player> players, LinkedList<Team> teams)
        {
            _players = players;
            _teams = teams;
            AddOrModifyPlayerCommand = new AddOrModifyPlayerCommand(this);
            AddOrModifyTeamCommand = new AddOrModifyTeamCommand(this);
            AgonizePlayerCommand = new AgonizePlayerCommand(this);
        }

        public ICommand AddOrModifyPlayerCommand { get; }
        public ICommand AddOrModifyTeamCommand { get; }
        public ICommand AgonizePlayerCommand { get; }
    }
}
