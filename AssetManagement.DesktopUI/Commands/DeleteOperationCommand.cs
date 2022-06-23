using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using System;
using System.ComponentModel;
using System.Windows;

namespace AssetManagement.DesktopUI.Commands
{
    class DeleteOperationCommand : CommandBase
    {
        private readonly OperationsViewModel _viewModel;
        private readonly OperationData _operationData;

        public DeleteOperationCommand(OperationsViewModel viewModel, OperationData operationData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _operationData = operationData;
        }

        public override void Execute(object parameter)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Sigur doresti sa stergi operatia?", "Atentie!", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _operationData.DeleteOperation(_viewModel.SelectedOperation);
                    _viewModel.DisplayOperations();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la stergerea operatiei!");
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
