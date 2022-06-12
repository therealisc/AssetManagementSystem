using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Models
{
    class FixedAssetDisplayModel
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
        public List<DocumentModel> AssignedDocuments { get; set; }
    }
}
