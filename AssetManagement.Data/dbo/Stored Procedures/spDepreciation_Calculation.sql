CREATE PROCEDURE [dbo].[spDepreciation_Calculation]
	@ClientId int,
	@DateOfReference datetime2
AS
BEGIN	
--------------------------------

		DECLARE @TabelIntrari TABLE (NumarInventar INT, DataIntrarii DATETIME2, NumarDocument VARCHAR(50))

	INSERT INTO @TabelIntrari (NumarInventar, DataIntrarii, NumarDocument)
		SELECT
			MF.NumarInventar,

			(SELECT MAX(DataDocument)
			 FROM MijloaceFixe MFD
			 INNER JOIN DocumenteMijloaceFixe DMF ON MFD.NumarInventar = DMF.NumarInventar
			 INNER JOIN Documente DOC ON DOC.IdDocument = DMF.IdDocument
			 INNER JOIN TipuriDocumente TD ON TD.IdTipDocument = DOC.IdTipDocument
			 WHERE TD.TipOperatieDocument IN ('Intrare','Receptie') AND MFD.NumarInventar = MF.NumarInventar
			 GROUP BY MFD.NumarInventar),

			 DOC.NumarDocument
		FROM
			MijloaceFixe MF
			INNER JOIN DocumenteMijloaceFixe DMF ON MF.NumarInventar = DMF.NumarInventar
			INNER JOIN Documente DOC ON DMF.IdDocument = DOC.IdDocument
		GROUP BY
			MF.NumarInventar, DOC.NumarDocument

	------------------------------
	
	DECLARE @TabelIesiri TABLE (NumarInventar INT, DataIesirii DATETIME2)

	INSERT INTO @TabelIesiri (NumarInventar, DataIesirii)
		SELECT
			MF.NumarInventar,

			(SELECT MAX(DataDocument)
			 FROM MijloaceFixe MFD
			 INNER JOIN DocumenteMijloaceFixe DMF ON MFD.NumarInventar = DMF.NumarInventar
			 INNER JOIN Documente DOC ON DOC.IdDocument = DMF.IdDocument
			 INNER JOIN TipuriDocumente TD ON TD.IdTipDocument = DOC.IdTipDocument
			 WHERE TD.TipOperatieDocument IN ('Iesire') AND MFD.NumarInventar = MF.NumarInventar
			 GROUP BY MFD.NumarInventar)
		FROM
			MijloaceFixe MF
			INNER JOIN DocumenteMijloaceFixe DMF ON MF.NumarInventar = DMF.NumarInventar
			INNER JOIN Documente DOC ON DMF.IdDocument = DOC.IdDocument
		GROUP BY
			MF.NumarInventar

	

	SELECT INTR.NumarInventar AS InventoryNumber, INTR.DataIntrarii AS EntryDate, INTR.NumarDocument AS DocumentNumber, IESR.DataIesirii AS ExitDate,
		   DescriereMijlocFix AS FixedAssetDescription, DurataAmortizareContabila AS MonthsOfAccountingDepreciation, DurataAmortizareFiscala AS MonthsOfFiscalDepreciation, 
		   CCLS.CodClasificare AS ClasificationCode, CCLS.DescriereCodClasificare AS ClasificationCodeDescription,
		   MetodaAmortizareContabila AS AccountingDepreciationMethod, MetodaAmortizareFiscala AS FiscalDepreciationMethod, CAST(ValoareIntrare AS decimal(12,2)) AS AssetValue,
		   
		   DescriereOperatie AS OperationDescription, CAST(ValoareOperatie AS decimal(12,2)) AS OperationValue, DataEfectuariiOperatiei AS OperationDate,

		   CAST(dbo.GetAccumulatedDepreciation(MetodaAmortizareContabila, ValoareIntrare, DurataAmortizareContabila, DataIntrarii, @DateOfReference, DataIesirii, null, 0) AS decimal(12,2)) AS AccountingDepreciation,
		   CAST(dbo.GetAccumulatedDepreciation(MetodaAmortizareFiscala, ValoareIntrare, DurataAmortizareFiscala, DataIntrarii, @DateOfReference, DataIesirii, null, 0) AS decimal(12,2)) AS FiscalDepreciation,

		   dbo.GetAccumulatedDepreciation(MetodaAmortizareContabila, ValoareOperatie, DurataAmortizareContabila, DataIntrarii, @DateOfReference, DataIesirii, DataEfectuariiOperatiei, 1) AS OperationAccountingDepreciation,
		   dbo.GetAccumulatedDepreciation(MetodaAmortizareFiscala, ValoareOperatie, DurataAmortizareFiscala, DataIntrarii, @DateOfReference, DataIesirii, DataEfectuariiOperatiei, 1) AS OperationFiscalDepreciation

	FROM @TabelIntrari INTR
	INNER JOIN @TabelIesiri IESR ON INTR.NumarInventar = IESR.NumarInventar
	INNER JOIN MijloaceFixe MIFX ON MIFX.NumarInventar = INTR.NumarInventar
	INNER JOIN CatalogCoduriClasificare CCLS ON CCLS.CodClasificare = MIFX.CodClasificare
	LEFT JOIN Operatii OPER ON OPER.NumarInventar = MIFX.NumarInventar
	LEFT JOIN TipuriOperatii TIPO ON TIPO.IdTipOperatie = OPER.IdTipOperatie
	WHERE IdClient = @ClientId
	ORDER BY MIFX.NumarInventar


END
