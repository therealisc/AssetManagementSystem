using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.DataAccess
{
    public class ClasificationCodeData
    {
        private readonly SqlDataAccess _sqlData;

        public ClasificationCodeData(SqlDataAccess sqlData)
        {
            _sqlData = sqlData;
        }

        public List<ClasificationCodeTypeModel> GetClasificationTypes()
        {
            var output = _sqlData.LoadData<ClasificationCodeTypeModel, dynamic>("dbo.spClasificationCodeTypes_GetAll", new { }, "AssetManagement");

            return output;
        }

        public void AddClasificationCodeType(ClasificationCodeTypeModel clasificationCodeType)
        {
            var parameters = new { clasificationCodeType.ClasificationType, clasificationCodeType.ClasificationRank };
            _sqlData.SaveData("dbo.spClasificationCodeType_Insert", parameters, "AssetManagement");
        }

        public void DeleteClasificationCodeType(ClasificationCodeTypeModel clasificationCodeType)
        {
            _sqlData.SaveData("dbo.spClasificationCodeType_Delete", new { clasificationCodeType.Id }, "AssetManagement");
        }

        public void UpdateClasificationCodeType(ClasificationCodeTypeModel clasificationCodeType)
        {
            var parameters = new { clasificationCodeType.Id, clasificationCodeType.ClasificationType, clasificationCodeType.ClasificationRank };
            _sqlData.SaveData("dbo.spClasificatoinCodeType_Update", parameters, "AssetManagement");
        }

        public List<ClasificationCodeModel> GetClasificationCodes()
        {
            var dynamicData = _sqlData.LoadData<dynamic, dynamic>("dbo.spClasificationCodes_GetAll", new { }, "AssetManagement");

            List<ClasificationCodeModel> output = dynamicData.Select(item => new ClasificationCodeModel
            {
                ClasificationCode = item.ClasificationCode,
                ClasificationCodeDescription = item.ClasificationCodeDescription,
                MinimumLifetime = item.MinimumLifetime,
                MaximumLifetime = item.MaximumLifetime,
                ClasificationCodeType = new ClasificationCodeTypeModel
                {
                    Id = item.ClasificationTypeId,
                    ClasificationType = item.ClasificationType,
                }
            }).ToList();

            return output;
        }

        public void AddClasificationCode(ClasificationCodeModel clasificationCode)
        {
            var parameters = new { clasificationCode.ClasificationCode, clasificationCode.ClasificationCodeDescription,
                clasificationCode.MinimumLifetime, clasificationCode.MaximumLifetime,
                ClasificationTypeId = clasificationCode.ClasificationCodeType.Id };

            _sqlData.SaveData("dbo.spClasificationCode_Insert", parameters, "AssetManagement");
        }

        public void DeleteClasificationCode(ClasificationCodeModel clasificationCode)
        {
            _sqlData.SaveData("dbo.spClasificationCode_Delete", new { clasificationCode.ClasificationCode }, "AssetManagement");
        }

        public void UpdateClasificationCode(ClasificationCodeModel clasificationCode)
        {
            var parameters = new { clasificationCode.ClasificationCode, clasificationCode.ClasificationCodeDescription, clasificationCode.MinimumLifetime, 
                clasificationCode.MaximumLifetime, ClasificationTypeId = clasificationCode.ClasificationCodeType.Id};
            _sqlData.SaveData("dbo.spClasificationCode_Update", parameters, "AssetManagement");
        }
    }
}
