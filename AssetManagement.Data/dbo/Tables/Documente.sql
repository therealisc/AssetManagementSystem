CREATE TABLE [dbo].[Documente]
(
	[IdDocument] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NumarDocument] INT NOT NULL, 
    [DataDocument] DATETIME2 NOT NULL, 
    [IdTipDocument] INT NOT NULL,
    [IdFurnizor] INT NULL, 
    CONSTRAINT [FK_dbo.Documente.TipuriDocumente_IdTipDocument] FOREIGN KEY ([IdTipDocument]) REFERENCES [dbo].[TipuriDocumente] ([IdTipDocument]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Documente.Furnizori_IdFurnizor] FOREIGN KEY ([IdFurnizor]) REFERENCES [dbo].[Furnizori] ([IdFurnizor])
)
