using AssetManagement.DesktopUI.Commands;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AssetManagement.DesktopUI.ViewModels
{
    public class ClientsViewModel : ViewModelBase
    {
        private readonly ClientData _clientData;

        public ClientsViewModel(ClientData clientData)
        {
            _clientData = clientData;
            DisplayClients();
            SaveClientCommand = new AddClientCommand(this, _clientData);
            DeleteClientCommand = new DeleteClientCommand(this, _clientData);
            UpdateClientCommand = new UpdateClientCommand(this, _clientData);
        }

        internal void DisplayClients()
        {
            Clients = new BindingList<FullClientModel>(_clientData.GetClients());
        }

        public ICommand SaveClientCommand { get; set; }
        public ICommand DeleteClientCommand { get; set; }
        public ICommand UpdateClientCommand { get; set; }

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
                if (value != null)
                {
                    _selectedClient = value;
                    SelectedClientName = value.ClientName;
                    SelectedClientAddress = value.Address;
                    SelectedClientFiscalCode = value.FiscalCode;
                    OnPropertyChanged(nameof(SelectedClient)); 
                }
            }
        }

        private string _selectedClientName;

        public string SelectedClientName
        {
            get { return _selectedClientName; }
            set 
            { 
                _selectedClientName = value;
                OnPropertyChanged(nameof(SelectedClientName));
            }
        }

        private string _selectedClientFiscalCode;

        public string SelectedClientFiscalCode
        {
            get { return _selectedClientFiscalCode; }
            set 
            {
                _selectedClientFiscalCode = value;
                OnPropertyChanged(nameof(SelectedClientFiscalCode));
            }
        }

        private string _selectedClientAddress;

        public string SelectedClientAddress
        {
            get { return _selectedClientAddress; }
            set 
            { 
                _selectedClientAddress = value;
                OnPropertyChanged(nameof(SelectedClientAddress));
            }
        }
    }
}
