using System.Collections.Generic;
using System.Collections.ObjectModel;
using FootballAdministrationApp.Model;

namespace FootballAdministrationApp.ViewModel.ViewInterfaces
{
    public interface ITeamWindowService
    {
        void CreateNewWindow(ObservableCollection<Team> targetObject);
        void CloseWindow();
        bool EnterIsCorrect();
        List<string> ReturnValues();
    }
}
