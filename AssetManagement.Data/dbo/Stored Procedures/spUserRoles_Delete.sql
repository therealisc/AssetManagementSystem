CREATE PROCEDURE [dbo].[spUserRoles_Delete]
	@UserId int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM UserRoles
	WHERE UserRoles.UserId = @UserId;
END
