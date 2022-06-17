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
using FootballAdministrationApp.ViewModel;
using FootballAdministrationApp.ViewModel.ViewInterfaces;

namespace FootballAdministrationApp.View
{
    /// <summary>
    /// Interaktionslogik für PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window, IPlayerWindowService
    {
        public PlayerWindow()
        {
            InitializeComponent();
        }

        public void CreateNewWindow(Team targetObject, Player currentPlayer)
        {
            var playerWindowViewModel = new PlayerWindowViewModel(this, targetObject, currentPlayer);
            DataContext = playerWindowViewModel;
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
