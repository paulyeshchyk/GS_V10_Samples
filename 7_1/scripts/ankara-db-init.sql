
USE [master];
GO

IF EXISTS (SELECT 1 FROM sys.databases WHERE [name] = N'ankara_py')
BEGIN

		DECLARE @SQL nvarchar(1000);
    SET @SQL = N'USE [ankara_py];

                 ALTER DATABASE ankara_py SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                 USE [master];

                 DROP DATABASE ankara_py;';
    EXEC (@SQL);

END


CREATE DATABASE [ankara_py];
GO

USE [ankara_py];
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE LOGIN [migrator] WITH PASSWORD = 'migrator123!'
GO

CREATE SCHEMA app
GO

CREATE USER [migrator] FOR LOGIN [migrator] WITH DEFAULT_SCHEMA=[app]
GO

EXEC sp_addrolemember N'db_owner', N'migrator'
GO

CREATE LOGIN [ankaraUser] WITH PASSWORD = 'user123!'
GO

CREATE USER [ankaraUser] FOR LOGIN [ankaraUser] WITH DEFAULT_SCHEMA=[app]
GO

EXEC sp_addrolemember N'db_owner', N'ankaraUser'
GO
