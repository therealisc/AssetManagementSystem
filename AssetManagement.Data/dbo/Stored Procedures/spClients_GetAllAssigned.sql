CREATE PROCEDURE [dbo].[spClients_GetAllAssigned]
	@UserId int
AS
BEGIN
	SELECT Clienti.IdClient AS [Id] , DenumireClient AS [ClientName], CodFiscalClient AS [FiscalCode], AdresaClient AS [Address] 
	FROM Clienti LEFT JOIN ClientiInLucru ON Clienti.IdClient = ClientiInLucru.IdClient
	WHERE ClientiInLucru.IdUtilizator = @UserId;
END

