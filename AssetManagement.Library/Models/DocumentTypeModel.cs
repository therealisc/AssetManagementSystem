using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.Models
{
    public class DocumentTypeModel
    {
        public int Id { get; set; }
        public string DocumentOperationType { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentTypeInfo
        {
            get
            {
                return $"{DocumentDescription} [{DocumentOperationType}]";
            }
        }
    }
}
