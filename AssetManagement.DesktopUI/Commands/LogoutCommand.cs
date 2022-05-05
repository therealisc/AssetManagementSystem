using AssetManagement.DesktopUI.Services;
using AssetManagement.DesktopUI.Stores;
using AssetManagement.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    internal class LogoutCommand : CommandBase
    {
        private readonly AccountStore _accountStore;
        private readonly INavigationService _homeNavigationService;

        public LogoutCommand(AccountStore accountStore, INavigationService homeNavigationService)
        {
            _accountStore = accountStore;
            _homeNavigationService = homeNavigationService;
        }

        public override void Execute(object parameter)
        {
            _accountStore.Logout();
            _homeNavigationService.Navigate();
        }
    }
}
