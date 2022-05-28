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
    internal class AddClasificationCodeTypeCommand : CommandBase
    {
        private readonly ClasificationCodesViewModel _viewModel;
        private readonly ClasificationCodeData _clasificationCodeData;

        public AddClasificationCodeTypeCommand(ClasificationCodesViewModel viewModel, ClasificationCodeData clasificationCodeData)
        {
            _viewModel = viewModel;
            _clasificationCodeData = clasificationCodeData;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            ClasificationCodeTypeModel codeType = new ClasificationCodeTypeModel()
            {
                ClasificationType =  _viewModel.SelectedClasificationCodeType,
                ClasificationRank = _viewModel.SelectedClasificationRank,
            };

            _clasificationCodeData.AddClasificationCodeType(codeType);
            _viewModel.DisplayClasificationCodeTypes();
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.ClasificationCodeTypes.Select(x => x.ClasificationType).Contains(_viewModel.SelectedClasificationCodeType) == false &&
                _viewModel.ClasificationCodeTypes.Select(x => x.ClasificationRank).Contains(_viewModel.SelectedClasificationRank) == false;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
