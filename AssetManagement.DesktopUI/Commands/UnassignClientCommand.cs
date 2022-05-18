using AssetManagement.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    internal class UnassignClientCommand : CommandBase
    {
        private UsersViewModel _viewModel;

        public UnassignClientCommand(UsersViewModel usersViewModel)
        {
            _viewModel = usersViewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            _viewModel.UnassignedClients.Add(_viewModel.SelectedAssignedClient);
            _viewModel.AssignedClients.Remove(_viewModel.SelectedAssignedClient);
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedAssignedClient != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
