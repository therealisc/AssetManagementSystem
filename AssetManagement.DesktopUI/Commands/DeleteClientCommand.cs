using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            _clientData.DeleteClient(_viewModel.SelectedClient);

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
