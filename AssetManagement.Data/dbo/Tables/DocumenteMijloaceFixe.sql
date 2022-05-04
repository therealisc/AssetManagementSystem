CREATE TABLE [dbo].[DocumenteMijloaceFixe]
(
	[NumarInventar] INT NOT NULL,
	[IdDocument] INT NOT NULL,
	CONSTRAINT [PK_dbo.DocumenteMijloaceFixe] PRIMARY KEY CLUSTERED ([NumarInventar] ASC, [IdDocument] ASC),
    CONSTRAINT [FK_dbo.DocumenteMijloaceFixe.MijloaceFixe_NumarInventar] FOREIGN KEY ([NumarInventar]) REFERENCES [dbo].[MijloaceFixe] ([NumarInventar]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.DocumenteMijloaceFixe.Documente_IdDocument] FOREIGN KEY ([IdDocument]) REFERENCES [dbo].[Documente] ([IdDocument]) ON DELETE CASCADE

)
