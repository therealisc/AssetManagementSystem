using AssetManagement.DesktopUI.Commands;
using AssetManagement.DesktopUI.Services;
using AssetManagement.DesktopUI.Stores;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AssetManagement.DesktopUI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ClientData _clientData;
        private readonly AccountStore _accountStore;

        public HomeViewModel(ClientData clientData, AccountStore accountStore)
        {
            _clientData = clientData;
            _accountStore = accountStore;

            Clients = new BindingList<FullClientModel>(_clientData.GetClients(_accountStore.CurrentAccount.UserId));
        }
        public ICommand DepreciationCalculationCommand { get; set; }

        private BindingList<FullClientModel> _clients;

        public BindingList<FullClientModel> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        private FullClientModel _selectedClient;

        public FullClientModel SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        private DateTime _selectedDate = DateTime.Now;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }
    }
}
