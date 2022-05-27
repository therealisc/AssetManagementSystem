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
    internal class UpdateClasificationCode : CommandBase
    {
        private readonly ClasificationCodesViewModel _viewModel;
        private readonly ClasificationCodeData _clasificationCodeData;

        public UpdateClasificationCode(ClasificationCodesViewModel viewModel, ClasificationCodeData clasificationCodeData)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            _clasificationCodeData = clasificationCodeData;
        }

        public override void Execute(object parameter)
        {
            try
            {
                ClasificationCodeModel clasificationCode = new()
                {
                    ClasificationCode = _viewModel.SelectedClasificationCodeModel.ClasificationCode,
                    ClasificationCodeDescription = _viewModel.SelectedClasificationCodeDescription,
                    MinimumLifetime = _viewModel.SelectedMinimumLifetime, 
                    MaximumLifetime = _viewModel.SelectedMaximumLifetime,
                    ClasificationCodeType = _viewModel.SelectedAvailableClasification
                };

                _clasificationCodeData.UpdateClasificationCode(clasificationCode);
                _viewModel.DisplayClasificationCodes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedClasificationCodeModel != null &&
                string.IsNullOrWhiteSpace(_viewModel.SelectedClasificationCodeDescription) == false &&
                 (_viewModel.SelectedMaximumLifetime > _viewModel.SelectedMinimumLifetime ||
                 _viewModel.SelectedMinimumLifetime == 0);
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
