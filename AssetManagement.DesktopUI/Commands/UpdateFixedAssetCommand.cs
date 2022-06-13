using AssetManagement.DesktopUI.ValidationRules.BusinessValidationRules;
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
    internal class UpdateFixedAssetCommand : CommandBase
    {
        private readonly FixedAssetsViewModel _viewModel;
        private readonly FixedAssetData _fixedAssetData;
        private readonly FixedAssetBusinessValidationRule _fixedAssetValidation;

        public UpdateFixedAssetCommand(FixedAssetsViewModel viewModel, FixedAssetData fixedAssetData, FixedAssetBusinessValidationRule fixedAssetValidation)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _fixedAssetData = fixedAssetData;
            _fixedAssetValidation = fixedAssetValidation;
        }

        public override void Execute(object parameter)
        {
            try
            {
                FixedAssetModel fixedAsset = new FixedAssetModel
                {
                    InventoryNumber = _viewModel.SelectedFixedAssetInventoryNumber,
                    ClasificationCode = _viewModel.SelectedClasificationCode,
                    Client = _viewModel.SelectedClient,
                    FixedAssetDescription = _viewModel.SelectedFixedAssetDescription,
                    AccountId = _viewModel.SelectedFixedAssetAccountId,
                    AssetValue = _viewModel.SelectedFixedAssetValue,
                    MonthsOfAccountingDepreciation = _viewModel.MonthsOfAccountingDepreciation,
                    MonthsOfFiscalDepreciation = _viewModel.MonthsOfFiscalDepreciation,
                    AccountingDepreciationMethod = _viewModel.SelectedAccountingDepreciationMethod,
                    FiscalDepreciationMethod = _viewModel.SelectedFiscalDepreciationMethod
                };

                _fixedAssetValidation.FixedAssetBusinessLogicValidation(fixedAsset, _viewModel.AssignedDocuments.ToList());

                _fixedAssetData.UpdateFixedAsset(fixedAsset, _viewModel.AssignedDocuments.ToList());
                _viewModel.DisplayFixedAssets();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atentie!");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedClient != null && _viewModel.SelectedClasificationCode != null &&
                _viewModel.SelectedAccountingDepreciationMethod != null && _viewModel.SelectedFiscalDepreciationMethod != null &&
                string.IsNullOrWhiteSpace(_viewModel.SelectedFixedAssetDescription) == false &&
                string.IsNullOrWhiteSpace(_viewModel.SelectedFixedAssetAccountId) == false &&

                _viewModel.AssignedDocuments.Count(x => x.DocumentType.DocumentOperationType == "Intrare") == 1 &&
                _viewModel.AssignedDocuments.Count(x => x.DocumentType.DocumentOperationType == "Receptie") <= 1;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
