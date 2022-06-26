using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.Models
{
    public class FixedAssetDepreciationModel : FixedAssetModel
    {
        public DateTime EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public OperationModel Operation { get; set; }
        public decimal AccountingDepreciation { get; set; }
        public decimal FiscalDepreciation { get; set; }
        public decimal OperationAccountingDepreciation { get; set; }
        public decimal OperationFiscalDepreciation { get; set; }
    }
}
