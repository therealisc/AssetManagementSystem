CREATE PROCEDURE [dbo].[spSupplier_Insert]
	@SupplierName nvarchar(50),
	@FiscalCode varchar(20),
	@Address nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Furnizori (DenumireFurnizor, CodFiscalFurnizor, AdresaFurnizor)
	VALUES (@SupplierName, @FiscalCode, @Address);
END
