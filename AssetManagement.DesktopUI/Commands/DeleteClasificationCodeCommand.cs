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
    internal class DeleteClasificationCodeCommand : CommandBase
    {
        private readonly ClasificationCodesViewModel _viewModel;
        private readonly ClasificationCodeData _clasificatinCodeData;

        public DeleteClasificationCodeCommand(ClasificationCodesViewModel viewModel, ClasificationCodeData clasificatinCodeData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _clasificatinCodeData = clasificatinCodeData;
        }

        public override void Execute(object parameter)
        {
            _clasificatinCodeData.DeleteClasificationCode(_viewModel.SelectedClasificationCodeModel);
            _viewModel.DisplayClasificationCodes();
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedClasificationCodeModel != null;
        }
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

    }
}
