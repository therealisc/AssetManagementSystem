CREATE PROCEDURE [dbo].[spClasificatoinCodeType_Update]
	@Id int, 
	@ClasificationType varchar(50),
	@ClasificationRank int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE TipuriClasificare
	SET TipClasificare = @ClasificationType, NivelClasificare = @ClasificationRank
	WHERE IdTipClasificare = @Id;
END
