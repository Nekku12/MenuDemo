﻿CREATE TABLE [dbo].[Ravintola]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nimi] NVARCHAR(50) NOT NULL, 
    [Osoite] NVARCHAR(50) NOT NULL, 
    [PuhelinNro] NVARCHAR(50) NOT NULL 
)