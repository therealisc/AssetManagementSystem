CREATE PROCEDURE [dbo].[spDocumentTypes_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT IdTipDocument AS Id, TipOperatieDocument AS DocumentOperationType, DescriereDocument AS DocumentDescription
	FROM TipuriDocumente
END
