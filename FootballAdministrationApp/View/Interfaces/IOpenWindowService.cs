using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballAdministrationApp.View.Interfaces
{
    public interface IOpenWindowService
    {
        void CreateNewWindow(IDialogService dialogService, IFootballObject editObject);
    }
}
