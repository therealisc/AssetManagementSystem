CREATE PROCEDURE [dbo].[spOperation_Delete]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM Operatii
	WHERE IdOperatie = @Id;
END
