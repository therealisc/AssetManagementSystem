CREATE PROCEDURE [dbo].[spUser_Insert]
	@Username nvarchar(256),
	@Email nvarchar(256),
	@PasswordHash nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Users(UserName, Email, PasswordHash)
	VALUES (@Username, @Email, @PasswordHash);
END
