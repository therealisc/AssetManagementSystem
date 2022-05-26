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
            DisplayClasificationCodes();
            AddClasificationCodeTypeCommand = new AddClasificationCodeTypeCommand(this, clasificationCodeData);
            DeleteClasificationCodeTypeCommand = new DeleteClasificationCodeTypeCommand(this, clasificationCodeData);
            UpdateClasificationCodeTypeCommand = new UpdateClasificationCodeTypeCommand(this, clasificationCodeData);

            AddClasificationCodeCommand = new AddClasificationCode(this, clasificationCodeData);
            DeleteClasificationCodeCommand = new DeleteClasificationCodeCommand(this, clasificationCodeData); 
        }

        public ICommand AddClasificationCodeTypeCommand { get; }
        public ICommand DeleteClasificationCodeTypeCommand { get; }
        public ICommand UpdateClasificationCodeTypeCommand { get; }

        public ICommand AddClasificationCodeCommand { get; }
        public ICommand DeleteClasificationCodeCommand { get; }
        public ICommand UpdateClasificationCodeCommand { get; }

        internal void DisplayClasificationCodeTypes()
        {
            ClasificationCodeTypes = new BindingList<ClasificationCodeTypeModel>(_clasificationCodeData.GetClasificationTypes());
        }

        internal void DisplayClasificationCodes()
        {
            ClasificationCodes = new BindingList<ClasificationCodeModel>(_clasificationCodeData.GetClasificationCodes());
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

        private ClasificationCodeTypeModel _selectedAvailableClasification;

        public ClasificationCodeTypeModel SelectedAvailableClasification
        {
            get { return _selectedAvailableClasification; }
            set
            {
                _selectedAvailableClasification = value;
                OnPropertyChanged(nameof(SelectedAvailableClasification));
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

        private BindingList<ClasificationCodeModel> _clasificationCodes;

        public BindingList<ClasificationCodeModel> ClasificationCodes
        {
            get { return _clasificationCodes; }
            set
            {
                _clasificationCodes = value;
                OnPropertyChanged(nameof(ClasificationCodes));
            }
        }

        private ClasificationCodeModel _selectedClasficationCodeModel;

        public ClasificationCodeModel SelectedClasificationCodeModel
        {
            get { return _selectedClasficationCodeModel; }
            set
            {
                _selectedClasficationCodeModel = value;
                OnPropertyChanged(nameof(SelectedClasificationCodeModel));
            }
        }

        private string _selectedClasificationCode;

        public string SelectedClasificationCode
        {
            get { return _selectedClasificationCode; }
            set
            {
                _selectedClasificationCode = value;
                OnPropertyChanged(nameof(SelectedClasificationCode));
            }
        }

        private string _selectedClasificationCodeDesription;

        public string SelectedClasificationCodeDescription
        {
            get { return _selectedClasificationCodeDesription; }
            set
            {
                _selectedClasificationCodeDesription = value;
                OnPropertyChanged(nameof(SelectedClasificationCodeDescription));
            }
        }

        private int? _selectedMinimumLifetime;

        public int? SelectedMinimumLifetime
        {
            get { return _selectedMinimumLifetime; }
            set
            {
                if (value == _selectedMinimumLifetime)
                    return;
                _selectedMinimumLifetime = value;
                OnPropertyChanged(nameof(SelectedMinimumLifetime));
            }
        }

        private int? _selectedMaximumLifetime;

        public int? SelectedMaximumLifetime
        {
            get { return _selectedMaximumLifetime; }
            set
            {
                _selectedMaximumLifetime = value;
                OnPropertyChanged(nameof(SelectedMaximumLifetime));
            }
        }

        private ClasificationCodeTypeModel _selectedClasificationType;

        public ClasificationCodeTypeModel SelectedClasificationType
        {
            get { return _selectedClasificationType; }
            set
            {
                _selectedClasificationType = value;
                OnPropertyChanged(nameof(SelectedClasificationType));
            }
        }


    }
}
