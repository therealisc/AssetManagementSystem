using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    public class AddClientCommand : CommandBase
    {

        private readonly ClientData _clientData;
        private readonly ClientsViewModel _viewModel;

        public AddClientCommand(ClientsViewModel viewModel, ClientData clientData)
        {
            _clientData = clientData;
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            FullClientModel client = new FullClientModel()
            {
                ClientName = _viewModel.SelectedClientName,
                FiscalCode = _viewModel.SelectedClientFiscalCode,
                Address = _viewModel.SelectedClientAddress
            };

            _clientData.AddClient(client);
            _viewModel.DisplayClients();
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
