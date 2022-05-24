CREATE PROCEDURE [dbo].[spClasificationCodeType_Delete]
	@Id int	
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM TipuriClasificare
	WHERE IdTipClasificare = @Id;
END

