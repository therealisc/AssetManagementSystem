using AssetManagement.DesktopUI.Services;
using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.DesktopUI.Models;
using AssetManagement.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    class DepreciationCalculationCommand : CommandBase
    {
        private readonly HomeViewModel _viewModel;
        private readonly DepreciationData _depreciationData;
        private readonly FixedAssetsOperationsAndDepreciationMappingService _fixedAssetsOperationsAndDepreciationMappingService;

        public DepreciationCalculationCommand(HomeViewModel viewModel, DepreciationData depreciationData, FixedAssetsOperationsAndDepreciationMappingService fixedAssetsOperationsAndDepreciationMappingService)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _depreciationData = depreciationData;
            _fixedAssetsOperationsAndDepreciationMappingService = fixedAssetsOperationsAndDepreciationMappingService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.FixedAssets = new BindingList<FixedAssetDepreciationDisplayModel>(_fixedAssetsOperationsAndDepreciationMappingService.MapToFixedAssetDepreciationDisplayModel(
                _depreciationData.GetFixedAssets(_viewModel.SelectedClient.Id, _viewModel.SelectedDate).Where(x => _viewModel.SelectedDate >= x.EntryDate).ToList()));
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedClient != null;
        }
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
