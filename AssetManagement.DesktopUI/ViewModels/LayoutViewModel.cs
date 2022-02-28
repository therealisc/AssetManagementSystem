﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.ViewModels
{
    public class LayoutViewModel : ViewModelBase
    {
        public LayoutViewModel(NavigationBarViewModel navigationBarViewModel, ViewModelBase contentViewModel)
        {
            NavigationBarViewModel = navigationBarViewModel;
            ContentViewModel = contentViewModel;
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }
        public ViewModelBase ContentViewModel { get; }


        internal override void Dispose()
        {
            NavigationBarViewModel.Dispose();
            ContentViewModel.Dispose();

            base.Dispose();
        }
    }
}
