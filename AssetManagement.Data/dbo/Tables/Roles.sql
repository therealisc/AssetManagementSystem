﻿CREATE TABLE [dbo].[Roles] (
    [Id]   INT NOT NULL IDENTITY, 
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[Roles]([Name] ASC);
