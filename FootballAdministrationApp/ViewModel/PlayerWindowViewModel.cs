using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FootballAdministrationApp.Model;
using FootballAdministrationApp.ViewModel.Commands;
using FootballAdministrationApp.ViewModel.ViewInterfaces;
using Prism.Mvvm;

namespace FootballAdministrationApp.ViewModel
{
    public class PlayerWindowViewModel : BindableBase
    {
        public IPlayerWindowService _view;
        public Team TargetTeam;
        public Player CurrentPlayer;
        private string _first;
        private string _last;
        private int _age;
        private int _weight;
        private int _size;
        private double _market;

        public string FirstName
        {
            get => _first;
            set
            {
                if (SetProperty(ref _first, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_first)));
                }
            }
        }

        public string LastName
        {
            get => _last;
            set
            {
                if (SetProperty(ref _last, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_last)));
                }
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (SetProperty(ref _age, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_age)));
                }
            }
        }

        public int WeightInKg
        {
            get => _weight;
            set
            {
                if (SetProperty(ref _weight, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_weight)));
                }
            }
        }

        public int SizeInCm
        {
            get => _size;
            set
            {
                if (SetProperty(ref _size, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_size)));
                }
            }
        }

        public double MarketValue
        {
            get => _market;
            set
            {
                if (SetProperty(ref _market, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_market)));
                }
            }
        }

        public PlayerWindowViewModel(IPlayerWindowService view, Team targetTeam, Player currentPlayer)
        {
            _view = view;
            TargetTeam = targetTeam;
            CurrentPlayer = currentPlayer;
            if (CurrentPlayer != null)
            {
                FirstName = CurrentPlayer.FirstName;
                LastName = CurrentPlayer.LastName;
                Age = CurrentPlayer.Age;
                WeightInKg = CurrentPlayer.WeightInKg;
                SizeInCm = CurrentPlayer.SizeInCm;
                MarketValue = CurrentPlayer.MarketValue;
            }
            CloseWindow = new CloseWindowPlayerWindow(_view);
            SaveWindow = new SaveWindowPlayerWindow(this, _view);
        }

        public ICommand CloseWindow { get; }
        public ICommand SaveWindow { get; }
    }
}
