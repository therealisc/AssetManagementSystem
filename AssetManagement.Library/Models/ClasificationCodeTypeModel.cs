using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.Models
{
    public class ClasificationCodeTypeModel
    {
        public int Id { get; set; }
        public string ClasificationType { get; set; }
        public int ClasificationRank { get; set; }

        public string ClasificationTypeInfo
        {
            get
            {
                return $"{ClasificationRank} - {ClasificationType}";
            }
        }

    }
}
