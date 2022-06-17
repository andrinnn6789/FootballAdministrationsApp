using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;
using FootballAdministrationApp.Model;
using FootballAdministrationApp.ViewModel.ViewInterfaces;

namespace FootballAdministrationApp.View
{
    /// <summary>
    /// Interaktionslogik für TeamWindow.xaml
    /// </summary>
    public partial class TeamWindow : Window, ITeamWindowService
    {
        public TeamWindow()
        {
            InitializeComponent();
        }

        public void CreateNewWindow(ObservableCollection<Team> targetObject)
        {
            ShowDialog();
        }

        public void CloseWindow()
        {
            Hide();
        }

        public bool EnterIsCorrect()
        {
            throw new NotImplementedException();
        }

        public List<string> ReturnValues()
        {
            throw new NotImplementedException();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            CloseWindow();
        }
    }
}
