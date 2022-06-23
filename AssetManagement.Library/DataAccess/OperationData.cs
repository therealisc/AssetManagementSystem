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

        public List<OperationModel> GetOperations(int inventoryNumber)
        {
            var dynamicData = _sqlData.LoadData<dynamic, dynamic>("dbo.spOperations_GetAll", new { inventoryNumber }, "AssetManagement");

            List<OperationModel> output = dynamicData.Select(item => new OperationModel
            {
                Id = item.Id,
                InventoryNumber = item.InventoryNumber,
                OperationType = new OperationTypeModel { Id = item.OperationTypeId, OperationDescription = item.OperationDescription },
                OperationValue = item.OperationValue,
                OperationDate = item.OperationDate

            }).ToList();

            return output;
        }

        public void AddOperation(OperationModel operation)
        {
            var parameters = new { operation.InventoryNumber, OperationTypeId = operation.OperationType.Id, operation.OperationValue, operation.OperationDate };

            _sqlData.SaveData("dbo.spOperation_Insert", parameters, "AssetManagement");
        }

        public void DeleteOperation(OperationModel operation)
        {
            _sqlData.SaveData("dbo.spOperation_Delete", new { operation.Id }, "AssetManagement");
        }

        public void UpdateOperation(OperationModel operation)
        {
            var parameters = new { operation.Id, OperationTypeId = operation.OperationType.Id, operation.OperationValue, operation.OperationDate };

            _sqlData.SaveData("dbo.spOperation_Update", parameters, "AssetManagement");
        }
    }
}
