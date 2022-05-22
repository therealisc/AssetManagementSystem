using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    public class AddSupplierCommand : CommandBase
    {
        private readonly SupplierData _supplierData;
        private readonly SuppliersViewModel _viewModel;

        public AddSupplierCommand(SuppliersViewModel viewModel, SupplierData supplierData)
        {
            _supplierData = supplierData;
            _viewModel = viewModel;
            //_viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            SupplierModel supplier = new SupplierModel() 
            {
                SupplierName = _viewModel.SelectedSupplierName,
                FiscalCode = _viewModel.SelectedSupplierFiscalCode,
                Address = _viewModel.SelectedSupplierAddress
            };

            _supplierData.AddSupplier(supplier);
            _viewModel.DisplaySuppliers();
        }
    }
}
