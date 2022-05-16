using AssetManagement.DesktopUI.Commands;
using AssetManagement.DesktopUI.Models;
using AssetManagement.DesktopUI.Services;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AssetManagement.DesktopUI.ViewModels
{
    internal class UsersViewModel : ViewModelBase
    {
        private readonly UserData _userData;
        private readonly UsersMappingService _usersMappingService;

        public UsersViewModel(UserData userData, UsersMappingService mappingService)
        {
            _userData = userData;
            _usersMappingService = mappingService;
            DisplayUsers();
            AssignRoleCommand = new AssignRoleCommand(this);
            UnassignRoleCommand = new UnassignRoleCommand(this);
        }

        private void DisplayUsers()
        {
            Users = new BindingList<UserDisplayModel>(_usersMappingService.MapToUserDisplayModel(_userData.GetUsers()));
        }

        public ICommand AssignRoleCommand { get; set; }
        public ICommand UnassignRoleCommand { get; set; }

        private BindingList<UserDisplayModel> _users;

        public BindingList<UserDisplayModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private UserDisplayModel _selectedUser;

        public UserDisplayModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (value != null)
                {
                    _selectedUser = value;
                    SelectedUserUsername = value.Username;
                    SelectedUserEmail = value.Email;
                    AssignedRoles = new BindingList<RoleModel>(value.Roles);
                    SelectedUserClients = new BindingList<string>(value.Clients);

                    UnassignedRoles = new BindingList<RoleModel>(_userData.GetUnassignedRoles(value.Id));

                    OnPropertyChanged(nameof(SelectedUser));
                }
            }
        }

        private string _selectedUserUsername;

        public string SelectedUserUsername
        {
            get { return _selectedUserUsername; }
            set
            {
                _selectedUserUsername = value;
                OnPropertyChanged(nameof(SelectedUserUsername));
            }
        }

        private string _selectedUserEmail;

        public string SelectedUserEmail
        {
            get { return _selectedUserEmail; }
            set
            {
                _selectedUserEmail = value;
                OnPropertyChanged(nameof(SelectedUserEmail));
            }
        }

        private BindingList<RoleModel> _assignedRoles;

        public BindingList<RoleModel> AssignedRoles
        {
            get { return _assignedRoles; }
            set
            {
                _assignedRoles = value;
                OnPropertyChanged(nameof(AssignedRoles));
            }
        }

        private RoleModel _selectedAssignedRole;

        public RoleModel SelectedAssignedRole
        {
            get { return _selectedAssignedRole; }
            set
            {
                _selectedAssignedRole = value;
                OnPropertyChanged(nameof(SelectedAssignedRole));
            }
        }


        private BindingList<string> _selectedUserClients;

        public BindingList<string> SelectedUserClients
        {
            get { return _selectedUserClients; }
            set
            {
                _selectedUserClients = value;
                OnPropertyChanged(nameof(SelectedUserClients));
            }
        }

        private BindingList<RoleModel> _unassignedRoles;

        public BindingList<RoleModel> UnassignedRoles
        {
            get { return _unassignedRoles; }
            set
            {
                _unassignedRoles = value;
                OnPropertyChanged(nameof(UnassignedRoles));
            }
        }

        private RoleModel _selectedUnassignedRole;

        public RoleModel SelectedUnassigedRole
        {
            get { return _selectedUnassignedRole; }
            set
            {
                _selectedUnassignedRole = value;
                OnPropertyChanged(nameof(SelectedUnassigedRole));
            }
        }






    }
}
