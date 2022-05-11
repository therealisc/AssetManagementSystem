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

        public void SaveClient(ClientModel client)
        {
            _sqlData.SaveData("dbo.spClient_Insert", new { client.ClientName, client.FiscalCode, client.Address }, "AssetManagement");
        }

        public void DeleteClient(ClientModel client)
        {
            _sqlData.SaveData("dbo.spClient_Delete", new { ClientId = client.Id }, "AssetManagement");
        }

        public void UpdateClient(ClientModel client)    //@Id INT,//@ClientName NVARCHAR(50),//@FiscalCode VARCHAR(20), //@Address NVARCHAR(max)
        {
            _sqlData.SaveData("dbo.spClient_Update", 
                new { Id = client.Id, ClientName = client.ClientName, FiscalCode = client.FiscalCode, Address = client.Address }, "AssetManagement");
        }
    }
}
