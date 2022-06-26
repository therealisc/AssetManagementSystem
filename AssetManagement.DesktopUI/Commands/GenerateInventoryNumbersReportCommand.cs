using AssetManagement.DesktopUI.Services.ReportServices;
using AssetManagement.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    class GenerateInventoryNumbersReportCommand : CommandBase
    {
        private readonly HomeViewModel _viewModel;
        private readonly InventoryNumbersReportService _inventoryNumbersReportService;

        public GenerateInventoryNumbersReportCommand(HomeViewModel viewModel, InventoryNumbersReportService inventoryNumbersReportService)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _inventoryNumbersReportService = inventoryNumbersReportService;
        }

        public override void Execute(object parameter)
        {
            _inventoryNumbersReportService.GenerateReport(_viewModel.SelectedClient.ClientName, _viewModel.SelectedDate, _viewModel.FixedAssets.ToList());
        }
        public override bool CanExecute(object parameter)
        {
            return _viewModel.FixedAssets != null;
        }
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
