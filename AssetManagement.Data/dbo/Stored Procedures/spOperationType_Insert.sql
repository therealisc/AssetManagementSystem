CREATE PROCEDURE [dbo].[spOperationType_Insert]
	@OperationDescription nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO TipuriOperatii (DescriereOperatie)
	VALUES (@OperationDescription);
END
