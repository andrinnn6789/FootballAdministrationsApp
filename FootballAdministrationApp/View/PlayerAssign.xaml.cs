using System;
using System.Collections.Generic;
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
using FootballAdministrationApp.View.Interfaces;
using FootballAdministrationApp.ViewModel;

namespace FootballAdministrationApp.View
{
    /// <summary>
    /// Interaktionslogik für PlayerAssign.xaml
    /// </summary>
    public partial class PlayerAssign : Window, IAgonizePlayerService
    {
        public PlayerAssign()
        {
            InitializeComponent();
        }

        public void CreateNewWindow(IFootballObject sourceObject, IFootballObject targetObject)
        {
            var playerAssignViewModel = new PlayerAssignViewModel((Team) sourceObject, (Team) targetObject, this);
            DataContext = playerAssignViewModel;
            ShowDialog();
        }

        public void CloseWindow()
        {
            Hide();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            CloseWindow();
        }
    }
}
