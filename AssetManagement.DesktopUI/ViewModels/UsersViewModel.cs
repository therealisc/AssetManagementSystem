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
        private readonly ClientData _clientData;
        private readonly UsersMappingService _usersMappingService;

        public UsersViewModel(UserData userData, UsersMappingService mappingService, ClientData clientData)
        {
            _userData = userData;
            _clientData = clientData;
            _usersMappingService = mappingService;
            DisplayUsers();
            AssignRoleCommand = new AssignRoleCommand(this);
            UnassignRoleCommand = new UnassignRoleCommand(this);
            AssignClientCommand = new AssignClientCommand(this);
            UnassignClientCommand = new UnassignClientCommand(this);
            AddUserCommand = new AddUserCommand(this, userData);
            UpdateUserCommand = new UpdateUserCommand(this, userData);
            DeleteUserCommand = new DeleteUserCommand(this, userData);
        }

        internal void DisplayUsers()
        {
            Users = new BindingList<UserDisplayModel>(_usersMappingService.MapToUserDisplayModel(_userData.GetUsers()));
            DisplayRolesAndCustomers();
        }

        private void DisplayRolesAndCustomers()
        {
            UnassignedRoles = new BindingList<RoleModel>(_userData.GetRoles());
            UnassignedClients = new BindingList<ClientModel>(new List<ClientModel>(_clientData.GetClients()));
        }

        public ICommand AssignRoleCommand { get; set; }
        public ICommand UnassignRoleCommand { get; set; }
        public ICommand AssignClientCommand { get; set; }
        public ICommand UnassignClientCommand { get; set; }

        public ICommand AddUserCommand { get; set; }
        public ICommand UpdateUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }


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
                    DisplayRolesAndCustomers();

                    SelectedUserUsername = value.Username;
                    SelectedUserEmail = value.Email;
                    AssignedRoles = new BindingList<RoleModel>(value.Roles);                    
                    foreach(var role in AssignedRoles) UnassignedRoles.RemoveAt(UnassignedRoles.IndexOf(UnassignedRoles.First(x => x.Id == role.Id)));

                    AssignedClients = new BindingList<ClientModel>(value.Clients);
                    foreach (var client in AssignedClients) UnassignedClients.RemoveAt(UnassignedClients.IndexOf(UnassignedClients.First(x => x.Id == client.Id)));

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

        private BindingList<RoleModel> _assignedRoles = new();

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


        private BindingList<ClientModel> _assignedClients = new();

        public BindingList<ClientModel> AssignedClients
        {
            get { return _assignedClients; }
            set
            {
                _assignedClients = value;
                OnPropertyChanged(nameof(AssignedClients));
            }
        }

        private ClientModel _selectedAssignedClient;

        public ClientModel SelectedAssignedClient
        {
            get { return _selectedAssignedClient; }
            set
            {
                _selectedAssignedClient = value;
                OnPropertyChanged(nameof(SelectedAssignedClient));
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

        private BindingList<ClientModel> _unassignedClients;

        public BindingList<ClientModel> UnassignedClients
        {
            get { return _unassignedClients; }
            set
            {
                _unassignedClients = value;
                OnPropertyChanged(nameof(UnassignedClients));
            }
        }

        private ClientModel _selectedUnassignedClient;

        public ClientModel SelectedUnassignedClient
        {
            get { return _selectedUnassignedClient; }
            set
            {
                _selectedUnassignedClient = value;
                OnPropertyChanged(nameof(SelectedUnassignedClient));
            }
        }
    }
}
