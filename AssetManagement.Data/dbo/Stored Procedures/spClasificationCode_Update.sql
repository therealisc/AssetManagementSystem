CREATE PROCEDURE [dbo].[spClasificationCode_Update]
	@ClasificationCode varchar(10), 
	@ClasificationCodeDescription varchar(max), 
	@Minimumlifetime int, 
	@Maximumlifetime int,
	@ClasificationTypeId int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE CatalogCoduriClasificare
	SET DescriereCodClasificare = @ClasificationCodeDescription, 
	DurataFunctionareMinima = @Minimumlifetime, DurataFunctionareMaxima = @Maximumlifetime, IdTipClasificare = @ClasificationTypeId
	WHERE CodClasificare = @ClasificationCode;
END
