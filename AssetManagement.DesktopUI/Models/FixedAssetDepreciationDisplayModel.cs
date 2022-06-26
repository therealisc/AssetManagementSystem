using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Models
{
    internal class FixedAssetDepreciationDisplayModel : FixedAssetModel
    {
        public DateTime EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public List<OperationDisplayModel> Operations { get; set; }
        public decimal FixedAssetAccountingDepreciation { get; set; }
        public decimal FixedAssetFiscalDepreciation { get; set; }

        public decimal TotalAccountingDepreciation
        {
            get
            {
                return FixedAssetAccountingDepreciation + Operations.Sum(x => x.OperationAccountingDepreciation);
            }
        }

        public decimal TotalFiscalDepreciation
        {
            get
            {
                return FixedAssetFiscalDepreciation + Operations.Sum(x => x.OperationFiscalDepreciation);
            }
        }

        public decimal TotalAssetValue
        {
            get
            {
                return AssetValue + Operations.Sum(x => x.OperationValue);
            }
        }

        public decimal NetAssetValue
        {
            get
            {
                return TotalAssetValue - TotalAccountingDepreciation;
            }
        }
    }
}
