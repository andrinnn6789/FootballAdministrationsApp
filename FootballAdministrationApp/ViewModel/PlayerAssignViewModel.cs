﻿using System;
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
        private Team _sourceTeam;
        private readonly IDialogService _view;
        private ObservableCollection<Player> _players;
        private Player _player;
        public Team targetTeam { get; set; }

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

        public Team SourceTeam
        {
            get { return _sourceTeam; }
            set
            {
                if (SetProperty(ref _sourceTeam, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_sourceTeam)));
                }
            }
        }

        public PlayerAssignViewModel(Team sourceTeam, Team targetTeam,IDialogService view)
        {
            _sourceTeam = sourceTeam;
            this.targetTeam = targetTeam;
            _players = sourceTeam.GetPlayers();
            _view = view ?? throw new ArgumentNullException(nameof(view));
            CloseWindow = new CloseWindow(view);
            SafeWindowPlayerAssign = new SafeWindowPlayerAssign(this, view);
        }

        public ICommand CloseWindow { get; }
        public ICommand SafeWindowPlayerAssign { get; }
    }
}