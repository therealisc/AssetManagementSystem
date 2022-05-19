using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using AssetManagement.DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagement.Library.Models;
using System.Windows;

namespace AssetManagement.DesktopUI.Commands
{
    internal class AddUserCommand : CommandBase
    {
        private UsersViewModel _viewModel;
        private readonly UserData _userData;

        public AddUserCommand(UsersViewModel viewModel, UserData userData)
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
                    Username = _viewModel.SelectedUserUsername,
                    Email = _viewModel.SelectedUserEmail,
                    PasswordHash = "ALZN+HSfh3PTKuEcdrion6b9LuLd96hZfb6si/OlEedzFiBAhMm/oUiqC3pLPBjQBw=="
                };

                _userData.AddUser(user, _viewModel.AssignedRoles.ToList(), _viewModel.AssignedClients.ToList());
                _viewModel.DisplayUsers();
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la adaugarea utilizatorului!");
            }

        }

        public override bool CanExecute(object parameter)
        {
            return string.IsNullOrWhiteSpace(_viewModel.SelectedUserUsername) == false &&
                string.IsNullOrWhiteSpace(_viewModel.SelectedUserEmail) == false && 
                _viewModel.AssignedRoles.Count > 0;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
