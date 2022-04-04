using AssetManagement.DesktopUI.Commands;
using AssetManagement.DesktopUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AssetManagement.DesktopUI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my application";

        public ICommand NavigateAccountCommand { get; }

        public HomeViewModel(INavigationService loginNavigationService)
        {
            //NavigateAccountCommand = new NavigateCommand(loginNavigationService);
        }
    }
}
