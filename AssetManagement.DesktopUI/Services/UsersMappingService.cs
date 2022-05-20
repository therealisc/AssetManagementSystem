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
        public List<UserDisplayModel> MapToUserDisplayModel(List<FullUserModel> users)
        {
            List<UserDisplayModel> mappedUsers = new List<UserDisplayModel>();

            foreach (var user in users.OrderBy(x => x.Id))
            {   
                // check if a user has been added previously
                if (mappedUsers.All(x => x.Id != user.Id))
                {
                    mappedUsers.Add(new UserDisplayModel()
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Email = user.Email,

                        // select all matching roles based on the user id
                        Roles = users.Where(x => x.Id == user.Id).GroupBy(x => x.RoleId).Select(x => x.First()).Select(x => new RoleModel()
                        {
                            Id = x.RoleId,
                            Role = x.Role
                        }).ToList(),

                        // select all mathcing clients based on the user id
                        Clients = users.Where(x => x.Id == user.Id).GroupBy(x => x.ClientId).Select(x => x.First()).Select(x => new ClientModel()
                        {
                            Id = x.ClientId,
                            ClientName = x.ClientName
                        }).ToList()
                    });
                }
            }

            return mappedUsers;
        }
    }
}
