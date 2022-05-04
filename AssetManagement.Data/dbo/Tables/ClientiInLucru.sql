CREATE TABLE [dbo].[ClientiInLucru]
(
	[IdClient] INT NOT NULL,
	[IdUtilizator] INT NOT NULL,
	CONSTRAINT [PK_dbo.ClientiInLucru] PRIMARY KEY CLUSTERED ([IdClient] ASC, [IdUtilizator] ASC),
    CONSTRAINT [FK_dbo.ClientiInLucru.Clienti_IdClient] FOREIGN KEY ([IdClient]) REFERENCES [dbo].[Clienti] ([IdClient]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ClientiInLucru.Users_UserId] FOREIGN KEY ([IdUtilizator]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
)
