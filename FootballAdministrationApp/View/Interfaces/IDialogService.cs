using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballAdministrationApp.View.Interfaces
{
    public interface IDialogService
    {
        IFootballObject CreateNewWindow(IFootballObject editObject);
        void CloseWindow();
        void SafeWindow();
    }
}
