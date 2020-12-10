CREATE TABLE [dbo].[RuokListKat]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RuokaListaId] INT NULL, 
    [KategoriaId] INT NULL, 
    CONSTRAINT [FK_RuokListKat_Kategoria] FOREIGN KEY ([KategoriaId]) REFERENCES [Kategoria]([Id]), 
    CONSTRAINT [FK_RuokListKat_RuokaLista] FOREIGN KEY ([RuokaListaId]) REFERENCES [RuokaLista]([Id])
)
