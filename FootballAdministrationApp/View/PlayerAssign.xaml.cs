using System;
using System.Collections.Generic;
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
using FootballAdministrationApp.View.Interfaces;
using FootballAdministrationApp.ViewModel;

namespace FootballAdministrationApp.View
{
    /// <summary>
    /// Interaktionslogik für PlayerAssign.xaml
    /// </summary>
    public partial class PlayerAssign : Window, IDialogService
    {
        public PlayerAssign()
        {
            InitializeComponent();
        }

        public void CreateNewWindow(IFootballObject editObject)
        {
            var playerAssignViewModel = new PlayerAssignViewModel((Team) editObject, this);
            this.DataContext = playerAssignViewModel;
            this.ShowDialog();
            /*
            Team team = (Team)editObject;
            var idString = string.Empty;
            foreach (var currentChar in availablePlayers.SelectedItem.ToString())
            {
                if (currentChar == ' ')
                    break;
                idString += currentChar.ToString();
            }
            
            return team.GetOnePlayerById(Convert.ToInt32(idString));*/
        }

        public void CloseWindow()
        {
            Close();
        }
    }
}
