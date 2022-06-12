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
    internal class UpdateDocumentCommand : CommandBase
    {
        private readonly DocumentsViewModel _viewModel;
        private readonly DocumentData _documentData;

        public UpdateDocumentCommand(DocumentsViewModel viewModel, DocumentData documentData)
        {
            _viewModel = viewModel;
            _documentData = documentData;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            _viewModel.SelectedDocument.DocumentNumber = _viewModel.SelectedDocumentNumber;
            _viewModel.SelectedDocument.Supplier = _viewModel.SelectedSupplier;
            _viewModel.SelectedDocument.DocumentType = _viewModel.SelectedDocumentType;
            _documentData.UpdateDocument(_viewModel.SelectedDocument);
            _viewModel.DisplayDocuments();
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedDocument != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
