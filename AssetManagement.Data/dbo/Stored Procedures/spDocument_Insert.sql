CREATE PROCEDURE [dbo].[spDocument_Insert]
	@DocumentNumber varchar(50), 
	@DocumentDate datetime2,
	@DocumentTypeId int, 
	@SupplierId int

AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Documente (NumarDocument, DataDocument, IdTipDocument, IdFurnizor)
	VALUES (@DocumentNumber, @DocumentDate, @DocumentTypeId, @SupplierId);
END
