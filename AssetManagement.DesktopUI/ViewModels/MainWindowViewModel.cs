﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.ViewModels
{
    public class MainWindowViewModel : ObservableObject // base class for ViewModels
    {
        private string demoProp;

        public string DemoProp
        {
            get => demoProp;
            set => demoProp = value;
        }
    }
}