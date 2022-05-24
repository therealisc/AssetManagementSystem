using AssetManagement.DesktopUI.Commands;
using AssetManagement.DesktopUI.Services;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AssetManagement.DesktopUI.ViewModels
{
    class DocumentsViewModel : ViewModelBase
    {
        private readonly SupplierData _supplierData;
        private readonly DocumentData _documentData;

        public DocumentsViewModel(INavigationService suppliersNavigationService, SupplierData supplierData, DocumentData documentData)
        {
            NavigateSuppliersCommand = new NavigateCommand(suppliersNavigationService);
            _supplierData = supplierData;
            _documentData = documentData;

            AddDocumentCommand = new AddDocumentCommand(this, documentData);
            DeleteDocumentCommand = new DeleteDocumentCommand(this, documentData);
            UpdateDocumentCommand = new UpdateDocumentCommand(this, documentData);

            DisplayDocuments();
            Suppliers = new BindingList<SupplierModel>(_supplierData.GetSuppliers());
            DocumentTypes = new BindingList<DocumentTypeModel>(_documentData.GetDocumentTypes());

        }

        internal void DisplayDocuments()
        {
            Documents = new BindingList<DocumentModel>(_documentData.GetDocuments());   
        }

        public ICommand NavigateSuppliersCommand { get; set; }
        public ICommand AddDocumentCommand { get; set; }
        public ICommand DeleteDocumentCommand { get; set; }
        public ICommand UpdateDocumentCommand { get; set; }

        private BindingList<DocumentModel> _documents;

        public BindingList<DocumentModel> Documents
        {
            get { return _documents; }
            set
            {
                _documents = value;
                OnPropertyChanged(nameof(Documents));
            }
        }

        private DocumentModel _selectedDocument;

        public DocumentModel SelectedDocument
        {
            get { return _selectedDocument; }
            set
            {
                if (value != null)
                {
                    _selectedDocument = value;
                    SelectedDocumentNumber = value.DocumentNumber;
                    SelectedDocumentDate = value.DocumentDate;
                    SelectedDocumentType = value.DocumentType;
                    SelectedSupplier = value.Supplier;
                    OnPropertyChanged(nameof(SelectedDocument));
                }
            }
        }



        private BindingList<SupplierModel> _suppliers;

        public BindingList<SupplierModel> Suppliers
        {
            get { return _suppliers; }
            set
            {
                _suppliers = value;
                OnPropertyChanged(nameof(Suppliers));
            }
        }

        private SupplierModel _selectedSupplier;

        public SupplierModel SelectedSupplier
        {
            get { return _selectedSupplier; }
            set 
            { 
                _selectedSupplier = value;
                OnPropertyChanged(nameof(SelectedSupplier));
            }
        }

        private BindingList<DocumentTypeModel> _documentTypes;

        public BindingList<DocumentTypeModel> DocumentTypes
        {
            get { return _documentTypes; }
            set 
            { 
                _documentTypes = value;
                OnPropertyChanged(nameof(DocumentTypes));
            }
        }

        private DocumentTypeModel _selectedDocumentType;

        public DocumentTypeModel SelectedDocumentType
        {
            get { return _selectedDocumentType; }
            set 
            { 
                _selectedDocumentType = value;
                OnPropertyChanged(nameof(SelectedDocumentType));
            }
        }

        private DateTime _selectedDocumentDate = DateTime.Now;
        public DateTime SelectedDocumentDate
        {
            get { return _selectedDocumentDate; }
            set { _selectedDocumentDate = value; }
        }

        private string _selectedDocumentNumber;

        public string SelectedDocumentNumber
        {
            get { return _selectedDocumentNumber; }
            set
            {
                _selectedDocumentNumber = value;
                OnPropertyChanged(nameof(SelectedDocumentNumber));
            }
        }
    }
}
