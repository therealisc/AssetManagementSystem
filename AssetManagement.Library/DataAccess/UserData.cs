using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.DataAccess
{
    public class UserData
    {
        private readonly SqlDataAccess _sqlData;

        public UserData(SqlDataAccess sqlData)
        {
            _sqlData = sqlData;
        }

        public List<FullUserModel> GetUserByUsername(string username)
        {
            var output = _sqlData.LoadData<FullUserModel, dynamic>("dbo.spUser_GetByUsername", new { Username = username }, "AssetManagement");

            return output;
        }

        public void ChangeUserPassword(int userId, string passwordHash)
        {
            _sqlData.SaveData("dbo.spUser_UpdatePassword", new { UserId = userId, PasswordHash = passwordHash}, "AssetManagement");
        }

        public List<FullUserModel> GetUsers()
        {
            var output = _sqlData.LoadData<FullUserModel, dynamic>("dbo.spUsers_GetAll", new { }, "AssetManagement");

            return output;
        }

        public List<RoleModel> GetRoles()
        {
            var output = _sqlData.LoadData<RoleModel, dynamic>("dbo.spRoles_GetUnassigned", new { }, "AssetManagement");

            return output;
        }

        public void AddUser(UserModel user, List<RoleModel> roles, List<ClientModel> clients)
        {
            try
            {
                _sqlData.StartTransaction("AssetManagement");

                //Save the user model
                _sqlData.SaveDataInTransaction("dbo.spUser_Insert", new { user.Username, user.Email, user.PasswordHash });

                //Get the newly inserted user id from the database
                user.Id = _sqlData.LoadDataInTransaction<int, dynamic>("dbo.spUser_Lookup", new { }).FirstOrDefault();

                //Add assigned roles
                foreach (var role in roles)
                {
                    _sqlData.SaveDataInTransaction("dbo.spUserRole_Insert", new { UserId = user.Id, RoleId = role.Id });
                }

                //Add assigned clients
                foreach (var client in clients)
                {
                    _sqlData.SaveDataInTransaction("dbo.spUserClient_Insert", new { UserId = user.Id, ClientId = client.Id });
                }

                _sqlData.CommitTransaction();
            }
            catch (Exception)
            {
                _sqlData.RollbackTransaction();
                throw;
            }
        }
    }
}
