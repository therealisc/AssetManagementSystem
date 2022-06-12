CREATE PROCEDURE [dbo].[spClients_GetAll]
AS
BEGIN
	SELECT IdClient AS [Id] , DenumireClient AS [ClientName], CodFiscalClient AS [FiscalCode], AdresaClient AS [Address] 
	FROM Clienti;
END
