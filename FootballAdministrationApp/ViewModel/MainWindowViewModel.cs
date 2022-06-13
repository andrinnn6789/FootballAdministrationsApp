using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
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
        private ObservableCollection<Player> _availablePlayers;
        private ObservableCollection<Team> _teams;

        public ObservableCollection<Player> Players
        {
            get { return _players; }
            set
            {
                if (SetProperty(ref _players, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_players)));
                }
            }
        }

        public ObservableCollection<Player> AvailablePlayers
        {
            get { return _availablePlayers; }
            set
            {
                if (SetProperty(ref _availablePlayers, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_availablePlayers)));
                }
            }
        }

        public ObservableCollection<Team> Teams
        {
            get
            {
                var teams = new ObservableCollection<Team>();
                foreach (var team in _teams)
                {
                    if (team.Id != 0)
                        teams.Add(team);
                }

                return teams;
            }
            set
            {
                if (SetProperty(ref _teams, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_teams)));
                }
            }
        }

        public MainWindowViewModel(ObservableCollection<Team> teams)
        {
            _players = teams[0].GetPlayers();
            _availablePlayers = teams[0].GetPlayers();
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
