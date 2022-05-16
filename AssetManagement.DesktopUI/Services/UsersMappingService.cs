using AssetManagement.DesktopUI.Models;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Services
{
    internal class UsersMappingService
    {
        public List<UserDisplayModel> MapToUserDisplayModel(List<UserModel> users)
        {
            List<UserDisplayModel> mappedUsers = new List<UserDisplayModel>();

            foreach (var user in users.OrderBy(x => x.Id))
            {
                if (mappedUsers.All(x => x.Id != user.Id))
                {
                    mappedUsers.Add(new UserDisplayModel()
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Email = user.Email,
                        Roles = users.GroupBy(x => x.RoleId).Select(x => x.First()).Select(x => new RoleModel()
                        {
                            Id = x.RoleId,
                            Role = x.Role
                        }).ToList(),
                        Clients = users.Where(x => x.Id == user.Id).Select(x => x.ClientName).Distinct().ToList()
                    });
                }
            }

            return mappedUsers;
        }
    }
}
