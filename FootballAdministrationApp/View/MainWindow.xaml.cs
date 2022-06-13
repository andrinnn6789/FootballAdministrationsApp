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
using FootballAdministrationApp.View.Interfaces;
using FootballAdministrationApp.ViewModel;

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
            teams.Add(new Team());
            teams[0].AddPlayer(new Player("1", "Moooin", 1, 1, 1, 1));
            teams[0].AddPlayer(new Player("3", "Moooin", 1, 1, 1, 1));
            teams[0].AddPlayer(new Player("4", "Moooin", 1, 1, 1, 1));
            teams.Add(new Team("Bayern","Deutschland"));
            teams[1].AddPlayer(new Player());
            teams[1].AddPlayer(new Player());
            teams.Add(new Team());
            DataContext = new MainWindowViewModel(teams);
        }

        public void CreateNewWindow(IDialogService dialogService, IFootballObject sourceObject, IFootballObject targetObject)
        { 
            dialogService.CreateNewWindow(sourceObject, targetObject);
        }
    }
}
