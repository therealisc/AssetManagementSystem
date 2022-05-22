CREATE PROCEDURE [dbo].[spClient_Update]
	@Id INT,
	@ClientName NVARCHAR(50),
	@FiscalCode VARCHAR(20), 
	@Address NVARCHAR(max)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.Clienti 
	SET DenumireClient = @ClientName, CodFiscalClient = @FiscalCode, AdresaClient = @Address
	WHERE IdClient = @Id;
END
