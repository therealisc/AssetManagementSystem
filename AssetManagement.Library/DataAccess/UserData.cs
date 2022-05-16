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

        public List<UserModel> GetUserByUsername(string username)
        {
            var output = _sqlData.LoadData<UserModel, dynamic>("dbo.spUser_GetByUsername", new { Username = username }, "AssetManagement");

            return output;
        }

        public void ChangeUserPassword(int userId, string passwordHash)
        {
            _sqlData.SaveData("dbo.spUser_UpdatePassword", new { UserId = userId, PasswordHash = passwordHash}, "AssetManagement");
        }

        public List<UserModel> GetUsers()
        {
            var output = _sqlData.LoadData<UserModel, dynamic>("dbo.spUsers_GetAll", new { }, "AssetManagement");

            return output;
        }

        public List<RoleModel> GetUnassignedRoles(int userId)
        {
            var output = _sqlData.LoadData<RoleModel, dynamic>("dbo.spRoles_GetUnassigned", new { userId }, "AssetManagement");

            return output;
        }
    }
}
