using AssetManagement.DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Stores
{
    public class AccountStore
    {
        private AccountModel _currentAccount;

        public AccountModel CurrentAccount
        {
            get { return _currentAccount; }
            set
            {
                _currentAccount = value;
                CurrentAccountChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;

        public event Action CurrentAccountChanged;

        internal void Logout()
        {
            CurrentAccount = null;
        }
    }
}
