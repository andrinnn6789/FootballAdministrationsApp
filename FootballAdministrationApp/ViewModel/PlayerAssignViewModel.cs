using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FootballAdministrationApp.Model;
using FootballAdministrationApp.View;
using FootballAdministrationApp.View.Interfaces;
using FootballAdministrationApp.ViewModel.Commands;
using Prism.Mvvm;

namespace FootballAdministrationApp.ViewModel
{
    public class PlayerAssignViewModel : BindableBase
    {
        private Team _team;
        private readonly IDialogService _view;
        private ObservableCollection<Player> _players;
        private Player _player;

        public ObservableCollection<Player> Players
        {
            get { return _players; }
            private set
            {
                if (SetProperty(ref _players, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_players)));
                }
            }
        }

        public Player Player
        {
            get { return _player; }
            set
            {
                if (SetProperty(ref _player, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_player)));
                }
            }
        }

        public Team Team
        {
            get { return _team; }
            set
            {
                if (SetProperty(ref _team, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_team)));
                }
            }
        }

        public PlayerAssignViewModel(Team team, PlayerAssign view)
        {
            _team = team;
            _players = team.GetPlayers();
            _view = view ?? throw new ArgumentNullException(nameof(view));
            CloseWindow = new CloseWindow(view);
            SafeWindowPlayerAssign = new SafeWindowPlayerAssign(this, view);
        }

        public ICommand CloseWindow { get; }
        public ICommand SafeWindowPlayerAssign { get; }
    }
}
