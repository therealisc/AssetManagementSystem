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
            _sqlData.SaveData("dbo.spClasificationCodeType_Insert", new { clasificationCodeType.ClasificationType, clasificationCodeType.ClasificationRank }, "AssetManagement");
        }

        public void DeleteClasificationCodeType(ClasificationCodeTypeModel clasificationCodeType)
        {
            _sqlData.SaveData("dbo.spClasificationCodeType_Delete", new { }, "AssetManagement");
        }

        public void UpdateClasificationCodeType(ClasificationCodeTypeModel clasificationCodeType)
        {
            _sqlData.SaveData("dbo.spClasificatoinCodeType_Update", new { }, "AssetManagement");
        }

        public List<ClasificationCodeModel> GetClasificationCodes()
        {
            var output = _sqlData.LoadData<ClasificationCodeModel, dynamic>("dbo.spClasificationCodes_GetAll", new { }, "AssetManagement");

            return output;
        }

        public void AddClasificationCode(ClasificationCodeModel clasificationCode)
        {
            _sqlData.SaveData("dbo.spClasificationCode_Insert", new { }, "AssetManagement");
        }

        public void DeleteClasificationCode(ClasificationCodeModel clasificationCode)
        {
            _sqlData.SaveData("dbo.spClasificationCode_Delete", new { }, "AssetManagement");
        }

        public void UpdateClasificationCode(ClasificationCodeModel clasificationCode)
        {
            _sqlData.SaveData("dbo.spClasificationCode_Update", new { }, "AssetManagement");
        }
    }
}
