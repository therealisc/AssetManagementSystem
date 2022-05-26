using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    internal class UpdateClasificationCodeTypeCommand : CommandBase
    {
        private readonly ClasificationCodesViewModel _viewModel;
        private readonly ClasificationCodeData _clasificatinoCodeData;

        public UpdateClasificationCodeTypeCommand(ClasificationCodesViewModel viewModel, ClasificationCodeData clasificatinoCodeData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _clasificatinoCodeData = clasificatinoCodeData;
        }

        public override void Execute(object parameter)
        {
            ClasificationCodeTypeModel codeType = new ClasificationCodeTypeModel()
            {
                Id = _viewModel.SelectedClasification.Id,
                ClasificationType = _viewModel.SelectedClasificationCodeType,
                ClasificationRank = _viewModel.SelectedClasificationRank
            };

            _clasificatinoCodeData.UpdateClasificationCodeType(codeType);
            _viewModel.DisplayClasificationCodeTypes();
        }
        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedClasification != null;
        }
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
