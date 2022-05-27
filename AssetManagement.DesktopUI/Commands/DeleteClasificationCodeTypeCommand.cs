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

            try
            {
                MessageBoxResult result = MessageBox.Show("Sigur doresti sa stergi tipul de clasificare? Vor fi sterse toate codurile de clasificare de acest tip!", "Atentie!", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _clasificationCodeData.DeleteClasificationCodeType(_viewModel.SelectedClasification);
                    _viewModel.DisplayClasificationCodeTypes();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la stergerea codului de clasificare");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedClasification != null;
        }

        private void ViewMode_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
