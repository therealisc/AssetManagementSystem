using AssetManagement.DesktopUI.Models;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Services
{
    internal class FixedAssetsMappingService
    {
        public List<FixedAssetDisplayModel> MapToFixedAssetDisplayModel(List<FixedAssetModel> fixedAssets)
        {
            List<FixedAssetDisplayModel> mappedFixedAssets = new List<FixedAssetDisplayModel>();

            foreach (var fixedAsset in fixedAssets)
            {
                // check if an asset has been added previously
                if (mappedFixedAssets.All(x => x.InventoryNumber != fixedAsset.InventoryNumber))
                {
                    mappedFixedAssets.Add(new FixedAssetDisplayModel
                    {
                        InventoryNumber = fixedAsset.InventoryNumber,
                        ClasificationCode = fixedAsset.ClasificationCode,
                        Client = fixedAsset.Client,
                        FixedAssetDescription = fixedAsset.FixedAssetDescription,
                        AccountId = fixedAsset.AccountId,
                        AssetValue = fixedAsset.AssetValue,
                        MonthsOfAccountingDepreciation = fixedAsset.MonthsOfAccountingDepreciation,
                        MonthsOfFiscalDepreciation = fixedAsset.MonthsOfFiscalDepreciation,
                        AccountingDepreciationMethod = fixedAsset.AccountingDepreciationMethod,
                        FiscalDepreciationMethod = fixedAsset.FiscalDepreciationMethod,
                        AssignedDocuments = fixedAssets.Where(x => x.InventoryNumber == fixedAsset.InventoryNumber).Select(x => x.AssignedDocument).ToList()
                    });
                }
            }

            return mappedFixedAssets;
        }
    }
}
