using AssetManagement.DesktopUI.Models;
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
    internal class AddFixedAssetCommand : CommandBase
    {
        private readonly FixedAssetsViewModel _viewModel;
        private readonly FixedAssetData _fixedAssetData;

        public AddFixedAssetCommand(FixedAssetsViewModel viewModel, FixedAssetData fixedAssetData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _fixedAssetData = fixedAssetData;
        }
        public override void Execute(object parameter)
        {
            try
            {
                FixedAssetModel fixedAsset = new FixedAssetModel
                {
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

                FixedAssetBusinessLogicValidation(fixedAsset, _viewModel.AssignedDocuments.ToList());

                _fixedAssetData.AddFixedAsset(fixedAsset, _viewModel.AssignedDocuments.ToList());
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

        private void FixedAssetBusinessLogicValidation(FixedAssetModel fixedAsset, List<DocumentModel> assignedDocuments)
        {
            if (fixedAsset.MonthsOfAccountingDepreciation < 12 || fixedAsset.MonthsOfFiscalDepreciation < 12)
            {
                throw new Exception("Nu se poate adauga un mijloc fix cu o durata mai mica de un an! Verifica lunile de amortizare.");
            }

            if (fixedAsset.MonthsOfFiscalDepreciation < fixedAsset.ClasificationCode.MinimumLifetime * 12 ||
                fixedAsset.MonthsOfFiscalDepreciation > fixedAsset.ClasificationCode.MaximumLifetime * 12)
            {
                throw new Exception("Numarul lunilor de amortizare fiscala trebuie sa fie cuprins intre perioda de functionare minima " +
                    "si perioda de functionare maxima conform codului de clasificare selectat!");
            }

            if (assignedDocuments.Where(x => x.DocumentType.DocumentOperationType != "Intrare").Any())
            {
                if (assignedDocuments.First(x => x.DocumentType.DocumentOperationType == "Intrare").DocumentDate >=
                    assignedDocuments.Where(x => x.DocumentType.DocumentOperationType != "Intrare").OrderBy(x => x.DocumentDate).FirstOrDefault().DocumentDate)
                {
                    throw new Exception("Nu se pot adauga documente a caror data este inainte de data documentului de intrare!");
                }
            }
        }
    }
}
