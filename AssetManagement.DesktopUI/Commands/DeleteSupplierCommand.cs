using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    class DeleteSupplierCommand : CommandBase
    {
        private readonly SuppliersViewModel _viewModel;
        private readonly SupplierData _supplierData;

        public DeleteSupplierCommand(SuppliersViewModel viewModel, SupplierData supplierData)
        {
            _viewModel = viewModel;
            _supplierData = supplierData;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            _supplierData.DeleteSupplier(_viewModel.SelectedSupplier);
            _viewModel.DisplaySuppliers();
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedSupplier != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
