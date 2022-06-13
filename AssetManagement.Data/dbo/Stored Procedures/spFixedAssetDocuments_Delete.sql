CREATE PROCEDURE [dbo].[spFixedAssetDocuments_Delete]
	@InventoryNumber int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM DocumenteMijloaceFixe
	WHERE DocumenteMijloaceFixe.NumarInventar = @InventoryNumber;
END
