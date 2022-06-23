using AssetManagement.DesktopUI.Commands;
using AssetManagement.DesktopUI.Models;
using AssetManagement.DesktopUI.Services;
using AssetManagement.DesktopUI.Stores;
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
    class OperationsViewModel : ViewModelBase
    {
        private readonly OperationData _operationData;
        private readonly FixedAssetData _fixedAssetData;
        private readonly FixedAssetsMappingService _fixedAssetsMappingService;
        private readonly AccountStore _accountStore;

        public OperationsViewModel(OperationData operationData, FixedAssetData fixedAssetData, FixedAssetsMappingService fixedAssetsMappingService, AccountStore accountStore)
        {
            _operationData = operationData;
            _fixedAssetData = fixedAssetData;
            _fixedAssetsMappingService = fixedAssetsMappingService;
            _accountStore = accountStore;

            AddOperationTypeCommand = new AddOperationTypeCommand(this, operationData);
            DeleteOperationTypeCommand = new DeleteOperationTypeCommand(this, operationData);
            UpdateOperationTypeCommand = new UpdateOperationTypeCommand(this, operationData);

            DisplayOperationTypes();

            AssignedFixedAssets = new BindingList<FixedAssetDisplayModel>(_fixedAssetsMappingService.MapToFixedAssetDisplayModel(
                _fixedAssetData.GetFixedAssets(_accountStore.CurrentAccount.UserId)));

        }

        internal void DisplayOperations()
        {

        }

        internal void DisplayOperationTypes()
        {
            OperationTypes = new BindingList<OperationTypeModel>(_operationData.GetOperationTypes());
        }

        public ICommand AddOperationTypeCommand { get; set; }
        public ICommand DeleteOperationTypeCommand { get; set; }
        public ICommand UpdateOperationTypeCommand { get; set; }

        private BindingList<OperationTypeModel> _operationTypes;

        public BindingList<OperationTypeModel> OperationTypes
        {
            get { return _operationTypes; }
            set 
            { 
                _operationTypes = value;
                OnPropertyChanged(nameof(OperationTypes));
            }
        }

        private OperationTypeModel _selectedOperationTypeModel;

        public OperationTypeModel SelectedOperationTypeModel 
        {
            get { return _selectedOperationTypeModel; }
            set
            {
                if (value != null)
                {
                    _selectedOperationTypeModel = value;

                    SelectedOperationDescription = value.OperationDescription;
                    OnPropertyChanged(nameof(SelectedOperationTypeModel));
                }
            }
        }

        private string _selectedOperationDescription;

        public string SelectedOperationDescription
        {
            get { return _selectedOperationDescription; }
            set 
            {
                _selectedOperationDescription = value;
                OnPropertyChanged(nameof(SelectedOperationDescription));
            }
        }

        private BindingList<FixedAssetDisplayModel> _assignedFixedAssets;

        public BindingList<FixedAssetDisplayModel> AssignedFixedAssets
        {
            get { return _assignedFixedAssets; }
            set { _assignedFixedAssets = value; }
        }




    }
}
