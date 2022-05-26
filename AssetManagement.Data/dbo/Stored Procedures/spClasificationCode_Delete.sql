CREATE PROCEDURE [dbo].[spClasificationCode_Delete]
	@ClasificationCode varchar(10)
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM CatalogCoduriClasificare
	WHERE CodClasificare = @ClasificationCode;
END