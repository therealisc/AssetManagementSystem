﻿CREATE TABLE [dbo].[Operatii]
(
	[IdOperatie] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ValoareOperatie] DECIMAL(18, 2) NOT NULL, 
    [DataEfectuariiOperatiei] DATETIME2 NOT NULL, 
    [IdTipOperatie] INT NOT NULL,
    [NumarInventar] INT NOT NULL, 
    CONSTRAINT [FK_dbo.Operatii.TipuriOperatii_IdTipOperatie] FOREIGN KEY ([IdTipOperatie]) REFERENCES [dbo].[TipuriOperatii] ([IdTipOperatie]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Operatii.MijloaceFixe_NumarInventar] FOREIGN KEY ([NumarInventar]) REFERENCES [dbo].[MijloaceFixe] ([NumarInventar]) ON DELETE CASCADE,
)
