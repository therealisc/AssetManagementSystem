CREATE PROCEDURE [dbo].[spFixedAsset_Delete]
	@InventoryNumber int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM MijloaceFixe
	WHERE NumarInventar = @InventoryNumber;
END
