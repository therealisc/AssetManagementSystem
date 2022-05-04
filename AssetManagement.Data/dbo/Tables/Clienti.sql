CREATE TABLE [dbo].[Clienti]
(
	[IdClient] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DenumireClient] NVARCHAR(50) NOT NULL, 
    [CodFiscalClient] VARCHAR(20) NOT NULL, 
    [AdresaClient] NVARCHAR(MAX) NOT NULL,

)

