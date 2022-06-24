CREATE PROCEDURE [dbo].[spDepreciation_Calculation]
	@ClientId int,
	@SelectedDate datetime2
AS
BEGIN	
--------------------------------

	DECLARE @TabelIntrari TABLE (NumarInventar INT, DataIntrarii DATETIME2)

	INSERT INTO @TabelIntrari (NumarInventar, DataIntrarii)
		SELECT
			MF.NumarInventar,

			(SELECT MAX(DataDocument)
			 FROM MijloaceFixe MFD
			 INNER JOIN DocumenteMijloaceFixe DMF ON MFD.NumarInventar = DMF.NumarInventar
			 INNER JOIN Documente DOC ON DOC.IdDocument = DMF.IdDocument
			 INNER JOIN TipuriDocumente TD ON TD.IdTipDocument = DOC.IdTipDocument
			 WHERE TD.TipOperatieDocument IN ('Intrare','Receptie') AND MFD.NumarInventar = MF.NumarInventar
			 GROUP BY MFD.NumarInventar)
		FROM
			MijloaceFixe MF
			INNER JOIN DocumenteMijloaceFixe DMF ON MF.NumarInventar = DMF.NumarInventar
			INNER JOIN Documente DOC ON DMF.IdDocument = DOC.IdDocument
		GROUP BY
			MF.NumarInventar

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



	--DECLARE @DateOfReference datetime2 = GETDATE();
	DECLARE @DateOfReference datetime2 = '2026-07-01';
	

	SELECT INTR.NumarInventar, INTR.DataIntrarii, IESR.DataIesirii, 
		   MIFX.DescriereMijlocFix, DurataAmortizareContabila, DurataAmortizareFiscala, MetodaAmortizareContabila, MetodaAmortizareFiscala, ValoareIntrare,
		   
		   ValoareOperatie, DataEfectuariiOperatiei,

		   dbo.GetAccumulatedDepreciation(MetodaAmortizareContabila, ValoareIntrare, DurataAmortizareContabila, DataIntrarii, @DateOfReference, DataIesirii, null, 0) AS AmortizareContabilaActiv,
		   dbo.GetAccumulatedDepreciation(MetodaAmortizareFiscala, ValoareIntrare, DurataAmortizareFiscala, DataIntrarii, @DateOfReference, DataIesirii, null, 0) AS AmortizareFiscalaActiv,

		   dbo.GetAccumulatedDepreciation(MetodaAmortizareContabila, ValoareOperatie, DurataAmortizareContabila, DataIntrarii, @DateOfReference, DataIesirii, DataEfectuariiOperatiei, 1) AS AmortizareContabilaOperatie,
		   dbo.GetAccumulatedDepreciation(MetodaAmortizareFiscala, ValoareOperatie, DurataAmortizareFiscala, DataIntrarii, @DateOfReference, DataIesirii, DataEfectuariiOperatiei, 1) AS AmortizareFiscalaOperatie

	FROM @TabelIntrari INTR
	INNER JOIN @TabelIesiri IESR ON INTR.NumarInventar = IESR.NumarInventar
	INNER JOIN MijloaceFixe MIFX ON MIFX.NumarInventar = INTR.NumarInventar
	LEFT JOIN Operatii OPER ON OPER.NumarInventar = MIFX.NumarInventar
	ORDER BY MIFX.NumarInventar



END
