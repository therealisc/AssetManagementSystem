CREATE PROCEDURE [dbo].[spUsers_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT UserS.Id, UserName, Email, RoleId, Roles.Name [Role], Clienti.IdClient as ClientId, DenumireClient as ClientName
	FROM Users
	INNER JOIN UserRoles ON Users.Id = UserRoles.UserId INNER JOIN Roles ON Roles.Id = UserRoles.RoleId
	INNER JOIN ClientiInLucru ON Users.Id = ClientiInLucru.IdUtilizator INNER JOIN Clienti ON ClientiInLucru.IdClient = Clienti.IdClient
END