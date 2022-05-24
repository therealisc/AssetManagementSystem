CREATE PROCEDURE [dbo].[spClasificationCodeTypes_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT IdTipClasificare AS Id, TipClasificare AS ClasificationType, NivelClasificare AS ClasificationRank
	FROM TipuriClasificare
	ORDER BY NivelClasificare;
END
