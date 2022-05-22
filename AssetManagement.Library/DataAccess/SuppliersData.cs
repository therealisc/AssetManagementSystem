using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.DataAccess
{
    public class SupplierData
    {
        private readonly SqlDataAccess _sqlData;

        public SupplierData(SqlDataAccess sqlData)
        {
            _sqlData = sqlData;
        }

        public List<SupplierModel> GetSuppliers()
        {
            var output = _sqlData.LoadData<SupplierModel, dynamic>("dbo.spSuppliers_GetAll", new { }, "AssetManagement");

            return output;
        }

        public void AddSupplier(SupplierModel supplier)
        {
            _sqlData.SaveData("dbo.spSupplier_Insert", new { supplier.SupplierName, supplier.FiscalCode, supplier.Address }, "AssetManagement");
        }

        public void DeleteSupplier(SupplierModel supplier)
        {
            _sqlData.SaveData("dbo.spSupplier_Delete", new { SupplierId = supplier.Id }, "AssetManagement");
        }

        public void UpdateSupplier(SupplierModel supplier)
        {
            _sqlData.SaveData("dbo.spSupplier_Update",
                new { supplier.Id, supplier.SupplierName, supplier.FiscalCode, supplier.Address }, "AssetManagement");
        }
    }
}
