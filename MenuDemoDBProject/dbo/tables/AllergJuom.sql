CREATE TABLE [dbo].[AllergJuom]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [JuomaId] INT NULL, 
    [AllergiaId] INT NULL, 
    CONSTRAINT [FK_AllergJuom_Allergia] FOREIGN KEY ([AllergiaId]) REFERENCES [Allergia]([Id]), 
    CONSTRAINT [FK_AllergJuom_Juoma] FOREIGN KEY ([JuomaId]) REFERENCES [Juoma]([Id]) 
)
