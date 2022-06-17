using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FootballAdministrationApp.Model;
using FootballAdministrationApp.View;
using FootballAdministrationApp.ViewModel;
using FootballAdministrationApp.ViewModel.ViewInterfaces;

namespace FootballAdministrationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IOpenWindowService
    {
        public MainWindow()
        {
            InitializeComponent();
            var teams = new ObservableCollection<Team>();
            var basicTeam = new Team("notAssignedPlayers", "offline");
            basicTeam.AddPlayer(new Player("1", "Moooin", 1, 1, 1, 1));
            basicTeam.AddPlayer(new Player("3", "Moooin", 1, 1, 1, 1));
            basicTeam.AddPlayer(new Player("4", "Moooin", 1, 1, 1, 1));
            teams.Add(new Team("Bayern","Deutschland"));
            teams[1].AddPlayer(new Player());
            teams[1].AddPlayer(new Player());
            teams.Add(new Team());
            DataContext = new MainWindowViewModel(teams, this, new PlayerAssign(), new PlayerWindow(), new TeamWindow(), basicTeam);
        }

        public void CreateNewPlayerAssignWindow(IPlayerAssignService playerAssignService, Team sourceObject, Team targetObject)
        { 
            playerAssignService.CreateNewWindow(sourceObject, targetObject);
        }

        public void CreateNewPlayerWindow(IPlayerWindowService playerWindowService, Team targetObject, Player currentPlayer)
        {
            playerWindowService.CreateNewWindow(targetObject, currentPlayer);
        }

        public void CreateNewTeamWindow(ITeamWindowService teamWindowService, ObservableCollection<Team> targetObject, Team currentTeam)
        {
            teamWindowService.CreateNewWindow(targetObject, currentTeam);
        }
    }
}
