CREATE TABLE [dbo].[RavRuokList]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RavintolaId] INT NULL, 
    [RuokaListaId] INT NULL, 
    CONSTRAINT [FK_RavRuokList_RuokaLista] FOREIGN KEY ([RuokaListaId]) REFERENCES [RuokaLista]([Id]), 
    CONSTRAINT [FK_RavRuokList_Ravintola] FOREIGN KEY ([RavintolaId]) REFERENCES [Ravintola]([Id])
)
