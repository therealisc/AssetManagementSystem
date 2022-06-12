using AssetManagement.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    internal class AssignDocumentCommand : CommandBase
    {
        private FixedAssetsViewModel _viewModel;

        public AssignDocumentCommand(FixedAssetsViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            _viewModel.AssignedDocuments.Add(_viewModel.SelectedUnassignedDocument);
            _viewModel.UnassignedDocuments.Remove(_viewModel.SelectedUnassignedDocument);
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedUnassignedDocument != null;
        }
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
