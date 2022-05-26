CREATE PROCEDURE [dbo].[spClasificationCodes_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CodClasificare AS ClasificationCode, DescriereCodClasificare AS ClasificationCodeDescription, 
	DurataFunctionareMinima AS MinimumLifetime, DurataFunctionareMaxima AS MaximumLifetime,
	TipuriClasificare.IdTipClasificare AS ClasificationTypeId, TipClasificare AS ClasificationType
	FROM CatalogCoduriClasificare
	INNER JOIN TipuriClasificare ON CatalogCoduriClasificare.IdTipClasificare = TipuriClasificare.IdTipClasificare
	ORDER BY CodClasificare;
END
