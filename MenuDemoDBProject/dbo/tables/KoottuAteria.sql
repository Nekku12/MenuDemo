CREATE TABLE [dbo].[KoottuAteria]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nimi] NVARCHAR(50) NOT NULL, 
    [JuomaId] INT NULL, 
    [SalaattiId] INT NULL, 
    [RuokaId] INT NULL, 
    [JalkiruokaId] INT NULL, 
    [Hinta] DECIMAL NOT NULL, 
    CONSTRAINT [FK_KoottuAteria_Jalkiruoka] FOREIGN KEY ([JalkiruokaId]) REFERENCES [Jalkiruoka]([Id]), 
    CONSTRAINT [FK_KoottuAteria_Ruoka] FOREIGN KEY ([RuokaId]) REFERENCES [Ruoka]([Id]), 
    CONSTRAINT [FK_KoottuAteria_Salaatti] FOREIGN KEY ([SalaattiId]) REFERENCES [Salaatti]([Id]), 
    CONSTRAINT [FK_KoottuAteria_Juoma] FOREIGN KEY ([JuomaId]) REFERENCES [Juoma]([Id])
)
