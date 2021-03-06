﻿/*
Deployment script for BooksDatabase

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "BooksDatabase"
:setvar DefaultFilePrefix "BooksDatabase"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\"

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
PRINT N'Dropping [dbo].[AuthorUDT]...';


GO
DROP TYPE [dbo].[AuthorUDT];


GO
PRINT N'Creating [dbo].[AuthorUDT]...';


GO
CREATE TYPE [dbo].[AuthorUDT] AS TABLE (
    [Id]          INT           IDENTITY (1, 1) NOT NULL PRIMARY KEY CLUSTERED ([Id] ASC),
    [FirstName]   NVARCHAR (50) NULL,
    [LastName]    NVARCHAR (50) NULL,
    [DateOfBirth] DATE          NULL);


GO
PRINT N'Creating [dbo].[spBooks_GetAll]...';


GO
CREATE PROCEDURE [dbo].[spBooks_GetAll]
	@authors [AuthorUDT] readonly
AS
BEGIN
	SELECT b.*, (SELECT a.[FirstName],a.[LastName],a.[DateOfBirth]
				 FROM @authors a
				 WHERE a.Id = (SELECT ba.IdAuthor
							   FROM BooksAuthors ba
							   WHERE ba.IdBook = (SELECT b.Id
												  FROM Books b))) AS Authors
	FROM Books b
END
GO
PRINT N'Update complete.';


GO
