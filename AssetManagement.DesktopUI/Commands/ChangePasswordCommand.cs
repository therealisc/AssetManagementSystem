using AssetManagement.DesktopUI.Services.AuthentificationServices;
using AssetManagement.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace AssetManagement.DesktopUI.Commands
{
    public class ChangePasswordCommand : CommandBase
    {
        private AccountViewModel _viewModel;
        private readonly AuthentificationService _authentificationService;
        public ChangePasswordCommand(AccountViewModel accountViewModel, AuthentificationService authentificationService)
        {
            _viewModel = accountViewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _authentificationService = authentificationService;
        }
        public override void Execute(object parameter)
        {
            try
            {
                ValidatePassword(_viewModel.ReenteredPassword);
                _authentificationService.ChangePassword(_viewModel.LoggedInUser.UserId, _viewModel.ReenteredPassword);
                _viewModel.NewPassword = string.Empty;
                _viewModel.ReenteredPassword = string.Empty;
                MessageBox.Show("Parola a fost modificata cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(_viewModel.NewPassword) &&
                !string.IsNullOrWhiteSpace(_viewModel.ReenteredPassword) &&
                _viewModel.NewPassword == _viewModel.ReenteredPassword;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        private void ValidatePassword(string password)
        {
            if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,30}$") == false)
            {
                throw new Exception("Parola trebuie sa contina intre 8 si 30 de caractere, un numar si un caracter special!");
            }
        }
    }
}
