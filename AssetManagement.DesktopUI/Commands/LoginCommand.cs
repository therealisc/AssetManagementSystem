using AssetManagement.DesktopUI.Models;
using AssetManagement.DesktopUI.Services;
using AssetManagement.DesktopUI.Services.AuthentificationServices;
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
        private readonly AuthentificationService _authentificationService;

        public LoginCommand(LoginViewModel viewModel, AccountStore accountStore, INavigationService homeNavigationService, AuthentificationService authentificationService)
        {
            _viewModel = viewModel;
            _accountStore = accountStore;
            _navigationService = homeNavigationService;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _authentificationService = authentificationService;
        }

        public override void Execute(object parameter)
        {
            try
            {
                AccountModel account = _authentificationService.Login(_viewModel.Username, _viewModel.Password);
                _accountStore.CurrentAccount = account;
                _viewModel.WrongCredentials = false;
            }
            catch (Exception ex) when (ex.Message == "PasswordVerificationFailed")
            {
                _viewModel.WrongCredentials = true;
                return;
            }

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
