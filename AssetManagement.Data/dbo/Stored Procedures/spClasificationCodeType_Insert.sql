CREATE PROCEDURE [dbo].[spClasificationCodeType_Insert]
	@ClasificationType varchar(50),
	@ClasificationRank int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO TipuriClasificare (TipClasificare, NivelClasificare)
	VALUES (@ClasificationType, @ClasificationRank);
END
