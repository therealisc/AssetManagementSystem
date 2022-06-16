CREATE PROCEDURE [dbo].[spDocumentType_Delete]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM TipuriDocumente
	WHERE IdTipDocument = @Id;
END
