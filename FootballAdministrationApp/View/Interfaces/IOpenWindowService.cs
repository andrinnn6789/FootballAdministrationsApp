using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballAdministrationApp.View.Interfaces
{
    public interface IOpenWindowService
    {
        IFootballObject CreateNewWindow(IDialogService dialogService, IFootballObject editObject);
    }
}
