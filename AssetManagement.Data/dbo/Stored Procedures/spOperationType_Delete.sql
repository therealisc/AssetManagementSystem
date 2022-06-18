CREATE PROCEDURE [dbo].[spOperationType_Delete]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM TipuriOperatii
	WHERE IdTipOperatie = @Id;
END
