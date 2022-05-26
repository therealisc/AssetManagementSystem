CREATE PROCEDURE [dbo].[spClasificationCode_Insert]
	@ClasificationCode varchar(10),
	@ClasificationCodeDescription varchar(max),
	@Minimumlifetime int, 
	@Maximumlifetime int,
	@ClasificationTypeId int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO CatalogCoduriClasificare (CodClasificare, DescriereCodClasificare, DurataFunctionareMinima, DurataFunctionareMaxima, IdTipClasificare)
	VALUES (@ClasificationCode, @ClasificationCodeDescription, @Minimumlifetime, @Maximumlifetime, @ClasificationTypeId);
END
