CREATE PROCEDURE [dbo].[spOperationTypes_GetAll]
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT IdTipOperatie AS Id, DescriereOperatie AS OperationDescription
	FROM TipuriOperatii;
END