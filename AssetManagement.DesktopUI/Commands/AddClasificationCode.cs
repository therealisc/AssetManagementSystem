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
    internal class AddClasificationCode : CommandBase
    {
        private readonly ClasificationCodesViewModel _viewModel;
        private readonly ClasificationCodeData _clasificationCodeData;

        public AddClasificationCode(ClasificationCodesViewModel viewModel, ClasificationCodeData clasificationCodeData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _clasificationCodeData = clasificationCodeData;
        }

        public override void Execute(object parameter)
        {
            ClasificationCodeModel clasificationCode = new ClasificationCodeModel()
            {
                ClasificationCode = _viewModel.SelectedClasificationCode,
                ClasificationCodeDescription = _viewModel.SelectedClasificationCodeDescription,
                MinimumLifetime = _viewModel.SelectedMinimumLifetime.Value,
                MaximumLifetime = _viewModel.SelectedMaximumLifetime.Value,
                ClasificationCodeType = new ClasificationCodeTypeModel() { Id = _viewModel.SelectedAvailableClasification.Id }
            };

            try
            {
                CheckToBeUnique(clasificationCode.ClasificationCode, _viewModel.ClasificationCodes.ToList());
                _clasificationCodeData.AddClasificationCode(clasificationCode);
                _viewModel.DisplayClasificationCodes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedAvailableClasification != null &&
                string.IsNullOrWhiteSpace(_viewModel.SelectedClasificationCodeDescription) == false &&
                string.IsNullOrWhiteSpace(_viewModel.SelectedClasificationCode) == false &&
                _viewModel.SelectedMinimumLifetime >= 0 && 
                _viewModel.SelectedMaximumLifetime > _viewModel.SelectedMinimumLifetime;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        private void CheckToBeUnique(string clasificationCode, List<ClasificationCodeModel> existingClasificationCodes)
        {
            if (existingClasificationCodes.Select(x => x.ClasificationCode).Contains(clasificationCode))
            {
                throw new Exception("Cod de clasificare existent!");
            }
        }

    }
}
