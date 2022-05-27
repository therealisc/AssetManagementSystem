CREATE TABLE [dbo].[CatalogCoduriClasificare]
(
	[CodClasificare] VARCHAR(10) NOT NULL PRIMARY KEY, 
    [DescriereCodClasificare] NVARCHAR(MAX) NOT NULL, 
    [DurataFunctionareMinima] INT NOT NULL, 
    [DurataFunctionareMaxima] INT NOT NULL, 
    [IdTipClasificare] int NOT NULL,
    CONSTRAINT [FK_dbo.CatalogCoduriClasificare.TipuriClasificare_IdTipuriClasificare] FOREIGN KEY ([IdTipClasificare]) REFERENCES [dbo].[TipuriClasificare] ([IdTipClasificare]) ON DELETE CASCADE,
)