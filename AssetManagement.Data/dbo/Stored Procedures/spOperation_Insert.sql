CREATE PROCEDURE [dbo].[spOperation_Insert]
	@InventoryNumber int,
	@OperationTypeId int,
	@OperationValue money,
	@OperationDate datetime2
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Operatii (NumarInventar, IdTipOperatie, ValoareOperatie, DataEfectuariiOperatiei) 
	VALUES (@InventoryNumber, @OperationTypeId, @OperationValue, @OperationDate);
END
