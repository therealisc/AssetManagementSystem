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
    internal class DeleteFixedAssetCommand : CommandBase
    {
        private readonly FixedAssetsViewModel _viewModel;
        private readonly FixedAssetData _fixedAssetData;

        public DeleteFixedAssetCommand(FixedAssetsViewModel viewModel, FixedAssetData fixedAssetData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _fixedAssetData = fixedAssetData;
        }

        public override void Execute(object parameter)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Sigur doresti sa stergi mijlocul fix?", "Atentie!", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                { 
                    _fixedAssetData.DeleteFixedAsset(_viewModel.SelectedFixedAsset.InventoryNumber);
                    _viewModel.DisplayFixedAssets();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la stergerea mijlocului fix");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedFixedAsset != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
