using FootballAdministrationApp.Model;

namespace FootballAdministrationApp.ViewModel.ViewInterfaces
{
    public interface IPlayerAssignService
    {
        void CreateNewWindow(Team sourceObject, Team targetObject);
        void CloseWindow();
    }
}
