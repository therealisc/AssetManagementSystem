using AssetManagement.DesktopUI.Commands;
using AssetManagement.DesktopUI.Models;
using AssetManagement.DesktopUI.Services;
using AssetManagement.DesktopUI.Services.ReportServices;
using AssetManagement.DesktopUI.Stores;
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
    class HomeViewModel : ViewModelBase
    {
        private readonly ClientData _clientData;
        private readonly AccountStore _accountStore;

        public HomeViewModel(ClientData clientData,
                             AccountStore accountStore,
                             DepreciationData depreciationData,
                             FixedAssetsOperationsAndDepreciationMappingService fixedAssetsOperationsAndDepreciationMappingService,
                             InventoryNumbersReportService inventoryNumbersReportService,
                             FixedAssetSheetReportService fixedAssetSheetReportService,
                             FixedAssetsGeneralReportService fixedAssetsGeneralReportService)
        {
            _clientData = clientData;
            _accountStore = accountStore;

            Clients = new BindingList<FullClientModel>(_clientData.GetClients(_accountStore.CurrentAccount.UserId));

            DepreciationCalculationCommand = new DepreciationCalculationCommand(this, depreciationData, fixedAssetsOperationsAndDepreciationMappingService);
            GenerateInventoryNumbersReportCommand = new GenerateInventoryNumbersReportCommand(this, inventoryNumbersReportService);
            GenerateFixedAssetSheetReportCommand = new GenerateFixedAssetSheetReportCommand(this, fixedAssetSheetReportService);
            GenerateFixedAssetsGeneralReportCommand = new GenerateFixedAssetsGeneralReportCommand(this, fixedAssetsGeneralReportService);
        }
        public ICommand DepreciationCalculationCommand { get; set; }
        public ICommand GenerateInventoryNumbersReportCommand { get; set; }
        public ICommand GenerateFixedAssetSheetReportCommand { get; set; }
        public ICommand GenerateFixedAssetsGeneralReportCommand { get; set; }

        private BindingList<FullClientModel> _clients;

        public BindingList<FullClientModel> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        private FullClientModel _selectedClient;

        public FullClientModel SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        private DateTime _selectedDate = DateTime.Now;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }

        private BindingList<FixedAssetDepreciationDisplayModel> _fixedAssets;

        public BindingList<FixedAssetDepreciationDisplayModel> FixedAssets
        {
            get { return _fixedAssets; }
            set 
            { 
                _fixedAssets = value;
                OnPropertyChanged(nameof(FixedAssets));
            }
        }

        private FixedAssetDepreciationDisplayModel _selectedFixedAsset;

        public FixedAssetDepreciationDisplayModel SelectedFixedAsset
        {
            get { return _selectedFixedAsset; }
            set 
            {
                _selectedFixedAsset = value;
                OnPropertyChanged(nameof(SelectedFixedAsset));
            }
        }


    }
}
