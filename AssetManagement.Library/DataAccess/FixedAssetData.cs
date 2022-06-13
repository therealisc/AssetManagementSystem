using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.DataAccess
{
    public class FixedAssetData
    {
        private readonly SqlDataAccess _sqlData;

        public FixedAssetData(SqlDataAccess sqlData)
        {
            _sqlData = sqlData;
        }

        public List<FixedAssetModel> GetFixedAssets(int userId)
        {
            var dynamicData = _sqlData.LoadData<dynamic, dynamic>("dbo.spFixedAssets_GetAll", new { userId }, "AssetManagement");

            List<FixedAssetModel> output = dynamicData.Select(item => new FixedAssetModel
            {
                InventoryNumber = item.InventoryNumber,
                ClasificationCode = new ClasificationCodeModel 
                { 
                    ClasificationCode = item.ClasificationCode, 
                    ClasificationCodeDescription = item.ClasificationCodeDescription,
                    MinimumLifetime = item.MinimumLifetime,
                    MaximumLifetime = item.MaximumLifetime
                },
                Client = new ClientModel { Id = item.ClientId, ClientName = item.ClientName },
                FixedAssetDescription = item.FixedAssetDescription,
                AccountId = item.AccountId,
                AssetValue = item.AssetValue,
                MonthsOfAccountingDepreciation = item.MonthsOfAccountingDepreciation,
                MonthsOfFiscalDepreciation = item.MonthsOfFiscalDepreciation,
                AccountingDepreciationMethod = item.AccountingDepreciationMethod,
                FiscalDepreciationMethod = item.FiscalDepreciationMethod,
                AssignedDocument = new DocumentModel { Id = item.DocumentId }

            }).ToList();

            return output;
        }

        public void AddFixedAsset(FixedAssetModel fixedAsset, List<DocumentModel> documents)
        {
            try
            {
                _sqlData.StartTransaction("AssetManagement");

                //Save the asset model
                var parameters = new 
                {
                    fixedAsset.ClasificationCode.ClasificationCode,
                    ClientId = fixedAsset.Client.Id,
                    fixedAsset.FixedAssetDescription,
                    fixedAsset.AccountId,
                    fixedAsset.AssetValue,
                    fixedAsset.MonthsOfAccountingDepreciation,
                    fixedAsset.MonthsOfFiscalDepreciation,
                    fixedAsset.AccountingDepreciationMethod,
                    fixedAsset.FiscalDepreciationMethod
                };
                _sqlData.SaveDataInTransaction("dbo.spFixedAsset_Insert", parameters);

                //Get the newly inserted asset id from the database
                fixedAsset.InventoryNumber = _sqlData.LoadDataInTransaction<int, dynamic>("dbo.spFixedAsset_Lookup", new { }).FirstOrDefault();

                //Add assigned roles
                foreach (var document in documents)
                {
                    _sqlData.SaveDataInTransaction("dbo.spFixedAssetDocument_Insert", new { fixedAsset.InventoryNumber, DocumentId = document.Id });
                }

                _sqlData.CommitTransaction();
            }
            catch (Exception)
            {
                _sqlData.RollbackTransaction();
                throw;
            }
        }

        public void DeleteFixedAsset(int inventoryNumber)
        {
            _sqlData.SaveData("dbo.spFixedAsset_Delete", new { inventoryNumber }, "AssetManagement");
        }

        public void UpdateFixedAsset(FixedAssetModel fixedAsset, List<DocumentModel> documents)
        {
            try
            {
                _sqlData.StartTransaction("AssetManagement");
                var parameters = new
                {
                    fixedAsset.InventoryNumber,
                    fixedAsset.ClasificationCode.ClasificationCode,
                    ClientId = fixedAsset.Client.Id,
                    fixedAsset.FixedAssetDescription,
                    fixedAsset.AccountId,
                    fixedAsset.AssetValue,
                    fixedAsset.MonthsOfAccountingDepreciation,
                    fixedAsset.MonthsOfFiscalDepreciation,
                    fixedAsset.AccountingDepreciationMethod,
                    fixedAsset.FiscalDepreciationMethod
                };
                _sqlData.SaveDataInTransaction("dbo.spFixedAsset_Update", parameters);

                _sqlData.SaveDataInTransaction("dbo.spFixedAssetDocuments_Delete", new { fixedAsset.InventoryNumber });

                foreach (var document in documents)
                {
                    _sqlData.SaveDataInTransaction("dbo.spFixedAssetDocument_Insert", new { fixedAsset.InventoryNumber, DocumentId = document.Id });
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
