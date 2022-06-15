using System.Collections.ObjectModel;
using FootballAdministrationApp.Model;

namespace FootballAdministrationApp.ViewModel.ViewInterfaces
{
    public interface IOpenWindowService
    {
        void CreateNewPlayerAssignWindow(IPlayerAssignService playerAssignService, Team sourceObject, Team targetObject);
        void CreateNewPlayerWindow(IPlayerWindowService playerWindowService, Team targetObject);
        void CreateNewTeamWindow(ITeamWindowService teamWindowService, ObservableCollection<Team> targetObject);
    }
}
