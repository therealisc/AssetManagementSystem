CREATE PROCEDURE [dbo].[spDocumentType_Insert]
	@DocumentOperationType nvarchar(50),
	@DocumentDescription nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO TipuriDocumente (TipOperatieDocument, DescriereDocument)
	VALUES (@DocumentOperationType, @DocumentDescription);
END