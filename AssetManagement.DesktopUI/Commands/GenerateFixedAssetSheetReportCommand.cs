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
    class GenerateFixedAssetSheetReportCommand : CommandBase
    {
        private readonly HomeViewModel _viewModel;
        private readonly FixedAssetSheetReportService _fixedAssetSheetReportService;

        public GenerateFixedAssetSheetReportCommand(HomeViewModel viewModel, FixedAssetSheetReportService fixedAssetSheetReportService)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _fixedAssetSheetReportService = fixedAssetSheetReportService;
        }

        public override void Execute(object parameter)
        {
            _fixedAssetSheetReportService.GenerateReport(_viewModel.SelectedClient.ClientName, _viewModel.SelectedDate, _viewModel.SelectedFixedAsset);
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.FixedAssets != null && _viewModel.SelectedFixedAsset != null && _viewModel.SelectedFixedAsset.AccountingDepreciationMethod == "Liniara";
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
