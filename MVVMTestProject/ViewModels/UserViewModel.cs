using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MVVM_Vorlage.HelpClasses;
using MVVM_Vorlage.Models;
using Prism.Mvvm;

namespace MVVM_Vorlage.ViewModels
{
    public class UserViewModel : BindableBase
    {
        private string _first;
        private string _last;
        public ObservableCollection<UserViewModel> users;


        public ObservableCollection<UserViewModel> Users
        {
            get { return users;}
            private set
            {
                if (SetProperty(ref users, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(users)));
                }
            }
        }
        public UserViewModel(UserModel userModel)
        {
            _first = userModel.FirstName;
            _last = userModel.LastName;
            ChangeName = new ChangeName(this);
            Users = new ObservableCollection<UserViewModel>();
        }

        public string FirstName
        {
            get => _first;
            set
            {
                if (SetProperty(ref _first, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(FormattedName)));
                }
            }
        }
        public string LastName
        {
            get => _last;
            set
            {
                if (SetProperty(ref _last, value))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(FormattedName)));
                }
            }
        }

        public ICommand ChangeName { get; }
        public string FormattedName => $"{_first} {_last}";
    }
}
