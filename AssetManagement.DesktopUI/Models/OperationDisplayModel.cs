﻿using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Models
{
    internal class OperationDisplayModel
    {
        public int Id { get; set; }
        public int InventoryNumber { get; set; }
        public OperationTypeModel OperationType { get; set; }
        public decimal OperationValue { get; set; }
        public DateTime? OperationDate { get; set; }
        public decimal OperationAccountingDepreciation { get; set; }
        public decimal OperationFiscalDepreciation { get; set; }
    }
}
