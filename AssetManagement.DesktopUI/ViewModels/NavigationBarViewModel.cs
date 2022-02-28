using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AssetManagement.DesktopUI.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
    }
}
