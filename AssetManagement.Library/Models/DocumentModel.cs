using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.Models
{
    public class DocumentModel
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public DocumentTypeModel DocumentType { get; set; }
        public SupplierModel Supplier { get; set; }
    }
}
