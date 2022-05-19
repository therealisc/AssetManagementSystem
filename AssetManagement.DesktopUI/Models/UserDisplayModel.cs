using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Models
{
    internal class UserDisplayModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<RoleModel> Roles { get; set; }
        public List<ClientModel> Clients { get; set; }

        public string AssignedRoles 
        {
            get
            {
                return string.Join(", ", Roles.Select(x => x.Role));
            }
        }

        public string AssignedClients
        {
            get
            {
                return string.Join(", ", Clients.Select(x => x.ClientName));
            }
        }

    }
}
