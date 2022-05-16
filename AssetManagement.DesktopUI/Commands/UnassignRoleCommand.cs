using AssetManagement.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    internal class UnassignRoleCommand : CommandBase
    {
        private UsersViewModel _viewModel;

        public UnassignRoleCommand(UsersViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            _viewModel.UnassignedRoles.Add(_viewModel.SelectedAssignedRole);
            _viewModel.AssignedRoles.Remove(_viewModel.SelectedAssignedRole);
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedAssignedRole != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
