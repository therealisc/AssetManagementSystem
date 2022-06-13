CREATE TABLE [dbo].[MijloaceFixe]
(
	[NumarInventar] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ContContabil] NVARCHAR(50) NOT NULL, 
    [DescriereMijlocFix] NVARCHAR(MAX) NOT NULL, 
    [DurataAmortizareContabila] INT NOT NULL, 
    [DurataAmortizareFiscala] INT NOT NULL, 
    [MetodaAmortizareContabila] NVARCHAR(10) NOT NULL, 
    [MetodaAmortizareFiscala] NVARCHAR(10) NOT NULL, 
    [ValoareIntrare] MONEY NOT NULL, 
    [IdClient] INT NOT NULL, 
    [CodClasificare] VARCHAR(15) NOT NULL,
    CONSTRAINT [FK_dbo.MijloaceFixe.Clienti_IdClient] FOREIGN KEY ([IdClient]) REFERENCES [dbo].[Clienti] ([IdClient]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.MijloaceFixe.CatalogCoduriClasificare_CodClasificare] FOREIGN KEY ([CodClasificare]) REFERENCES [dbo].[CatalogCoduriClasificare] ([CodClasificare]) ON DELETE CASCADE
)
