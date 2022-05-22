CREATE PROCEDURE [dbo].[spSupplier_Delete]
	@SupplierId int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM Furnizori
	WHERE IdFurnizor = @SupplierId;

END
