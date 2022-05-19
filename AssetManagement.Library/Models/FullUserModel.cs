using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.Models
{
    public class FullUserModel : UserModel
    {
        public int RoleId { get; set; }
        public string Role { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
    }
}
