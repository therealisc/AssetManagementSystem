CREATE PROCEDURE [dbo].[spSuppliers_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT IdFurnizor AS Id, DenumireFurnizor AS SupplierName, CodFiscalFurnizor AS FiscalCode, AdresaFurnizor AS Address
	FROM Furnizori;
END
