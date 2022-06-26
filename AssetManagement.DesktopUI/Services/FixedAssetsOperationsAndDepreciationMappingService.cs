using AssetManagement.DesktopUI.Models;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Services
{
    internal class FixedAssetsOperationsAndDepreciationMappingService
    {
        public List<FixedAssetDepreciationDisplayModel> MapToFixedAssetDepreciationDisplayModel(List<FixedAssetDepreciationModel> fixedAssets)
        {
            List<FixedAssetDepreciationDisplayModel> mappedFixedAssetsWithOperations = new List<FixedAssetDepreciationDisplayModel>();

            foreach (var fixedAsset in fixedAssets)
            {
                // check if an asset has been added previously
                if (mappedFixedAssetsWithOperations.All(x => x.InventoryNumber != fixedAsset.InventoryNumber))
                {
                    mappedFixedAssetsWithOperations.Add(new FixedAssetDepreciationDisplayModel
                    {
                        InventoryNumber = fixedAsset.InventoryNumber,
                        EntryDate = fixedAsset.EntryDate,
                        ExitDate = fixedAsset.ExitDate,

                        ClasificationCode = fixedAsset.ClasificationCode,
                        FixedAssetDescription = fixedAsset.FixedAssetDescription,
                        AccountId = fixedAsset.AccountId,
                        AssetValue = fixedAsset.AssetValue,
                        MonthsOfAccountingDepreciation = fixedAsset.MonthsOfAccountingDepreciation,
                        MonthsOfFiscalDepreciation = fixedAsset.MonthsOfFiscalDepreciation,
                        AccountingDepreciationMethod = fixedAsset.AccountingDepreciationMethod,
                        FiscalDepreciationMethod = fixedAsset.FiscalDepreciationMethod,

                        Operations = fixedAssets.Where(x => x.InventoryNumber == fixedAsset.InventoryNumber).Select(x => new OperationDisplayModel
                        {
                            OperationType =  new OperationTypeModel { OperationDescription = x.Operation.OperationType.OperationDescription},
                            OperationDate = x.Operation.OperationDate,
                            OperationValue = x.Operation.OperationValue
                        }).ToList(),

                        FixedAssetAccountingDepreciation = fixedAsset.AccountingDepreciation,
                        FixedAssetFiscalDepreciation = fixedAsset.FiscalDepreciation,
                        AssignedDocument = fixedAsset.AssignedDocument

                        
                    });
                }
            }

            return mappedFixedAssetsWithOperations;
        }
    }
}
