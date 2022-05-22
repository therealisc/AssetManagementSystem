using AssetManagement.DesktopUI.Commands;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AssetManagement.DesktopUI.ViewModels
{
    public class SuppliersViewModel : ViewModelBase
    {
        private readonly SupplierData _supplierData;

        public SuppliersViewModel(SupplierData supplierData)
        {
            _supplierData = supplierData;
            DisplaySuppliers();
            SaveSupplierCommand = new AddSupplierCommand(this, _supplierData);
            DeleteSupplierCommand = new DeleteSupplierCommand(this, _supplierData);
            UpdateSupplierCommand = new UpdateSupplierCommand(this, _supplierData);
        }

        internal void DisplaySuppliers()
        {
            Suppliers = new BindingList<SupplierModel>(_supplierData.GetSuppliers());
        }

        public ICommand SaveSupplierCommand { get; set; }
        public ICommand DeleteSupplierCommand { get; set; }
        public ICommand UpdateSupplierCommand { get; set; }


        private BindingList<SupplierModel> _suppliers;

        public BindingList<SupplierModel> Suppliers
        {
            get { return _suppliers; }
            set 
            { 
                _suppliers = value;
                OnPropertyChanged(nameof(Suppliers));
            }
        }

        private SupplierModel _selectedSupplier;

        public SupplierModel SelectedSupplier
        {
            get { return _selectedSupplier; }
            set
            {
                if (value != null)
                {
                    _selectedSupplier = value;
                    SelectedSupplierName = value.SupplierName;
                    SelectedSupplierAddress = value.Address;
                    SelectedSupplierFiscalCode = value.FiscalCode;
                    OnPropertyChanged(nameof(SelectedSupplier));
                }
            }
        }

        private string _selectedSupplierName;

        public string SelectedSupplierName
        {
            get { return _selectedSupplierName; }
            set
            {
                _selectedSupplierName = value;
                OnPropertyChanged(nameof(SelectedSupplierName));
            }
        }

        private string _selectedSupplierFiscalCode;

        public string SelectedSupplierFiscalCode
        {
            get { return _selectedSupplierFiscalCode; }
            set
            {
                _selectedSupplierFiscalCode = value;
                OnPropertyChanged(nameof(SelectedSupplierFiscalCode));
            }
        }

        private string _selectedSupplierAddress;

        public string SelectedSupplierAddress
        {
            get { return _selectedSupplierAddress; }
            set
            {
                _selectedSupplierAddress = value;
                OnPropertyChanged(nameof(SelectedSupplierAddress));
            }
        }

    }
}
