CREATE PROCEDURE [dbo].[spDepreciationCalculation]
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
			 WHERE TD.TipOperatieDocument NOT IN ('Intrare','Receptie') AND MFD.NumarInventar = MF.NumarInventar
			 GROUP BY MFD.NumarInventar)
		FROM
			MijloaceFixe MF
			INNER JOIN DocumenteMijloaceFixe DMF ON MF.NumarInventar = DMF.NumarInventar
			INNER JOIN Documente DOC ON DMF.IdDocument = DOC.IdDocument
		GROUP BY
			MF.NumarInventar




	SELECT I.NumarInventar, I.DataIntrarii, 

	--(SELECT DATEDIFF(M, I.DataIntrarii, IE.DataIesirii)) [LuniGestiune],
	
	IE.DataIesirii, MijloaceFixe.*
	FROM @TabelIntrari I
	INNER JOIN @TabelIesiri IE
		ON I.NumarInventar = IE.NumarInventar
		INNER JOIN MijloaceFixe ON MijloaceFixe.NumarInventar = I.NumarInventar

END
