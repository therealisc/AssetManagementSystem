CREATE TABLE [dbo].[TipuriDocumente]
(
	[IdTipDocument] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TipOperatieDocument] NVARCHAR(50) NOT NULL, 
    [DescriereDocument] NVARCHAR(50) NOT NULL,
)
