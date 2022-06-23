CREATE PROCEDURE [dbo].[spOperation_Update]
	@Id int,
	@OperationTypeId int,
	@OperationValue money,
	@OperationDate datetime2
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Operatii
	SET IdTipOperatie = @OperationTypeId, ValoareOperatie = @OperationValue, DataEfectuariiOperatiei = @OperationDate
	WHERE IdOperatie = @Id;
END
