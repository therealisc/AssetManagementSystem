using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.ViewModels
{
    public class ClientsViewModel : ViewModelBase
    {
        private readonly ClientData _clientData;

        public ClientsViewModel(ClientData clientData)
        {
            _clientData = clientData;
            Clients = new BindingList<ClientModel>(_clientData.GetClients());
        }

        private BindingList<ClientModel> _clients;

        public BindingList<ClientModel> Clients
        {
            get { return _clients; }
            set { _clients = value; }
        }

        private ClientModel _selectedClient;

        public ClientModel SelectedClient
        {
            get { return _selectedClient; }
            set 
            {
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

    }
}
