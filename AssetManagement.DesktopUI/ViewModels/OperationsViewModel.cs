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
    class OperationsViewModel : ViewModelBase
    {
        private readonly OperationData _operationData;
        private readonly FixedAssetData _fixedAssetData;

        public OperationsViewModel(OperationData operationData, FixedAssetData fixedAssetData)
        {
            _operationData = operationData;
            _fixedAssetData = fixedAssetData;

            AddOperationTypeCommand = new AddOperationTypeCommand(this, operationData);
            DeleteOperationTypeCommand = new DeleteOperationTypeCommand(this, operationData);

            DisplayOperationTypes();
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
                _selectedOperationTypeModel = value;
                OnPropertyChanged(nameof(SelectedOperationTypeModel));
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



    }
}
