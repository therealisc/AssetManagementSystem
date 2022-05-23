using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    internal class AddDocumentCommand : CommandBase
    {
        private readonly DocumentData _documentData;
        private readonly DocumentsViewModel _viewModel;

        public AddDocumentCommand(DocumentsViewModel viewModel, DocumentData documentData)
        {
            _documentData = documentData;
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            DocumentModel document = new DocumentModel()
            {
                DocumentNumber = _viewModel.SelectedDocumentNumber,
                DocumentDate = _viewModel.SelectedDocumentDate,
                DocumentType = new DocumentTypeModel() { Id = _viewModel.SelectedDocumentType.Id },
                Supplier = new SupplierModel() { Id = _viewModel.SelectedSupplier.Id }
            };

            _documentData.AddDocument(document);
            _viewModel.DisplayDocuments();
        }

        public override bool CanExecute(object parameter)
        {
            return string.IsNullOrEmpty(_viewModel.SelectedDocumentNumber) == false &&
                _viewModel.SelectedDocumentType != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
