using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AssetManagement.DesktopUI.Commands
{
    internal class UpdateUserCommand : CommandBase
    {
        private readonly UsersViewModel _viewModel;
        private readonly UserData _userData;

        public UpdateUserCommand(UsersViewModel viewModel, UserData userData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _userData = userData;
        }

        public override void Execute(object parameter)
        {
            try
            {
                UserModel user = new UserModel()
                {
                    Id = _viewModel.SelectedUser.Id,
                    Username = _viewModel.SelectedUserUsername,
                    Email = _viewModel.SelectedUserEmail,
                };

                _userData.UpdateUser(user, _viewModel.AssignedRoles.ToList(), _viewModel.AssignedClients.ToList());
                _viewModel.DisplayUsers();
                _viewModel.SelectedUser = _viewModel.Users.FirstOrDefault();
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la modificarea utilizatorului!");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedUser != null &&
                string.IsNullOrWhiteSpace(_viewModel.SelectedUserUsername) == false &&
                string.IsNullOrWhiteSpace(_viewModel.SelectedUserEmail) == false &&
                _viewModel.AssignedRoles.Count > 0 &&
                _viewModel.AssignedClients.Count > 0;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
