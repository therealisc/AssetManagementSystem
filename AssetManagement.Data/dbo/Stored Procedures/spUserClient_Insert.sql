CREATE PROCEDURE [dbo].[spUserClient_Insert]
	@UserId int, 
	@ClientId int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.ClientiInLucru(IdClient, IdUtilizator)
	VALUES (@ClientId, @UserId);
END
