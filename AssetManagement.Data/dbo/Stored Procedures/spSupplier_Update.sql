CREATE PROCEDURE [dbo].[spSupplier_Update]
	@Id int, 
	@SupplierName nvarchar(50),
	@FiscalCode varchar(20),
	@Address nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Furnizori
	SET DenumireFurnizor = @SupplierName, CodFiscalFurnizor = @FiscalCode, AdresaFurnizor = @Address
	WHERE IdFurnizor = @Id
END
