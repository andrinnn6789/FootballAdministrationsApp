using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using FootballAdministrationApp.Model;
using FootballAdministrationApp.ViewModel.Commands;
using FootballAdministrationApp.ViewModel.ViewInterfaces;
using Prism.Mvvm;

namespace FootballAdministrationApp.ViewModel
{
    public class TeamWindowViewModel : BindableBase
    {
        public ITeamWindowService _view;
        public ObservableCollection<Team> Teams;
        public Team CurrentTeam;
        private string _name;
        private string _country;

        public string Name
        {
            get => _name;
            set
            {
                if (SetProperty(ref _name, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_name)));
                }
            }
        }

        public string Country
        {
            get => _country;
            set
            {
                if (SetProperty(ref _country, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_country)));
                }
            }
        }

        public TeamWindowViewModel(ITeamWindowService view, ObservableCollection<Team> teams, Team currentTeam)
        {
            _view = view;
            Teams = teams;
            CurrentTeam = currentTeam;
            if (CurrentTeam != null)
            {
                Name = currentTeam.Name;
                Country = currentTeam.Country;
            }
            CloseWindow = new CloseWindowTeamWindow(_view);
            SaveWindow = new SaveWindowTeamWindow(this, _view);
        }

        public ICommand CloseWindow { get; }
        public ICommand SaveWindow { get; }
    }
}
