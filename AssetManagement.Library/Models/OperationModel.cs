using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.Models
{
    public class OperationModel
    {
        public int Id { get; set; }
        public int InventoryNumber { get; set; }
        public OperationTypeModel OperationType { get; set; }
        public decimal OperationValue { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
