CREATE PROCEDURE [dbo].[spDocuments_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT IdDocument AS Id, NumarDocument AS DocumentNumber, DataDocument AS DocumentDate, TipuriDocumente.IdTipDocument AS DocumentTypeId,
	TipOperatieDocument AS DocumentOperationType, DescriereDocument AS DocumentDescription, Furnizori.IdFurnizor AS SupplierId, 
	DenumireFurnizor AS SupplierName, CodFiscalFurnizor AS FiscalCode
	FROM Documente 
	INNER JOIN TipuriDocumente ON Documente.IdTipDocument = TipuriDocumente.IdTipDocument 
	INNER JOIN Furnizori ON Documente.IdFurnizor = Furnizori.IdFurnizor;
END
