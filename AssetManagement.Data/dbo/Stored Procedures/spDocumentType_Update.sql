CREATE PROCEDURE [dbo].[spDocumentType_Update]
	@Id int,
	@DocumentOperationType nvarchar(50),
	@DocumentDescription nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE TipuriDocumente
	SET TipOperatieDocument = @DocumentOperationType, DescriereDocument = @DocumentDescription
	WHERE IdTipDocument = @Id;
END