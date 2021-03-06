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
PRINT N'Altering [dbo].[spBooks_InsertBook]...';


GO
ALTER PROCEDURE [dbo].[spBooks_InsertBook]
	@Title NVARCHAR(50),
	@Language NVARCHAR(50),
	@PublishedAt DATE,
	@CreatedAt DATETIME,
	@IdPublisher INT,
	@IdAuthor INT,
	@InsertedId INT OUTPUT
AS
BEGIN
	INSERT INTO Books 
	VALUES(@Title, @Language, @PublishedAt, @CreatedAt, @IdPublisher, @IdAuthor) 
    SET @InsertedId = SCOPE_IDENTITY();
END
GO
PRINT N'Update complete.';


GO
