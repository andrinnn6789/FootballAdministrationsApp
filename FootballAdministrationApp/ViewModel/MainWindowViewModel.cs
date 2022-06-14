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
using FootballAdministrationApp.View.Interfaces;
using FootballAdministrationApp.ViewModel.Commands;
using Prism.Mvvm;

namespace FootballAdministrationApp.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        public IOpenWindowService View;
        public IAgonizePlayerService AgonizePlayerView;
        public ObservableCollection<Player> players;
        public ObservableCollection<Player> availablePlayers;
        public ObservableCollection<Team> teams;
        private Player _player;
        private Player _availablePlayer;
        private Team _team;
        private string _teamName;
        private string _teamCountry;

        public ObservableCollection<Player> Players
        {
            get => players;
            set
            {
                if (SetProperty(ref players, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(players)));
                }
            }
        }

        public ObservableCollection<Player> AvailablePlayers
        {
            get => availablePlayers;
            set
            {
                if (SetProperty(ref availablePlayers, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(availablePlayers)));
                }
            }
        }

        public ObservableCollection<Team> Teams
        {
            get
            {
                var teams = new ObservableCollection<Team>();
                foreach (var team in this.teams)
                {
                    if (team.Id != 0)
                        teams.Add(team);
                }

                return teams;
            }
            set
            {
                if (SetProperty(ref teams, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(teams)));
                }
            }
        }
        public Player Player
        {
            get => _player;
            set
            {
                if (SetProperty(ref _player, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_player)));
                }
            }
        }

        public Player AvailablePlayer
        {
            get => _availablePlayer;
            set
            {
                if (SetProperty(ref _availablePlayer, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_availablePlayer)));
                }
            }
        }

        public Team Team
        {
            get => _team;
            set
            {
                if (SetProperty(ref _team, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_team)));
                    RefreshCurrentTeam(Team);
                }
            }
        }

        public string TeamName
        {
            get => _teamName;
            set
            {
                if (SetProperty(ref _teamName, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_teamName)));
                }
            }
        }

        public string TeamCountry
        {
            get => _teamCountry;
            set
            {
                if (SetProperty(ref _teamCountry, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_teamCountry)));
                }
            }
        }

        public MainWindowViewModel(ObservableCollection<Team> teams, IOpenWindowService view, IAgonizePlayerService agonizePlayerViewView)
        {
            View = view;
            AgonizePlayerView = agonizePlayerViewView;
            if (Team != null) RefreshCurrentTeam(teams[Team.Id]);
            availablePlayers = teams[0].GetPlayers();
            this.teams = teams;
            AddOrModifyPlayerCommand = new AddPlayerCommand(this);
            AddOrModifyTeamCommand = new AddTeamCommand(this);
            AgonizePlayerCommand = new AgonizePlayerCommand(this);
        }

        private void RefreshCurrentTeam(Team team)
        {
            Players = team.GetPlayers();
            TeamName = team.Name;
            TeamCountry = team.Country;
        }

        public ICommand AddOrModifyPlayerCommand { get; }
        public ICommand AddOrModifyTeamCommand { get; }
        public ICommand AgonizePlayerCommand { get; }
    }
}
