using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.ComponentModel;
using System.Windows;

namespace AssetManagement.DesktopUI.Commands
{
    class AddOperationCommand : CommandBase
    {
        private readonly OperationsViewModel _viewModel;
        private readonly OperationData _operationData;

        public AddOperationCommand(OperationsViewModel viewModel, OperationData operationData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _operationData = operationData;
        }

        public override void Execute(object parameter)
        {
            try
            {
                OperationModel operation = new()
                {
                    InventoryNumber = _viewModel.SelectedFixedAsset.InventoryNumber,
                    OperationType = _viewModel.SelectedOperationType,
                    OperationValue = _viewModel.SelectedOperationValue,
                    OperationDate = _viewModel.SelectedOperationDate
                };

                _operationData.AddOperation(operation);
                _viewModel.DisplayOperations();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la adaugarea operatiei!");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedFixedAsset != null &&
                _viewModel.SelectedOperationType != null &&
                _viewModel.SelectedOperationValue != 0;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
