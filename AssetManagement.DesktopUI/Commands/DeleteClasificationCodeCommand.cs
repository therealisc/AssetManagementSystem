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
            try
            {
                MessageBoxResult result = MessageBox.Show("Sigur doresti sa stergi codul de clasificare?","Atentie!", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _clasificatinCodeData.DeleteClasificationCode(_viewModel.SelectedClasificationCodeModel);
                    _viewModel.DisplayClasificationCodes();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la stergerea codului de clasificare");
            }
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
