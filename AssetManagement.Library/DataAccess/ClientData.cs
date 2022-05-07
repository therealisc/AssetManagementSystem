using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.DataAccess
{
    public class ClientData
    {
        private readonly SqlDataAccess _sqlData;

        public ClientData(SqlDataAccess sqlData)
        {
            _sqlData = sqlData;
        }

        public List<ClientModel> GetClients()
        {
            var output = _sqlData.LoadData<ClientModel, dynamic>("dbo.spClients_GetAll", new { }, "AssetManagement");

            return output;
        }
    }
}
