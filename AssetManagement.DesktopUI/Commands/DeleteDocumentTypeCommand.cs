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
    class DeleteDocumentTypeCommand : CommandBase
    {
        private readonly DocumentsViewModel _viewModel;
        private readonly DocumentData _documentData;

        public DeleteDocumentTypeCommand(DocumentsViewModel viewModel, DocumentData documentData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _documentData = documentData;
        }

        public override void Execute(object parameter)
        {
            try
            {
                _documentData.DeleteDocumentType(_viewModel.SelectedDocumentTypeModel);
                _viewModel.DisplayDocumentTypes();
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la stergerea tipului de document!");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedDocumentTypeModel != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
