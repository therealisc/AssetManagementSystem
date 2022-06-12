CREATE PROCEDURE [dbo].[spFixedAssets_GetAll]
	@UserId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT MijloaceFixe.NumarInventar AS InventoryNumber, MijloaceFixe.CodClasificare AS ClasificationCode, DescriereCodClasificare AS ClasificationCodeDescription,
	DurataFunctionareMinima AS MinimumLifetime, DurataFunctionareMaxima AS MaximumLifetime, DenumireClient AS ClientName,
	DescriereMijlocFix AS FixedAssetDescription, ContContabil AS AccountId, ValoareIntrare AS AssetValue, DurataAmortizareContabila AS MonthsOfAccountingDepreciation,
	DurataAmortizareFiscala AS MonthsOfFiscalDepreciation, MetodaAmortizareContabila AS AccountingDepreciationMethod, MetodaAmortizareFiscala AS FiscalDepreciationMethod,
	DocumenteMijloaceFixe.IdDocument AS DocumentId --Documente.NumarDocument AS DocumentNumber, DataDocument AS DocumentDate, 
	FROM MijloaceFixe
	INNER JOIN CatalogCoduriClasificare ON MijloaceFixe.CodClasificare = CatalogCoduriClasificare.CodClasificare
	INNER JOIN Clienti ON MijloaceFixe.IdClient = Clienti.IdClient
	INNER JOIN ClientiInLucru ON Clienti.IdClient = ClientiInLucru.IdClient
	INNER JOIN DocumenteMijloaceFixe ON MijloaceFixe.NumarInventar = DocumenteMijloaceFixe.NumarInventar
	WHERE ClientiInLucru.IdUtilizator = @UserId;
END
