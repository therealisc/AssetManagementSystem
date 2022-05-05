﻿CREATE PROCEDURE [dbo].[spUser_GetByUsername]
	@Username varchar

AS
BEGIN
	SET NOCOUNT ON;

	SELECT Users.Id, Email, PasswordHash, UserName, Roles.Name as Role
	FROM Users inner join UserRoles ON Users.Id = UserRoles.UserId inner join Roles ON UserRoles.RoleId = Roles.Id
END
