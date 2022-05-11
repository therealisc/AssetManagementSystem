CREATE PROCEDURE [dbo].[spClient_Insert]
	@ClientName nvarchar(50),
	@FiscalCode varchar(20), 
	@Address nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Clienti(DenumireClient, CodFiscalClient, AdresaClient)
	VALUES (@ClientName, @FiscalCode, @Address)
END
