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
    internal class AddDocumentTypeCommand : CommandBase
    {
        private readonly DocumentsViewModel _viewModel;
        private readonly DocumentData _documentData;

        public AddDocumentTypeCommand(DocumentsViewModel viewModel, DocumentData documentData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _documentData = documentData;
        }

        public override void Execute(object parameter)
        {
            try
            {
                DocumentTypeModel documentType = new()
                {
                    DocumentOperationType = _viewModel.DocumentOperationType,
                    DocumentDescription = _viewModel.DocumentTypeDescription
                };
                _documentData.AddDocumentType(documentType);
                _viewModel.DisplayDocumentTypes();
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la adaugarea tipului de document!");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return string.IsNullOrWhiteSpace(_viewModel.DocumentOperationType) == false &&
                string.IsNullOrWhiteSpace(_viewModel.DocumentTypeDescription) == false;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
