using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.DataAccess
{
    public class DocumentData
    {
        private readonly SqlDataAccess _sqlData;

        public DocumentData(SqlDataAccess sqlData)
        {
            _sqlData = sqlData;
        }

        public List<DocumentTypeModel> GetDocumentTypes()
        {
            var output = _sqlData.LoadData<DocumentTypeModel, dynamic>("dbo.spDocumentTypes_GetAll", new { }, "AssetManagement");
            return output;
        }

        public List<DocumentModel> GetDocuments()
        {
            var dynamicData = _sqlData.LoadData<dynamic, dynamic>("spDocuments_GetAll", new { }, "AssetManagement");

            List<DocumentModel> output = dynamicData.Select(item => new DocumentModel
            {
                Id = item.Id,
                DocumentNumber = item.DocumentNumber,
                DocumentDate = item.DocumentDate,
                DocumentType = new DocumentTypeModel()
                {
                    Id = item.DocumentTypeId,
                    DocumentOperationType = item.DocumentOperationType,
                    DocumentDescription = item.DocumentDescription
                },
                Supplier = new SupplierModel()
                {
                    Id = item.SupplierId,
                    SupplierName = item.SupplierName,
                    FiscalCode = item.FiscalCode
                }
                
            }).ToList();

            return output;
        }

        public void AddDocument(DocumentModel document)
        {
            var parameters = new { document.DocumentNumber, document.DocumentDate, DocumentTypeId = document.DocumentType.Id, SupplierId = document.Supplier.Id };

            _sqlData.SaveData("dbo.spDocument_Insert", parameters, "AssetManagement");
        }

        public void DeleteDocument(DocumentModel document)
        {
            _sqlData.SaveData("dbo.spDocument_Delete", new { DocumentId = document.Id }, "AssetManagement");
        }

        public void UpdateDocument(DocumentModel document)
        {
            var parameters = new { document.Id, document.DocumentNumber, document.DocumentDate, DocumentTypeId = document.DocumentType.Id, SupplierId = document.Supplier.Id };

            _sqlData.SaveData("dbo.spDocument_Update", parameters, "AssetManagement");
        }


    }
}
