CREATE TABLE [dbo].[AllergSal]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SalaattiId] INT NULL, 
    [AllergiaId] INT NULL, 
    CONSTRAINT [FK_AllergSal_Salaatti] FOREIGN KEY ([SalaattiId]) REFERENCES [Salaatti]([Id]), 
    CONSTRAINT [FK_AllergSal_Allergia] FOREIGN KEY ([AllergiaId]) REFERENCES [Allergia]([Id])
)
