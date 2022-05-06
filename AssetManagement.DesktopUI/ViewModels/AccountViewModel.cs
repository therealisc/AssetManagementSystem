using AssetManagement.DesktopUI.Commands;
using AssetManagement.DesktopUI.Models;
using AssetManagement.DesktopUI.Services.AuthentificationServices;
using AssetManagement.DesktopUI.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AssetManagement.DesktopUI.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public AccountViewModel(AccountStore accountstore, AuthentificationService authentificationService)
        {
            _accountStore = accountstore;
            ChangePasswordCommand = new ChangePasswordCommand(this, authentificationService);
        }

        public ICommand ChangePasswordCommand { get; }


        public AccountModel LoggedInUser
        {
            get { return _accountStore.CurrentAccount; }           
        }

        private string _newPassword;

        public string NewPassword
        {
            get { return _newPassword; }
            set 
            { 
                _newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }


        private string _reenteredPassword;

        public string ReenteredPassword
        {
            get { return _reenteredPassword; }
            set 
            { 
                _reenteredPassword = value;
                OnPropertyChanged(nameof(ReenteredPassword));
            }
        }

    }
}
