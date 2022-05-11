using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    public class DeleteClientCommand : CommandBase
    {
        private readonly ClientsViewModel _viewModel;
        private readonly ClientData _clientData;

        public DeleteClientCommand(ClientsViewModel viewModel, ClientData clientData)
        {
            _clientData = clientData;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _clientData.DeleteClient(_viewModel.SelectedClient);

            _viewModel.DisplayClients();
        }
    }
}
