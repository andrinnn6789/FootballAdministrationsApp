using System.Collections.Generic;
using FootballAdministrationApp.Model;

namespace FootballAdministrationApp.ViewModel.ViewInterfaces
{
    public interface IPlayerWindowService
    {
        void CreateNewWindow(Team targetObject, Player currentPlayer);
        void CloseWindow();
    }
}
