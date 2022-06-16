using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AssetManagement.DesktopUI.Commands
{
    class UpdateDocumentTypeCommand : CommandBase
    {
        private readonly DocumentsViewModel _viewModel;
        private readonly DocumentData _documentData;

        public UpdateDocumentTypeCommand(DocumentsViewModel viewModel, DocumentData documentData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _documentData = documentData;
        }

        public override void Execute(object parameter)
        {
            try
            {
                _viewModel.SelectedDocumentTypeModel.DocumentDescription = _viewModel.DocumentTypeDescription;
                _viewModel.SelectedDocumentTypeModel.DocumentOperationType = _viewModel.DocumentOperationType;
                _documentData.UpdateDocumentType(_viewModel.SelectedDocumentTypeModel);

                _viewModel.DisplayDocumentTypes();
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la modificarea tipului de document!");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedDocumentTypeModel != null &&
                string.IsNullOrWhiteSpace(_viewModel.DocumentOperationType) == false &&
                string.IsNullOrWhiteSpace(_viewModel.DocumentTypeDescription) == false;

        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
