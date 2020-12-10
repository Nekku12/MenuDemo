CREATE TABLE [dbo].[AllergRuok]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RuokaId] INT NULL, 
    [AllergiaId] INT NULL, 
    CONSTRAINT [FK_AllergRuok_Allergia] FOREIGN KEY ([AllergiaId]) REFERENCES [Allergia]([Id]), 
    CONSTRAINT [FK_AllergRuok_Ruoka] FOREIGN KEY ([RuokaId]) REFERENCES [Ruoka]([Id])
)
