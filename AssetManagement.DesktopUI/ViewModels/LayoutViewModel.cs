using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.ViewModels
{
    public class LayoutViewModel : ObservableRecipient
    {
        public LayoutViewModel(NavigationBarViewModel navigationBarViewModel, ObservableObject contentViewModel)
        {
            NavigationBarViewModel = navigationBarViewModel;
            ContentViewModel = contentViewModel;
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }
        public ObservableObject ContentViewModel { get; }

        

        //internal override void Dispose()
        //{
        //    NavigationBarViewModel.Dispose();
        //    ContentViewModel.Dispose();

        //    base.Dispose();
        //}
    }
}
