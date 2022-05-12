﻿using AssetManagement.DesktopUI.Commands;
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
        public ICommand NavigateClientsCommand { get; set; }
        public ICommand NavigateUsersCommand { get; set; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand LogoutCommand { get; }

        public bool IsLoggedIn => _accountStore.IsLoggedIn;

        public NavigationBarViewModel(
            AccountStore accountStore,
            INavigationService homeNavigationService,
            INavigationService clientsNavigationService,
            INavigationService usersNavigationService,
            INavigationService accountNavigationService,
            INavigationService loginNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
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
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        internal override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;
            base.Dispose();
        }
    }
}
