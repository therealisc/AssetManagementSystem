using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.ComponentModel;
using System.Windows;

namespace AssetManagement.DesktopUI.Commands
{
    class UpdateOperationCommand : CommandBase
    {
        private readonly OperationsViewModel _viewModel;
        private readonly OperationData _operationData;

        public UpdateOperationCommand(OperationsViewModel viewModel, OperationData operationData)
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
                    Id = _viewModel.SelectedOperation.Id,
                    OperationType = _viewModel.SelectedOperationType,
                    OperationValue = _viewModel.SelectedOperationValue,
                    OperationDate = _viewModel.SelectedOperationDate
                };

                _operationData.UpdateOperation(operation);
                _viewModel.DisplayOperations();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la modificarea operatiei!");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedOperation != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
