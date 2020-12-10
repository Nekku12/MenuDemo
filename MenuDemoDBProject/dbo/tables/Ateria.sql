CREATE TABLE [dbo].[Ateria]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY , 
    [Nimi] NVARCHAR(50) NOT NULL, 
    [Sisaltaa] NVARCHAR(400) NULL, 
    [Hinta] DECIMAL NOT NULL, 
    [KoottuAteriaId] INT NULL, 
    [AteriaTyyppiId] INT NULL, 
    CONSTRAINT [FK_Ateria_KoottuAteria] FOREIGN KEY ([KoottuAteriaId]) REFERENCES [KoottuAteria]([Id]), 
    CONSTRAINT [FK_Ateria_AteriaTyyppi] FOREIGN KEY ([AteriaTyyppiId]) REFERENCES [AteriaTyyppi]([Id]), 
)
