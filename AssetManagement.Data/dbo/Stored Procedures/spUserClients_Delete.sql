CREATE PROCEDURE [dbo].[spUserClients_Delete]
	@UserId int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM ClientiInLucru
	WHERE ClientiInLucru.IdUtilizator = @UserId;
END
