CREATE TABLE [dbo].[AllergJalk]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [JalkiruokaId] INT NULL, 
    [AllergiaId] INT NULL, 
    CONSTRAINT [FK_AllergJalk_Allergia] FOREIGN KEY ([AllergiaId]) REFERENCES [Allergia]([Id]), 
    CONSTRAINT [FK_AllergJalk_Jalkiruoka] FOREIGN KEY ([JalkiruokaId]) REFERENCES [Jalkiruoka]([Id])
)
