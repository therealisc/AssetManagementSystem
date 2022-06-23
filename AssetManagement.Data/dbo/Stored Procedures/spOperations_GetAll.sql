CREATE PROCEDURE [dbo].[spOperations_GetAll]
	@InventoryNumber int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT IdOperatie AS Id, NumarInventar AS InventoryNumber, Operatii.IdTipOperatie AS OperationTypeId, 
	DescriereOperatie AS OperationDescription, ValoareOperatie AS OperationValue, DataEfectuariiOperatiei AS OperationDate

	FROM Operatii INNER JOIN TipuriOperatii ON TipuriOperatii.IdTipOperatie = Operatii.IdTipOperatie
	WHERE Operatii.NumarInventar = @InventoryNumber;
END
