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
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateFixedAssetsCommand { get; }
        public ICommand NavigateClasificationCodesCommand { get; }
        public ICommand NavigateDocumentsCommand { get; }
        public ICommand NavigateSuppliersCommand { get; }
        public ICommand NavigateClientsCommand { get; }
        public ICommand NavigateUsersCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand LogoutCommand { get; }

        public bool IsManager => _accountStore.CurrentAccount.Roles.Contains("Manager");
        public bool IsAccountant => _accountStore.CurrentAccount.Roles.Contains("Accountant");

        public NavigationBarViewModel(
            AccountStore accountStore,
            INavigationService homeNavigationService,
            INavigationService fixedAssetsNavigationService,
            INavigationService clasificationCodesNavigationService,
            INavigationService documentsNavigationService,
            INavigationService suppliersNavigationService,
            INavigationService clientsNavigationService,
            INavigationService usersNavigationService,
            INavigationService accountNavigationService,
            INavigationService loginNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateFixedAssetsCommand = new NavigateCommand(fixedAssetsNavigationService);
            NavigateClasificationCodesCommand = new NavigateCommand(clasificationCodesNavigationService);
            NavigateDocumentsCommand = new NavigateCommand(documentsNavigationService);
            NavigateSuppliersCommand = new NavigateCommand(suppliersNavigationService);
            NavigateClientsCommand = new NavigateCommand(clientsNavigationService);
            NavigateUsersCommand = new NavigateCommand(usersNavigationService);
            NavigateAccountCommand = new NavigateCommand(accountNavigationService);
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
            _accountStore = accountStore;
            LogoutCommand = new LogoutCommand(_accountStore, loginNavigationService);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            //OnPropertyChanged(nameof(IsLoggedIn));
        }

        internal override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;
            base.Dispose();
        }
    }
}
