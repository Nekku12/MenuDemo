﻿CREATE TABLE [dbo].[Jalkiruoka]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nimi] NVARCHAR(50) NOT NULL, 
    [Hinta] DECIMAL NOT NULL, 
    [Sisaltaa] NVARCHAR(400) NULL 
)
