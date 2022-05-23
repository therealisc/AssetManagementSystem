CREATE PROCEDURE [dbo].[spDocument_Delete]
	@DocumentId int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM Documente
	WHERE IdDocument = @DocumentId;
END
