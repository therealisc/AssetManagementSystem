CREATE PROCEDURE [dbo].[spDocument_Update]
	@Id int,
	@DocumentNumber varchar(50),
	@DocumentDate datetime2,
	@DocumentTypeId int, 
	@SupplierId int
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE Documente
	SET NumarDocument = @DocumentNumber, DataDocument = @DocumentDate, IdTipDocument = @DocumentTypeId, IdFurnizor = @SupplierId
	WHERE IdDocument = @Id;
END
