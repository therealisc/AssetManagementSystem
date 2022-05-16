CREATE PROCEDURE [dbo].[spRoles_GetUnassigned]
	@UserId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Roles.Id, Roles.Name as Role
	FROM Roles
	RIGHT JOIN UserRoles ON Roles.Id = UserRoles.RoleId
	WHERE UserId <> @UserId
END
