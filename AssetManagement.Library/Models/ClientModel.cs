using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string FiscalCode { get; set; }
        public string Address { get; set; }
    }
}
