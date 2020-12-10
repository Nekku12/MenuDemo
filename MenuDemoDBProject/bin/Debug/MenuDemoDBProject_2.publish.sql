﻿/*
Deployment script for MenuDemoV1

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "MenuDemoV1"
:setvar DefaultFilePrefix "MenuDemoV1"
:setvar DefaultDataPath "C:\Users\aikio\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\aikio\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[RuokaLista].[RavintolaId] on table [dbo].[RuokaLista] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[RuokaLista])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Rename refactoring operation with key 20dc01ba-4592-4b51-b397-2053788ee250 is skipped, element [dbo].[Ateria].[sisaltaa] (SqlSimpleColumn) will not be renamed to Sisaltaa';


GO
PRINT N'Rename refactoring operation with key 0cfd06a4-695d-4d92-b541-4621bc27418b is skipped, element [dbo].[Allergia].[Id] (SqlSimpleColumn) will not be renamed to AllergiaId';


GO
PRINT N'Rename refactoring operation with key aa33e0ad-bb6d-4cd8-b279-c170932f6127 is skipped, element [dbo].[Ravintola].[Id] (SqlSimpleColumn) will not be renamed to RavintolaId';


GO
PRINT N'Rename refactoring operation with key c7bc551d-a48a-48c4-8d79-934cb8110687 is skipped, element [dbo].[Ruoka].[Id] (SqlSimpleColumn) will not be renamed to RuokaId';


GO
PRINT N'Rename refactoring operation with key 07a0e0b6-7a32-4c97-a8e5-bc8df4b4c1cc is skipped, element [dbo].[Ateria].[Id] (SqlSimpleColumn) will not be renamed to AteriaId';


GO
PRINT N'Rename refactoring operation with key ae19f6cb-4f0d-4d1c-ad46-0837a93344b8 is skipped, element [dbo].[Jalkiruoka].[Id] (SqlSimpleColumn) will not be renamed to JalkiruokaId';


GO
PRINT N'Rename refactoring operation with key 01fb1763-8876-4b0b-aeea-23cc440b794e is skipped, element [dbo].[Juoma].[Id] (SqlSimpleColumn) will not be renamed to JuomaId';


GO
PRINT N'The following operation was generated from a refactoring log file 6a52f215-72f8-4a5f-8914-5777a4da62f4';

PRINT N'Rename [dbo].[RuokaLista].[Id] to RuokaListaId';


GO
EXECUTE sp_rename @objname = N'[dbo].[RuokaLista].[Id]', @newname = N'RuokaListaId', @objtype = N'COLUMN';


GO
PRINT N'Rename refactoring operation with key 72e2c2f8-35d4-4c3d-929a-a729fc554e7e is skipped, element [dbo].[Salaatti].[Id] (SqlSimpleColumn) will not be renamed to SalaattiId';


GO
PRINT N'The following operation was generated from a refactoring log file da8ce692-8a9f-4e81-9461-53d2853ab7cc';

PRINT N'Rename [dbo].[Kategoria].[Id] to KategoriaId';


GO
EXECUTE sp_rename @objname = N'[dbo].[Kategoria].[Id]', @newname = N'KategoriaId', @objtype = N'COLUMN';


GO
PRINT N'Rename refactoring operation with key 2858cbb8-560b-4941-b922-cf5f9ea6ac47 is skipped, element [dbo].[Kategoria].[nimi] (SqlSimpleColumn) will not be renamed to Nimi';


GO
PRINT N'Altering [dbo].[RuokaLista]...';


GO
ALTER TABLE [dbo].[RuokaLista]
    ADD [RavintolaId] INT NOT NULL;


GO
PRINT N'Creating [dbo].[Allergia]...';


GO
CREATE TABLE [dbo].[Allergia] (
    [AllergiaId] INT           IDENTITY (1, 1) NOT NULL,
    [Nimi]       NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([AllergiaId] ASC)
);


GO
PRINT N'Creating [dbo].[Ateria]...';


GO
CREATE TABLE [dbo].[Ateria] (
    [AteriaId] INT            IDENTITY (1, 1) NOT NULL,
    [Nimi]     NVARCHAR (50)  NOT NULL,
    [Sisaltaa] NVARCHAR (400) NULL,
    [Hinta]    DECIMAL (18)   NOT NULL,
    PRIMARY KEY CLUSTERED ([AteriaId] ASC)
);


GO
PRINT N'Creating [dbo].[Jalkiruoka]...';


GO
CREATE TABLE [dbo].[Jalkiruoka] (
    [JalkiruokaId] INT            IDENTITY (1, 1) NOT NULL,
    [Nimi]         NVARCHAR (50)  NOT NULL,
    [Hinta]        DECIMAL (18)   NOT NULL,
    [Sisaltaa]     NVARCHAR (400) NULL,
    PRIMARY KEY CLUSTERED ([JalkiruokaId] ASC)
);


GO
PRINT N'Creating [dbo].[Juoma]...';


GO
CREATE TABLE [dbo].[Juoma] (
    [JuomaId] INT           IDENTITY (1, 1) NOT NULL,
    [Nimi]    NVARCHAR (50) NOT NULL,
    [Hinta]   DECIMAL (18)  NOT NULL,
    [AnnosDl] DECIMAL (18)  NULL,
    PRIMARY KEY CLUSTERED ([JuomaId] ASC)
);


GO
PRINT N'Creating [dbo].[KategAter]...';


GO
CREATE TABLE [dbo].[KategAter] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [KategoriaId] INT NOT NULL,
    [AteriaId]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Ravintola]...';


GO
CREATE TABLE [dbo].[Ravintola] (
    [RavintolaId]   INT           IDENTITY (1, 1) NOT NULL,
    [Nimi]          NVARCHAR (50) NOT NULL,
    [Osoite]        NVARCHAR (50) NOT NULL,
    [Puhelinnumero] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([RavintolaId] ASC)
);


GO
PRINT N'Creating [dbo].[Ruoka]...';


GO
CREATE TABLE [dbo].[Ruoka] (
    [RuokaId]  INT           IDENTITY (1, 1) NOT NULL,
    [Nimi]     NVARCHAR (50) NOT NULL,
    [Hinta]    DECIMAL (18)  NOT NULL,
    [Sisaltaa] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([RuokaId] ASC)
);


GO
PRINT N'Creating [dbo].[Salaatti]...';


GO
CREATE TABLE [dbo].[Salaatti] (
    [SalaattiId] INT            IDENTITY (1, 1) NOT NULL,
    [Nimi]       NVARCHAR (50)  NOT NULL,
    [Hinta]      DECIMAL (18)   NOT NULL,
    [Sisaltaa]   NVARCHAR (400) NULL,
    [Kastike]    NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([SalaattiId] ASC)
);


GO
PRINT N'Creating [dbo].[FK_RuokaLista_ToRavintola]...';


GO
ALTER TABLE [dbo].[RuokaLista] WITH NOCHECK
    ADD CONSTRAINT [FK_RuokaLista_ToRavintola] FOREIGN KEY ([RavintolaId]) REFERENCES [dbo].[Ravintola] ([RavintolaId]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '20dc01ba-4592-4b51-b397-2053788ee250')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('20dc01ba-4592-4b51-b397-2053788ee250')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '0cfd06a4-695d-4d92-b541-4621bc27418b')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('0cfd06a4-695d-4d92-b541-4621bc27418b')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'aa33e0ad-bb6d-4cd8-b279-c170932f6127')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('aa33e0ad-bb6d-4cd8-b279-c170932f6127')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c7bc551d-a48a-48c4-8d79-934cb8110687')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c7bc551d-a48a-48c4-8d79-934cb8110687')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '07a0e0b6-7a32-4c97-a8e5-bc8df4b4c1cc')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('07a0e0b6-7a32-4c97-a8e5-bc8df4b4c1cc')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'ae19f6cb-4f0d-4d1c-ad46-0837a93344b8')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('ae19f6cb-4f0d-4d1c-ad46-0837a93344b8')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '01fb1763-8876-4b0b-aeea-23cc440b794e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('01fb1763-8876-4b0b-aeea-23cc440b794e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6a52f215-72f8-4a5f-8914-5777a4da62f4')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6a52f215-72f8-4a5f-8914-5777a4da62f4')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '72e2c2f8-35d4-4c3d-929a-a729fc554e7e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('72e2c2f8-35d4-4c3d-929a-a729fc554e7e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'da8ce692-8a9f-4e81-9461-53d2853ab7cc')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('da8ce692-8a9f-4e81-9461-53d2853ab7cc')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '2858cbb8-560b-4941-b922-cf5f9ea6ac47')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('2858cbb8-560b-4941-b922-cf5f9ea6ac47')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[RuokaLista] WITH CHECK CHECK CONSTRAINT [FK_RuokaLista_ToRavintola];


GO
PRINT N'Update complete.';


GO