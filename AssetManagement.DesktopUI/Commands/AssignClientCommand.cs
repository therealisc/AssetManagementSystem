using AssetManagement.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    internal class AssignClientCommand : CommandBase
    {
        private UsersViewModel _viewModel;

        public AssignClientCommand(UsersViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            _viewModel.AssignedClients.Add(_viewModel.SelectedUnassignedClient);
            _viewModel.UnassignedClients.Remove(_viewModel.SelectedUnassignedClient);
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedUnassignedClient != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
