CREATE TABLE [dbo].[KategAter]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [KategoriaId] INT NULL, 
    [AteriaId] INT NULL, 
    CONSTRAINT [FK_KategAter_Kategoria] FOREIGN KEY ([KategoriaId]) REFERENCES [Kategoria]([Id]), 
    CONSTRAINT [FK_KategAter_Ateria] FOREIGN KEY ([AteriaId]) REFERENCES [Ateria]([Id])
)
