using AssetManagement.DesktopUI.Commands;
using AssetManagement.DesktopUI.Models;
using AssetManagement.DesktopUI.Services;
using AssetManagement.DesktopUI.Stores;
using AssetManagement.DesktopUI.ValidationRules.BusinessValidationRules;
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
    class FixedAssetsViewModel : ViewModelBase
    {
        private readonly ClientData _clientData;
        private readonly ClasificationCodeData _clasificationCodeData;
        private readonly DocumentData _documentData;
        private readonly FixedAssetData _fixedAssetData;
        private readonly FixedAssetsMappingService _fixedAssetsMappingService;
        private readonly AccountStore _accountStore;

        public FixedAssetsViewModel(
            ClientData clientData,
            ClasificationCodeData clasificationCodeData,
            DocumentData documentData,
            FixedAssetData fixedAssetData,
            FixedAssetsMappingService fixedAssetsMappingService, 
            AccountStore accountStore,
            FixedAssetBusinessValidationRule fixedAssetValidation)
        {
            _clientData = clientData;
            _clasificationCodeData = clasificationCodeData;
            _documentData = documentData;
            _fixedAssetData = fixedAssetData;
            _fixedAssetsMappingService = fixedAssetsMappingService;
            _accountStore = accountStore;

            DisplayFixedAssets();

            AssignDocumentCommand = new AssignDocumentCommand(this);
            UnassignDocumentCommand = new UnassignDocumentCommand(this);

            AddFixedAssetCommand = new AddFixedAssetCommand(this, fixedAssetData, fixedAssetValidation);
            DeleteFixedAssetCommand = new DeleteFixedAssetCommand(this, fixedAssetData);
            UpdateFixedAssetCommand = new UpdateFixedAssetCommand(this, fixedAssetData, fixedAssetValidation);

            Clients = new BindingList<ClientModel>(_clientData.GetClients(_accountStore.CurrentAccount.UserId).ConvertAll(x => (ClientModel)x));
            ClasificationCodes = new BindingList<ClasificationCodeModel>(_clasificationCodeData.GetClasificationCodes());
            DisplayDocuments();
        }

        internal void DisplayFixedAssets()
        {
            FixedAssets = new BindingList<FixedAssetDisplayModel>(_fixedAssetsMappingService.MapToFixedAssetDisplayModel(
                _fixedAssetData.GetFixedAssets(_accountStore.CurrentAccount.UserId)));
        }

        internal void DisplayDocuments()
        {
            UnassignedDocuments = new BindingList<DocumentModel>(_documentData.GetDocuments());
        }

        public ICommand AssignDocumentCommand { get; set; }
        public ICommand UnassignDocumentCommand { get; set; }

        public ICommand AddFixedAssetCommand { get; set; }
        public ICommand DeleteFixedAssetCommand { get; set; }
        public ICommand UpdateFixedAssetCommand { get; set; }

        private BindingList<ClientModel> _clients;

        public BindingList<ClientModel> Clients
        {
            get { return _clients; }
            set 
            { 
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        private ClientModel _selectedClient;

        public ClientModel SelectedClient
        {
            get { return _selectedClient; }
            set 
            { 
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        private BindingList<ClasificationCodeModel> _clasificationCodes;

        public BindingList<ClasificationCodeModel> ClasificationCodes
        {
            get { return _clasificationCodes; }
            set 
            { 
                _clasificationCodes = value;
                OnPropertyChanged(nameof(ClasificationCodes));
            }
        }

        private ClasificationCodeModel _selectedClasificationCode;

        public ClasificationCodeModel SelectedClasificationCode
        {
            get { return _selectedClasificationCode; }
            set 
            { 
                _selectedClasificationCode = value;
                OnPropertyChanged(nameof(SelectedClasificationCode));
            }
        }

        private int _selectedFixedAssetInvertoryNumber;

        public int SelectedFixedAssetInventoryNumber
        {
            get { return _selectedFixedAssetInvertoryNumber; }
            set 
            { 
                _selectedFixedAssetInvertoryNumber = value;
                OnPropertyChanged(nameof(SelectedFixedAssetInventoryNumber));
            }
        }


        private string _selectedFixedAssetDescription;

        public string SelectedFixedAssetDescription
        {
            get { return _selectedFixedAssetDescription; }
            set 
            { 
                _selectedFixedAssetDescription = value;
                OnPropertyChanged(nameof(SelectedFixedAssetDescription));
            }
        }

        private string _selectedFixedAssetAccountId;

        public string SelectedFixedAssetAccountId
        {
            get { return _selectedFixedAssetAccountId; }
            set 
            { 
                _selectedFixedAssetAccountId = value;
                OnPropertyChanged(nameof(SelectedFixedAssetAccountId));
            }
        }

        private decimal _selectedFixedAssetValue;

        public decimal SelectedFixedAssetValue
        {
            get { return _selectedFixedAssetValue; }
            set 
            { 
                _selectedFixedAssetValue = value;
                OnPropertyChanged(nameof(SelectedFixedAssetValue));
            }
        }

        private int _monthsOfAccountingDepreciation;

        public int MonthsOfAccountingDepreciation
        {
            get { return _monthsOfAccountingDepreciation; }
            set 
            {
                _monthsOfAccountingDepreciation = value;
                OnPropertyChanged(nameof(MonthsOfAccountingDepreciation));
            }
        }

        private int _monthsOfFiscalDepreciation;

        public int MonthsOfFiscalDepreciation
        {
            get { return _monthsOfFiscalDepreciation; }
            set 
            { 
                _monthsOfFiscalDepreciation = value;
                OnPropertyChanged(nameof(MonthsOfFiscalDepreciation));
            }
        }

        private List<string> _depreciationMethods = new List<string>() { "Liniara", "Accelerata", "Degresiva" };

        public List<string> DepreciationMethods
        {
            get { return _depreciationMethods; }
            set { _depreciationMethods = value; }
        }


        private string _selectedAccountingDepreciationMethod;

        public string SelectedAccountingDepreciationMethod
        {
            get { return _selectedAccountingDepreciationMethod; }
            set 
            {
                _selectedAccountingDepreciationMethod = value;
                OnPropertyChanged(nameof(SelectedAccountingDepreciationMethod));
            }
        }

        private string _selectedFiscalDepreciationMethod;

        public string SelectedFiscalDepreciationMethod
        {
            get { return _selectedFiscalDepreciationMethod; }
            set 
            { 
                _selectedFiscalDepreciationMethod = value;
                OnPropertyChanged(nameof(SelectedFiscalDepreciationMethod));
            }
        }

        private BindingList<DocumentModel> _unassignedDocuments;

        public BindingList<DocumentModel> UnassignedDocuments
        {
            get { return _unassignedDocuments; }
            set 
            { 
                _unassignedDocuments = value;
                OnPropertyChanged(nameof(UnassignedDocuments));
            }
        }

        private DocumentModel _selectedUnassignedDocument;

        public DocumentModel SelectedUnassignedDocument
        {
            get { return _selectedUnassignedDocument; }
            set 
            { 
                _selectedUnassignedDocument = value;
                OnPropertyChanged(nameof(SelectedUnassignedDocument));
            }
        }

        private BindingList<DocumentModel> _assignedDocuments = new();

        public BindingList<DocumentModel> AssignedDocuments
        {
            get { return _assignedDocuments; }
            set 
            { 
                _assignedDocuments = value;
                OnPropertyChanged(nameof(AssignedDocuments));
            }
        }

        private DocumentModel _selectedAssignedDocument;

        public DocumentModel SelectedAssignedDocument
        {
            get { return _selectedAssignedDocument; }
            set 
            { 
                _selectedAssignedDocument = value;
                OnPropertyChanged(nameof(SelectedAssignedDocument));
            }
        }

        private BindingList<FixedAssetDisplayModel> _fixedAssets;

        public BindingList<FixedAssetDisplayModel> FixedAssets
        {
            get { return _fixedAssets; }
            set 
            { 
                _fixedAssets = value;
                OnPropertyChanged(nameof(FixedAssets));
            }
        }

        private FixedAssetDisplayModel _selectedFixedAsset;

        public FixedAssetDisplayModel SelectedFixedAsset
        {
            get { return _selectedFixedAsset; }
            set 
            {
                if (value != null)
                {
                    _selectedFixedAsset = value;
                    DisplayDocuments();

                    AssignedDocuments = new BindingList<DocumentModel>(UnassignedDocuments.Where(doc => value.AssignedDocuments.Any(x => x.Id == doc.Id)).ToList());

                    SelectedClient = value.Client;
                    SelectedFixedAssetInventoryNumber = value.InventoryNumber;
                    SelectedClasificationCode = value.ClasificationCode;
                    SelectedFixedAssetDescription = value.FixedAssetDescription;
                    SelectedFixedAssetAccountId = value.AccountId;
                    SelectedFixedAssetValue = value.AssetValue;
                    MonthsOfAccountingDepreciation = value.MonthsOfAccountingDepreciation;
                    SelectedAccountingDepreciationMethod = value.AccountingDepreciationMethod;
                    MonthsOfFiscalDepreciation = value.MonthsOfFiscalDepreciation;
                    SelectedFiscalDepreciationMethod = value.FiscalDepreciationMethod;


                    foreach (var document in AssignedDocuments) UnassignedDocuments.RemoveAt(UnassignedDocuments.IndexOf(UnassignedDocuments.First(x => x.Id == document.Id)));

                    OnPropertyChanged(nameof(SelectedFixedAsset));
                }
            }
        }

    }
}
