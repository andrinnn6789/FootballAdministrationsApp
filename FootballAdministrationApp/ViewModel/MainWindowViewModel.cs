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
using FootballAdministrationApp.ViewModel.ViewInterfaces;
using Prism.Mvvm;

namespace FootballAdministrationApp.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        public IOpenWindowService View;
        public IPlayerAssignService PlayerAssignView;
        public IPlayerWindowService PlayerWindowView;
        public ITeamWindowService TeamWindowView;
        public ObservableCollection<Player> players;
        public ObservableCollection<Player> availablePlayers;
        public ObservableCollection<Team> teams;
        private Player _player;
        private Player _availablePlayer;
        private Team _team;
        private string _teamName;
        private string _teamCountry;

        public Team BasicTeam { get; set;}

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
            get => teams;
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

        private void RefreshCurrentTeam(Team team)
        {
            Players = team.GetPlayers();
            TeamName = team.Name;
            TeamCountry = team.Country;
        }

        public void RefreshAvailablePlayers()
        {
            AvailablePlayers = basicTeam.GetPlayers();
        }


        public MainWindowViewModel(ObservableCollection<Team> teams, IOpenWindowService view, IPlayerAssignService playerAssignView, IPlayerWindowService playerWindow, ITeamWindowService teamWindow, Team basicTeam)
        {
            BasicTeam = basicTeam;
            View = view;
            PlayerAssignView = playerAssignView;
            PlayerWindowView = playerWindow;
            TeamWindowView = teamWindow;
            if (Team != null) RefreshCurrentTeam(teams[Team.Id]);
            availablePlayers = basicTeam.GetPlayers();
            this.teams = teams;
            AddAvailablePlayerCommand = new AddAvailablePlayerCommand(this);
            ModifyAvailablePlayerCommand = new ModifyAvailablePlayerCommand(this);
            DeleteAvailablePlayerCommand = new DeleteAvailablePlayerCommand(this);
            AddTeamCommand = new AddTeamCommand(this);
            AssignPlayerCommand = new PlayerAssignCommand(this);
            RemovePlayerCommand = new RemovePlayerCommand(this);
        }


        public ICommand AddAvailablePlayerCommand { get; }
        public ICommand ModifyAvailablePlayerCommand { get; }
        public ICommand DeleteAvailablePlayerCommand { get; }
        public ICommand AddTeamCommand { get; }
        public ICommand AssignPlayerCommand { get; }
        public ICommand RemovePlayerCommand { get; }
    }
}
