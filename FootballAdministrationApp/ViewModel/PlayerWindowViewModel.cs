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
        private string _first;
        private string _last;
        private string _age;
        private string _weight;
        private string _size;
        private string _market;

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

        public string Age
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

        public string WeightInKg
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

        public string SizeInCm
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

        public string MarketValue
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

        public PlayerWindowViewModel(IPlayerWindowService view, Team targetTeam)
        {
            _view = view;
            TargetTeam = targetTeam;
            CloseWindow = new CloseWindowPlayerWindow(_view);
            SafeWindow = new SafeWindowPlayerWindow(this, _view);
        }

        public ICommand CloseWindow { get; }
        public ICommand SafeWindow { get; }
    }
}
