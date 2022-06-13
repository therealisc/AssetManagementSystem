CREATE PROCEDURE [dbo].[spFixedAsset_Update]
	@InventoryNumber int,
	@ClasificationCode varchar(15),
	@ClientId int,
	@FixedAssetDescription nvarchar(max),
	@AccountId nvarchar(50),
	@AssetValue money,
	@MonthsOfAccountingDepreciation int,
	@MonthsOfFiscalDepreciation int, 
	@AccountingDepreciationMethod nvarchar(10),
	@FiscalDepreciationMethod nvarchar(10)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE MijloaceFixe
	SET CodClasificare = @ClasificationCode, IdClient = @ClientId, DescriereMijlocFix = @FixedAssetDescription, ContContabil = @AccountId, ValoareIntrare = @AssetValue, DurataAmortizareContabila = @MonthsOfAccountingDepreciation, 
	DurataAmortizareFiscala = @MonthsOfFiscalDepreciation, MetodaAmortizareContabila = @AccountingDepreciationMethod, MetodaAmortizareFiscala = @FiscalDepreciationMethod
	WHERE NumarInventar = @InventoryNumber;
END
