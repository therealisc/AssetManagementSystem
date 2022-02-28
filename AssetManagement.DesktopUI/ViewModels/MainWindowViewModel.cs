using AssetManagement.DesktopUI.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        private readonly NavigationStore _navigationStore;


        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    }
}
