using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.DataAccess
{
    public class OperationData
    {
        private readonly SqlDataAccess _sqlData;

        public OperationData(SqlDataAccess sqlData)
        {
            _sqlData = sqlData;
        }

        public List<OperationTypeModel> GetOperationTypes()
        {
            var output = _sqlData.LoadData<OperationTypeModel, dynamic>("dbo.spOperationTypes_GetAll", new { }, "AssetManagement");
            return output;
        }

        public void AddOperationType(OperationTypeModel operationType)
        {
            _sqlData.SaveData("dbo.spOperationType_Insert", new { operationType.OperationDescription }, "AssetManagement");
        }

        public void DeleteOperationType(OperationTypeModel operationType)
        {
            _sqlData.SaveData("dbo.spOperationType_Delete", new { operationType.Id }, "AssetManagement");
        }

        public void UpdateOperationType(OperationTypeModel operationType)
        {
            _sqlData.SaveData("dbo.spOperationType_Update", new { operationType.Id, operationType.OperationDescription }, "AssetManagement");
        }


    }
}
