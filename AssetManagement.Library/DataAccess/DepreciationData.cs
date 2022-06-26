using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.DataAccess
{
    public class DepreciationData
    {
        private readonly SqlDataAccess _sqlData;

        public DepreciationData(SqlDataAccess sqlData)
        {
            _sqlData = sqlData;
        }

        public List<FixedAssetDepreciationModel> GetFixedAssets(int clientId, DateTime dateOfReference)
        {
            var dynamicData = _sqlData.LoadData<dynamic, dynamic>("dbo.spDepreciation_Calculation", new { clientId, dateOfReference }, "AssetManagement");

            List<FixedAssetDepreciationModel> output = dynamicData.Select(item => new FixedAssetDepreciationModel
            {
                InventoryNumber = item.InventoryNumber,
                EntryDate = item.EntryDate,
                ExitDate = item.ExitDate,
                AssignedDocument = new DocumentModel { DocumentNumber = item.DocumentNumber},
                Operation = new OperationModel
                {
                    OperationType = new OperationTypeModel { OperationDescription = item.OperationDescription },
                    OperationDate = item.OperationDate,
                    OperationValue = item.OperationValue ?? 0
                },
                FixedAssetDescription = item.FixedAssetDescription,
                ClasificationCode = new ClasificationCodeModel { ClasificationCode = item.ClasificationCode, ClasificationCodeDescription = item.ClasificationCodeDescription },
                AccountId = item.AccountId,
                AssetValue = item.AssetValue,
                MonthsOfAccountingDepreciation = item.MonthsOfAccountingDepreciation,
                MonthsOfFiscalDepreciation = item.MonthsOfFiscalDepreciation,
                AccountingDepreciationMethod = item.AccountingDepreciationMethod,
                FiscalDepreciationMethod = item.FiscalDepreciationMethod,

                AccountingDepreciation = item.AccountingDepreciation,
                FiscalDepreciation = item.FiscalDepreciation,
                OperationAccountingDepreciation = item.OperationAccountingDepreciation ?? 0,
                OperationFiscalDepreciation = item.OperationFiscalDepreciation ?? 0


            }).ToList();

            return output;
        }
    }
}