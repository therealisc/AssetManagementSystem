CREATE PROCEDURE [dbo].[spFixedAsset_Insert]
	@ClasificationCode varchar(10),
	@ClientId int,
	@FixedAssetDescription nvarchar(max),
	@AccountId nvarchar(50),
	@AssetValue decimal,
	@MonthsOfAccountingDepreciation int,
	@MonthsOfFiscalDepreciation int,
	@AccountingDepreciationMethod nvarchar(10),
	@FiscalDepreciationMethod nvarchar(10)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO MijloaceFixe (CodClasificare, IdClient, DescriereMijlocFix, ContContabil, ValoareIntrare, DurataAmortizareContabila, DurataAmortizareFiscala, MetodaAmortizareContabila, MetodaAmortizareFiscala)
	VALUES (@ClasificationCode, @ClientId, @FixedAssetDescription, @AccountId, @AssetValue, @MonthsOfAccountingDepreciation, @MonthsOfFiscalDepreciation, @AccountingDepreciationMethod, @FiscalDepreciationMethod);
END
