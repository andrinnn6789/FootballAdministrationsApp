using System.Windows;
using MVVM_Vorlage.Models;
using MVVM_Vorlage.ViewModels;

namespace MVVM_Vorlage
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Window
    {
        public View()
        {
            InitializeComponent();
            var userViewModel = new UserViewModel(new UserModel());
            DataContext = userViewModel;
        }
    }
}
 