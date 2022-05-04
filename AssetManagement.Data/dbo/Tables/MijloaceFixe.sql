CREATE TABLE [dbo].[MijloaceFixe]
(
	[NumarInventar] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ContContabil] NVARCHAR(50) NOT NULL, 
    [DescriereMijlocFix] NVARCHAR(MAX) NOT NULL, 
    [DurataAmortizareContabila] DATETIME2 NOT NULL, 
    [DurataAmortizareFiscala] DATETIME2 NOT NULL, 
    [MetodaAmortizareContabila] NVARCHAR(10) NOT NULL, 
    [ValoareIntrare] DECIMAL(18, 2) NOT NULL, 
    [IdClient] INT NOT NULL, 
    [CodClasificare] VARCHAR(10) NOT NULL,
    CONSTRAINT [FK_dbo.MijloaceFixe.Clienti_IdClient] FOREIGN KEY ([IdClient]) REFERENCES [dbo].[Clienti] ([IdClient]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.MijloaceFixe.CatalogCoduriClasificare_CodClasificare] FOREIGN KEY ([CodClasificare]) REFERENCES [dbo].[CatalogCoduriClasificare] ([CodClasificare]) ON DELETE CASCADE
)
