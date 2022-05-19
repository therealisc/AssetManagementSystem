CREATE PROCEDURE [dbo].[spRoles_GetUnassigned]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT Roles.Id, Roles.Name as Role
	FROM Roles
END
