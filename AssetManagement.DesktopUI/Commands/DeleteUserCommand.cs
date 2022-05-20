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
    internal class DeleteUserCommand : CommandBase
    {
        private readonly UsersViewModel _viewModel;
        private readonly UserData _userData;

        public DeleteUserCommand(UsersViewModel viewModel, UserData userData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _userData = userData;
        }

        public override void Execute(object parameter)
        {
            _userData.DeleteUser(_viewModel.SelectedUser.Id);
            _viewModel.DisplayUsers();
            _viewModel.SelectedUser = _viewModel.Users.FirstOrDefault();
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedUser != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
