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

        public void CreateNewWindow(IFootballObject sourceObject, IFootballObject targetObject)
        {
            var playerAssignViewModel = new PlayerAssignViewModel((Team) sourceObject, (Team) targetObject, this);
            this.DataContext = playerAssignViewModel;
            this.ShowDialog();
        }

        public void CloseWindow()
        {
            Close();
        }
    }
}
