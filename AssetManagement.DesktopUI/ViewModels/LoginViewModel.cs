using AssetManagement.DesktopUI.Commands;
using AssetManagement.DesktopUI.Services;
using AssetManagement.DesktopUI.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AssetManagement.DesktopUI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }


        private string _password = "asdf";

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(AccountStore accountStore, INavigationService homeNavigationService)
        {
            LoginCommand = new LoginCommand(this, accountStore, homeNavigationService);
        }

    }
}
