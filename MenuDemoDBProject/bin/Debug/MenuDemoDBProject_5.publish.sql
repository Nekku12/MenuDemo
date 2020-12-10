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
The column [dbo].[Jalkiruoka].[AllergJalkId] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Jalkiruoka])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[Juoma].[AllergJuomId] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Juoma])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[Kategoria].[KategAterId] is being dropped, data loss could occur.

The column [dbo].[Kategoria].[RuokListKatId] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Kategoria])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[Ravintola].[RavRuokListId] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Ravintola])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[Ruoka].[AllergRuokId] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Ruoka])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[RuokaLista].[RavRuokListId] is being dropped, data loss could occur.

The column [dbo].[RuokaLista].[RuokListKatId] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[RuokaLista])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[Salaatti].[AllergSalId] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Salaatti])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping [dbo].[FK_Jalkiruoka_AllergJalk]...';


GO
ALTER TABLE [dbo].[Jalkiruoka] DROP CONSTRAINT [FK_Jalkiruoka_AllergJalk];


GO
PRINT N'Dropping [dbo].[FK_Juoma_AllergJuom]...';


GO
ALTER TABLE [dbo].[Juoma] DROP CONSTRAINT [FK_Juoma_AllergJuom];


GO
PRINT N'Dropping [dbo].[FK_Kategoria_KategAter]...';


GO
ALTER TABLE [dbo].[Kategoria] DROP CONSTRAINT [FK_Kategoria_KategAter];


GO
PRINT N'Dropping [dbo].[FK_Kategoria_RuokListKat]...';


GO
ALTER TABLE [dbo].[Kategoria] DROP CONSTRAINT [FK_Kategoria_RuokListKat];


GO
PRINT N'Dropping [dbo].[FK_Ravintola_RavRuokList]...';


GO
ALTER TABLE [dbo].[Ravintola] DROP CONSTRAINT [FK_Ravintola_RavRuokList];


GO
PRINT N'Dropping [dbo].[FK_Ruoka_AllergRuok]...';


GO
ALTER TABLE [dbo].[Ruoka] DROP CONSTRAINT [FK_Ruoka_AllergRuok];


GO
PRINT N'Dropping [dbo].[FK_RuokaLista_RavRuokList]...';


GO
ALTER TABLE [dbo].[RuokaLista] DROP CONSTRAINT [FK_RuokaLista_RavRuokList];


GO
PRINT N'Dropping [dbo].[FK_RuokaLista_RuokListKat]...';


GO
ALTER TABLE [dbo].[RuokaLista] DROP CONSTRAINT [FK_RuokaLista_RuokListKat];


GO
PRINT N'Dropping [dbo].[FK_Salaatti_AllergSal]...';


GO
ALTER TABLE [dbo].[Salaatti] DROP CONSTRAINT [FK_Salaatti_AllergSal];


GO
PRINT N'Altering [dbo].[Jalkiruoka]...';


GO
ALTER TABLE [dbo].[Jalkiruoka] DROP COLUMN [AllergJalkId];


GO
PRINT N'Altering [dbo].[Juoma]...';


GO
ALTER TABLE [dbo].[Juoma] DROP COLUMN [AllergJuomId];


GO
PRINT N'Altering [dbo].[Kategoria]...';


GO
ALTER TABLE [dbo].[Kategoria] DROP COLUMN [KategAterId], COLUMN [RuokListKatId];


GO
PRINT N'Altering [dbo].[Ravintola]...';


GO
ALTER TABLE [dbo].[Ravintola] DROP COLUMN [RavRuokListId];


GO
PRINT N'Altering [dbo].[Ruoka]...';


GO
ALTER TABLE [dbo].[Ruoka] DROP COLUMN [AllergRuokId];


GO
PRINT N'Altering [dbo].[RuokaLista]...';


GO
ALTER TABLE [dbo].[RuokaLista] DROP COLUMN [RavRuokListId], COLUMN [RuokListKatId];


GO
PRINT N'Altering [dbo].[Salaatti]...';


GO
ALTER TABLE [dbo].[Salaatti] DROP COLUMN [AllergSalId];


GO
PRINT N'Update complete.';


GO