using AssetManagement.DesktopUI.Models;
using AssetManagement.DesktopUI.Services;
using AssetManagement.DesktopUI.Stores;
using AssetManagement.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AssetManagement.DesktopUI.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly INavigationService _navigationService;

        public LoginCommand(LoginViewModel viewModel, AccountStore accountStore, INavigationService homeNavigationService)
        {
            _viewModel = viewModel;
            _accountStore = accountStore;
            _navigationService = homeNavigationService;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            //TODO: Check Password hash in the database

            AccountModel account = new()
            {
                //Email = $"{_viewModel.Username}.@test.com",
                Username = _viewModel.Username,
                Password = _viewModel.Password
            };

            _accountStore.CurrentAccount = account;

            _navigationService.Navigate();
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(_viewModel.Username) &&
                !string.IsNullOrWhiteSpace(_viewModel.Password);
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
