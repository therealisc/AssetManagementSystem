CREATE PROCEDURE [dbo].[spClient_Delete]
	@ClientId int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.Clienti 
	WHERE IdClient = @ClientId;
END
