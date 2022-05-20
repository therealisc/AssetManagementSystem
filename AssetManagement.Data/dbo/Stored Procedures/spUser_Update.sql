CREATE PROCEDURE [dbo].[spUser_Update]
	@UserId int, 
	@Username nvarchar(256),
	@Email nvarchar(256)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Users
	SET UserName = @Username, Email = @Email
	WHERE Id = @UserId;

END
