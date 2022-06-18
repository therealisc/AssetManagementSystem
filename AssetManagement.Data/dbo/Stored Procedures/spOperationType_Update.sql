CREATE PROCEDURE [dbo].[spOperationType_Update]
	@Id int,
	@OperationDescription nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE TipuriOperatii
	SET DescriereOperatie = @OperationDescription
	WHERE IdTipOperatie = @Id;
END
