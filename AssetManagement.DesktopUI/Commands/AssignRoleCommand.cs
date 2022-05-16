using AssetManagement.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    internal class AssignRoleCommand : CommandBase
    {
        private UsersViewModel _viewModel;

        public AssignRoleCommand(UsersViewModel usersViewModel)
        {
            _viewModel = usersViewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            _viewModel.AssignedRoles.Add(_viewModel.SelectedUnassigedRole);
            _viewModel.UnassignedRoles.Remove(_viewModel.SelectedUnassigedRole);
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedUnassigedRole != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
