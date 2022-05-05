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

        public UserModel GetUserByUsername(string username)
        {
            var output = _sqlData.LoadData<UserModel, dynamic>("dbo.spUser_GetByUsername", new { Username = username }, "AssetManagement");

            return output.First();
        }
    }
}
