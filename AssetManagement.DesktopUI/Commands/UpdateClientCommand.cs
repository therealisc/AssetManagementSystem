using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;

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
    }
}
