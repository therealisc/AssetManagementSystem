using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.Models
{
    public class FixedAssetModel
    {
        public int InventoryNumber { get; set; }
        public ClasificationCodeModel ClasificationCode { get; set; }
        public ClientModel Client { get; set; }
        public string FixedAssetDescription { get; set; }
        public string AccountId { get; set; }
        public decimal AssetValue { get; set; }
        public int MonthsOfAccountingDepreciation { get; set; }
        public int MonthsOfFiscalDepreciation { get; set; }
        public string AccountingDepreciationMethod { get; set; }
        public string FiscalDepreciationMethod { get; set; }
        public DocumentModel AssignedDocument { get; set; }
    }
}
