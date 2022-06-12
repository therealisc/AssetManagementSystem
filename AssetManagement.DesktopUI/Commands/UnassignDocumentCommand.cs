using AssetManagement.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    internal class UnassignDocumentCommand : CommandBase
    {
        private FixedAssetsViewModel _viewModel;

        public UnassignDocumentCommand(FixedAssetsViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object parameter)
        {
            _viewModel.UnassignedDocuments.Add(_viewModel.SelectedAssignedDocument);
            _viewModel.AssignedDocuments.Remove(_viewModel.SelectedAssignedDocument);
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedAssignedDocument != null;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

    }
}
