﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.Models
{
    public class ClasificationCodeModel
    {
        public string ClasificationCode { get; set; }
        public string ClasificationCodeDescription { get; set; }
        public int MinimumLifetime { get; set; }
        public int MaximumLifetime { get; set; }
        public ClasificationCodeTypeModel ClasificationCodeType { get; set; }
        public string ClasificationCodeInfo
        {
            get
            {
                return $"{ClasificationCode} {ClasificationCodeDescription} [{MinimumLifetime} - {MaximumLifetime}]";
            }
        }
    }
}
