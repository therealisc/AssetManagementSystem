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

        public OperationsViewModel(OperationData operationData,
                                   FixedAssetData fixedAssetData,
                                   FixedAssetsMappingService fixedAssetsMappingService,
                                   AccountStore accountStore)
        {
            _operationData = operationData;
            _fixedAssetData = fixedAssetData;
            _fixedAssetsMappingService = fixedAssetsMappingService;
            _accountStore = accountStore;

            AddOperationTypeCommand = new AddOperationTypeCommand(this, operationData);
            DeleteOperationTypeCommand = new DeleteOperationTypeCommand(this, operationData);
            UpdateOperationTypeCommand = new UpdateOperationTypeCommand(this, operationData);

            AddOperationCommand = new AddOperationCommand(this, operationData);
            DeleteOperationCommand = new DeleteOperationCommand(this, operationData);
            UpdateOperationCommand = new UpdateOperationCommand(this, operationData);

            DisplayOperationTypes();

            AssignedFixedAssets = new BindingList<FixedAssetDisplayModel>(_fixedAssetsMappingService.MapToFixedAssetDisplayModel(
                _fixedAssetData.GetFixedAssets(_accountStore.CurrentAccount.UserId)));

        }

        internal void DisplayOperations()
        {
            Operations = new BindingList<OperationModel>(_operationData.GetOperations(SelectedFixedAsset.InventoryNumber));
        }

        internal void DisplayOperationTypes()
        {
            OperationTypes = new BindingList<OperationTypeModel>(_operationData.GetOperationTypes());
        }

        public ICommand AddOperationTypeCommand { get; set; }
        public ICommand DeleteOperationTypeCommand { get; set; }
        public ICommand UpdateOperationTypeCommand { get; set; }

        public ICommand AddOperationCommand { get; set; }
        public ICommand DeleteOperationCommand { get; set; }
        public ICommand UpdateOperationCommand { get; set; }

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


        public BindingList<FixedAssetDisplayModel> AssignedFixedAssets { get; set; }

        private FixedAssetDisplayModel _selectedFixedAsset;

        public FixedAssetDisplayModel SelectedFixedAsset
        {
            get { return _selectedFixedAsset; }
            set
            {
                _selectedFixedAsset = value;
                DisplayOperations();
                OnPropertyChanged(nameof(SelectedFixedAsset));
            }
        }

        private OperationTypeModel _selectedOperationType;

        public OperationTypeModel SelectedOperationType
        {
            get { return _selectedOperationType; }
            set
            {
                _selectedOperationType = value;
                OnPropertyChanged(nameof(SelectedOperationType));
            }
        }

        private decimal _selectedOperationValue;

        public decimal SelectedOperationValue
        {
            get { return _selectedOperationValue; }
            set
            {
                _selectedOperationValue = value;
                OnPropertyChanged(nameof(SelectedOperationValue));
            }
        }

        private DateTime _selectedOperationDate = DateTime.Now;

        public DateTime SelectedOperationDate
        {
            get { return _selectedOperationDate; }
            set
            {
                _selectedOperationDate = value;
                OnPropertyChanged(nameof(SelectedOperationDate));
            }
        }

        private OperationModel _selectedOperation;

        public OperationModel SelectedOperation
        {
            get { return _selectedOperation; }
            set
            {
                if (value != null)
                {
                    _selectedOperation = value;
                    SelectedOperationType = value.OperationType;
                    SelectedOperationValue = value.OperationValue;
                    SelectedOperationDate = value.OperationDate;
                    OnPropertyChanged(nameof(SelectedOperation));
                }
            }
        }

        private BindingList<OperationModel> _operations;

        public BindingList<OperationModel> Operations
        {
            get { return _operations; }
            set
            {
                _operations = value;
                OnPropertyChanged(nameof(Operations));
            }
        }









    }
}
