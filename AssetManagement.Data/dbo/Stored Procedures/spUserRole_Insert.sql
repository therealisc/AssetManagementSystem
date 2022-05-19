CREATE PROCEDURE [dbo].[spUserRole_Insert]
	@UserId int, 
	@RoleId int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.UserRoles(UserId, RoleId)
	VALUES (@UserId, @RoleId);
END
