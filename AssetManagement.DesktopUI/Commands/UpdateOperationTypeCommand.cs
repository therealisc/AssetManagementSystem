using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AssetManagement.DesktopUI.Commands
{
    class UpdateOperationTypeCommand :CommandBase
    {
        private readonly OperationsViewModel _viewModel;
        private readonly OperationData _operationData;

        public UpdateOperationTypeCommand(OperationsViewModel viewModel, OperationData operationData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _operationData = operationData;
        }

        public override void Execute(object parameter)
        {
            try
            {
                _viewModel.SelectedOperationTypeModel.OperationDescription = _viewModel.SelectedOperationDescription;
                _operationData.UpdateOperationType(_viewModel.SelectedOperationTypeModel);
                _viewModel.DisplayOperationTypes();
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la modificarea tipului de operatie!");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedOperationTypeModel != null &&
                string.IsNullOrWhiteSpace(_viewModel.SelectedOperationDescription) == false &&
                _viewModel.OperationTypes.Any(x => x.OperationDescription == _viewModel.SelectedOperationDescription) == false;
        }        

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
