using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballAdministrationApp.View.Interfaces
{
    public interface IAgonizePlayerService
    {
        void CreateNewWindow(IFootballObject sourceObject, IFootballObject targetObject);
        void CloseWindow();
    }
}
