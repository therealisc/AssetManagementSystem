﻿using AssetManagement.DesktopUI.ViewModels;
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
    class DeleteOperationTypeCommand : CommandBase
    {
        private readonly OperationsViewModel _viewModel;
        private readonly OperationData _operationData;

        public DeleteOperationTypeCommand(OperationsViewModel viewModel, OperationData operationData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _operationData = operationData;
        }

        public override void Execute(object parameter)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Sigur doresti sa stergi tipul de operatie?", "Atentie!", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _operationData.DeleteOperationType(_viewModel.SelectedOperationTypeModel);
                    _viewModel.DisplayOperationTypes();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la stergerea tipului de operatie!");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedOperationTypeModel != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
