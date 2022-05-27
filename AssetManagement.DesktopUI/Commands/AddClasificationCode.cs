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
                MinimumLifetime = _viewModel.SelectedMinimumLifetime,
                MaximumLifetime = _viewModel.SelectedMaximumLifetime,
                ClasificationCodeType = new ClasificationCodeTypeModel() { Id = _viewModel.SelectedAvailableClasification.Id }
            };

            try
            {
                CheckToBeUnique(clasificationCode, _viewModel.ClasificationCodes.ToList());
                CheckClasificationOrder(clasificationCode, _viewModel.ClasificationCodes.ToList(), _viewModel.ClasificationCodeTypes.ToList());
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
                (_viewModel.SelectedMaximumLifetime > _viewModel.SelectedMinimumLifetime ||
                _viewModel.SelectedMinimumLifetime == 0);
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        private void CheckToBeUnique(ClasificationCodeModel clasificationCode, List<ClasificationCodeModel> existingClasificationCodes)
        {
            if (existingClasificationCodes.Select(x => x.ClasificationCode).Contains(clasificationCode.ClasificationCode))
            {
                throw new Exception("Cod de clasificare existent!");
            }
        }

        private void CheckClasificationOrder(ClasificationCodeModel clasificationCode,
            List<ClasificationCodeModel> existingClasificationCodes,
            List<ClasificationCodeTypeModel> existingClasificationTypes)
        {
            //var lastCodeType = existingClasificationCodes
            //    .Where(x => x.ClasificationCode[..1] == clasificationCode.ClasificationCode[..1]) ?
            //    .Select(x => x.ClasificationCodeType)
            //    .OrderBy(x => x.ClasificationRank)
            //    .Last();

            //if (clasificationCode.ClasificationCodeType.ClasificationRank > lastCodeType.ClasificationRank + 1)
            //{
            //    throw new Exception($"Adauga mai intai o {existingClasificationTypes[existingClasificationTypes.IndexOf(clasificationCode.ClasificationCodeType)]}");
            //}
        }
    }
}
