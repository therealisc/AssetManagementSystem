CREATE PROCEDURE [dbo].[spUser_UpdatePassword]
	@UserId INT,
	@PasswordHash VARCHAR(MAX)
AS
BEGIN
	UPDATE Users
	SET PasswordHash = @PasswordHash
	WHERE Id = @UserId
END
