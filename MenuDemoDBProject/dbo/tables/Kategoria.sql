CREATE TABLE [dbo].[Kategoria]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nimi] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(400) NULL 
)
