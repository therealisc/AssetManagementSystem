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
    class GenerateFixedAssetsGeneralReportCommand : CommandBase
    {
        private readonly HomeViewModel _viewModel;
        private readonly FixedAssetsGeneralReportService _fixedAssetsGeneralReportService;

        public GenerateFixedAssetsGeneralReportCommand(HomeViewModel viewModel, FixedAssetsGeneralReportService fixedAssetsGeneralReportService)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _fixedAssetsGeneralReportService = fixedAssetsGeneralReportService;
        }

        public override void Execute(object parameter)
        {
            _fixedAssetsGeneralReportService.GenerateReport(_viewModel.SelectedClient.ClientName, _viewModel.SelectedDate, _viewModel.FixedAssets.ToList());
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
