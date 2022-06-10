using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Player> _players;
        private ObservableCollection<Team> _teams;

        public ObservableCollection<Player> Players
        {
            get { return _players; }
        }
        public ObservableCollection<Team> Teams
        {
            get { return _teams; }
        }

        public MainWindowViewModel(ObservableCollection<Player> players, ObservableCollection<Team> teams)
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
