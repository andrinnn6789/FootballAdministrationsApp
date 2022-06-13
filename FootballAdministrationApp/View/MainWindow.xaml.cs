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
            var players = new ObservableCollection<Player>();
            var teams = new ObservableCollection<Team>();
            DataContext = new MainWindowViewModel(players, teams);
        }

        public void CreateNewWindow(IDialogService dialogService, IFootballObject editObject)
        { 
            dialogService.CreateNewWindow(editObject);
        }
    }
}
