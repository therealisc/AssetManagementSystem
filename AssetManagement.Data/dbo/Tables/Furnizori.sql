CREATE TABLE [dbo].[Furnizori]
(
	[IdFurnizor] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DenumireFurnizor] NVARCHAR(50) NOT NULL, 
    [CodFiscalFurnizor] VARCHAR(20) NOT NULL, 
    [AdresaFurnizor] VARCHAR(MAX) NOT NULL
)
