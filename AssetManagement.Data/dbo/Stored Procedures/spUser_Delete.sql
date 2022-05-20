CREATE PROCEDURE [dbo].[spUser_Delete]
	@UserId int
AS

BEGIN TRANSACTION [DeleteUser]

    BEGIN TRY
    
        DELETE FROM dbo.UserRoles
        WHERE UserRoles.UserId = @UserId;

        DELETE FROM dbo.ClientiInLucru
        WHERE ClientiInLucru.IdUtilizator = @UserId;

        DELETE FROM dbo.Users
        WHERE Users.Id = @UserId;

        COMMIT TRANSACTION [DeleteUser]

    END TRY

    BEGIN CATCH

        ROLLBACK TRANSACTION [DeleteUser]

    END CATCH  
