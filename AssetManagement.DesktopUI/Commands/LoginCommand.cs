using AssetManagement.DesktopUI.Models;
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
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly INavigationService _navigationService;

        public LoginCommand(LoginViewModel viewModel, AccountStore accountStore, INavigationService navigationService)
        {
            _viewModel = viewModel;
            _accountStore = accountStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            AccountModel account = new()
            {
                Email = $"{_viewModel.Username}.@test.com",
                Username = _viewModel.Username
            };

            _accountStore.CurrentAccount = account;

            _navigationService.Navigate();
        }
    }
}
