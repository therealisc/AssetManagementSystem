﻿using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<FullClientModel> GetClients()
        {
            var output = _sqlData.LoadData<FullClientModel, dynamic>("dbo.spClients_GetAll", new { }, "AssetManagement");

            return output;
        }

        public List<FullClientModel> GetClients(int userId)
        {
            var output = _sqlData.LoadData<FullClientModel, dynamic>("dbo.spClients_GetAllAssigned", new { userId }, "AssetManagement");

            return output;
        }

        public void AddClient(FullClientModel client)
        {
            _sqlData.SaveData("dbo.spClient_Insert", new { client.ClientName, client.FiscalCode, client.Address }, "AssetManagement");
        }

        public void DeleteClient(FullClientModel client)
        {
            _sqlData.SaveData("dbo.spClient_Delete", new { ClientId = client.Id }, "AssetManagement");
        }

        public void UpdateClient(FullClientModel client)
        {
            _sqlData.SaveData("dbo.spClient_Update", 
                new { Id = client.Id, ClientName = client.ClientName, FiscalCode = client.FiscalCode, Address = client.Address }, "AssetManagement");
        }
    }
}
