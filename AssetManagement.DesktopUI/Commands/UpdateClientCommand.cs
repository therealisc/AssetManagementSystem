using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System.ComponentModel;

namespace AssetManagement.DesktopUI.Commands
{
    public class UpdateClientCommand : CommandBase
    {
        private readonly ClientsViewModel _viewModel;
        private readonly ClientData _clientData;

        public UpdateClientCommand(ClientsViewModel viewModel, ClientData clientData)
        {
            _viewModel = viewModel;
            _clientData = clientData;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            FullClientModel client = new FullClientModel
            {
                Id = _viewModel.SelectedClient.Id,
                ClientName = _viewModel.SelectedClientName,
                FiscalCode = _viewModel.SelectedClientFiscalCode, 
                Address = _viewModel.SelectedClientAddress
            };

            _clientData.UpdateClient(client);
            _viewModel.DisplayClients();
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedClient != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
