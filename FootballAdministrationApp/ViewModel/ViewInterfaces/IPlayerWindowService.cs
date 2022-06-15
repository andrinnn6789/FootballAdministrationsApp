using System.Collections.Generic;
using FootballAdministrationApp.Model;

namespace FootballAdministrationApp.ViewModel.ViewInterfaces
{
    public interface IPlayerWindowService
    {
        void CreateNewWindow(Team targetObject);
        void CloseWindow();
        bool EnterIsCorrect();
        List<string> ReturnValues();
    }
}
