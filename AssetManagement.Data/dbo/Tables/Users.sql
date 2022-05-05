CREATE TABLE [dbo].[Users] (
    [Id]                   INT NOT NULL IDENTITY, 
    [Email]                NVARCHAR (256) NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[Users]([UserName] ASC);

