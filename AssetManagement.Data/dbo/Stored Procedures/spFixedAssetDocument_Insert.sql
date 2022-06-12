CREATE PROCEDURE [dbo].[spFixedAssetDocument_Insert]
	@InventoryNumber int,
	@DocumentId int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO DocumenteMijloaceFixe(NumarInventar, IdDocument)
	VALUES (@InventoryNumber, @DocumentId);
END
