using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    internal class DeleteClasificationCodeTypeCommand : CommandBase
    {
        private readonly ClasificationCodesViewModel _viewModel;
        private readonly ClasificationCodeData _clasificationCodeData;

        public DeleteClasificationCodeTypeCommand(ClasificationCodesViewModel viewModel, ClasificationCodeData clasificationCodeData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewMode_PropertyChanged;
            _clasificationCodeData = clasificationCodeData;
        }

        public override void Execute(object parameter)
        {
            _clasificationCodeData.DeleteClasificationCodeType(_viewModel.SelectedClasification);
            _viewModel.DisplayClasificationCodeTypes();
        }

        private void ViewMode_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
