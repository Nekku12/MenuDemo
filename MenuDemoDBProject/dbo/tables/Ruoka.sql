﻿CREATE TABLE [dbo].[Ruoka]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nimi] NVARCHAR(50) NOT NULL, 
    [Hinta] DECIMAL NOT NULL, 
    [Sisaltaa] NVARCHAR(50) NULL 
)
