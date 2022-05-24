using AssetManagement.DesktopUI.Commands;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AssetManagement.DesktopUI.ViewModels
{
    internal class ClasificationCodesViewModel : ViewModelBase
    {
        private readonly ClasificationCodeData _clasificationCodeData;

        public ClasificationCodesViewModel(ClasificationCodeData clasificationCodeData)
        {
            _clasificationCodeData = clasificationCodeData;

            DisplayClasificationCodeTypes();
            AddClasificationCodeTypeCommand = new AddClasificationCodeTypeCommand(this, clasificationCodeData);
        }

        public ICommand AddClasificationCodeTypeCommand{ get; set; }

        internal void DisplayClasificationCodeTypes()
        {
            ClasificationCodeTypes = new BindingList<ClasificationCodeTypeModel>(_clasificationCodeData.GetClasificationTypes());
        }

        internal void DisplayClasificationCodes()
        {

        }

        private BindingList<ClasificationCodeTypeModel> _clasificationCodeTypes;

        public BindingList<ClasificationCodeTypeModel> ClasificationCodeTypes
        {
            get { return _clasificationCodeTypes; }
            set
            {
                _clasificationCodeTypes = value;
                OnPropertyChanged(nameof(ClasificationCodeTypes));
            }
        }

        private ClasificationCodeTypeModel _selectedClasification;

        public ClasificationCodeTypeModel SelectedClasification
        {
            get { return _selectedClasification; }
            set
            {
                _selectedClasification = value;
                OnPropertyChanged(nameof(SelectedClasification));
            }
        }


        private string _selectedClasificationCodeType;

        public string SelectedClasificationCodeType
        {
            get { return _selectedClasificationCodeType; }
            set
            {
                _selectedClasificationCodeType = value;
                OnPropertyChanged(nameof(SelectedClasificationCodeType));
            }
        }

        private int _selectedClasificationRank;

        public int SelectedClasificationRank
        {
            get { return _selectedClasificationRank; }
            set
            {
                _selectedClasificationRank = value;
                OnPropertyChanged(nameof(SelectedClasificationRank));
            }
        }



    }
}
