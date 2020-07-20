﻿/*
Deployment script for iSIS

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "iSIS"
:setvar DefaultFilePrefix "iSIS"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\"

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
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO

GO
/*
The column [dbo].[HierarchicalCategory].[ClassLevelID] is being dropped, data loss could occur.

The column [dbo].[HierarchicalCategory].[SchoolID] is being dropped, data loss could occur.

The type for column ID in table [dbo].[HierarchicalCategory] is currently  BIGINT IDENTITY (1, 1) NOT NULL but is being changed to  INT IDENTITY (1, 1) NOT NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[HierarchicalCategory])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[Organization].[EmailAddrss] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Organization])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The type for column ID in table [dbo].[Teacher] is currently  BIGINT NOT NULL but is being changed to  INT NOT NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Teacher])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[User].[EffectiveFrom] is being dropped, data loss could occur.

The column [dbo].[User].[EffectiveTo] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[User])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Starting rebuilding table [dbo].[HierarchicalCategory]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_HierarchicalCategory] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [Code]             NVARCHAR (30)  NULL,
    [EffectiveFrom]    DATETIME2 (7)  NULL,
    [EffectiveTo]      DATETIME2 (7)  NULL,
    [Reference]        NVARCHAR (200) NULL,
    [Remark]           NVARCHAR (400) NULL,
    [RootID]           INT            NULL,
    [ParentID]         INT            NULL,
    [DescriptionMLSID] BIGINT         NULL,
    [ShortTitleMLSID]  BIGINT         NULL,
    [TitleMLSID]       BIGINT         NULL,
    [LevelNo]          INT            NULL,
    [SeqNo]            INT            NULL,
    [Weight]           REAL           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[HierarchicalCategory])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_HierarchicalCategory] ON;
        INSERT INTO [dbo].[tmp_ms_xx_HierarchicalCategory] ([ID], [Code], [EffectiveFrom], [EffectiveTo], [Reference], [Remark], [ShortTitleMLSID], [TitleMLSID])
        SELECT   [ID],
                 [Code],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [Reference],
                 [Remark],
                 [ShortTitleMLSID],
                 [TitleMLSID]
        FROM     [dbo].[HierarchicalCategory]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_HierarchicalCategory] OFF;
    END

DROP TABLE [dbo].[HierarchicalCategory];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_HierarchicalCategory]', N'HierarchicalCategory';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Organization]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Organization] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [CurrentNameID]             INT            NULL,
    [Discriminator]             TINYINT        NULL,
    [EffectiveFrom]             DATETIME2 (7)  NULL,
    [EffectiveTo]               DATETIME2 (7)  NULL,
    [Reference]                 NVARCHAR (200) NULL,
    [Remark]                    NVARCHAR (400) NULL,
    [OfficialIDNo]              NVARCHAR (50)  NULL,
    [EmailAddress]              NVARCHAR (50)  NULL,
    [URL]                       NVARCHAR (500) NULL,
    [CategoryID]                INT            NULL,
    [SupervisoryOrganizationID] BIGINT         NULL,
    [MaxClassLevelID]           INT            NULL,
    [MinClassLevelID]           INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Organization])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Organization] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Organization] ([ID], [CurrentNameID], [Discriminator], [EffectiveFrom], [EffectiveTo], [OfficialIDNo], [URL], [CategoryID], [SupervisoryOrganizationID], [MaxClassLevelID], [MinClassLevelID])
        SELECT   [ID],
                 [CurrentNameID],
                 [Discriminator],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [OfficialIDNo],
                 [URL],
                 [CategoryID],
                 [SupervisoryOrganizationID],
                 [MaxClassLevelID],
                 [MinClassLevelID]
        FROM     [dbo].[Organization]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Organization] OFF;
    END

DROP TABLE [dbo].[Organization];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Organization]', N'Organization';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Student]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Student] (
    [ID]                   BIGINT         NOT NULL,
    [IDNo]                 NVARCHAR (20)  NULL,
    [CategoryID]           INT            NULL,
    [PersonID]             INT            NULL,
    [SchoolID]             INT            NULL,
    [EffectiveFrom]        DATETIME2 (7)  NULL,
    [EffectiveTo]          DATETIME2 (7)  NULL,
    [Reference]            NVARCHAR (50)  NULL,
    [Remark]               NVARCHAR (500) NULL,
    [CurriculumID]         INT            NULL,
    [MajorID]              INT            NULL,
    [AdmittedClassLevelID] INT            NULL,
    [AdmittedAcademicYear] INT            NULL,
    [AdmittedSemesterID]   INT            NULL,
    [AdmittedSemesterNo]   INT            NULL,
    [AdmittedGPA]          REAL           NULL,
    [CurrentGPA]           REAL           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Student])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_Student] ([ID], [IDNo], [PersonID], [SchoolID], [EffectiveFrom], [EffectiveTo], [Reference], [Remark])
        SELECT   [ID],
                 [IDNo],
                 [PersonID],
                 [SchoolID],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [Reference],
                 [Remark]
        FROM     [dbo].[Student]
        ORDER BY [ID] ASC;
        
    END

DROP TABLE [dbo].[Student];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Student]', N'Student';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Teacher]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Teacher] (
    [ID]                INT            NOT NULL,
    [IDNo]              NVARCHAR (20)  NULL,
    [CategoryID]        INT            NULL,
    [PersonID]          INT            NULL,
    [SchoolID]          INT            NULL,
    [EffectiveFrom]     DATETIME2 (7)  NULL,
    [EffectiveTo]       DATETIME2 (7)  NULL,
    [Reference]         NVARCHAR (50)  NULL,
    [Remark]            NVARCHAR (500) NULL,
    [StartAcademicYear] INT            NULL,
    [StartSemesterID]   INT            NULL,
    [StartSemesterNo]   INT            NULL,
    [StatusID]          INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Teacher])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_Teacher] ([ID], [IDNo], [PersonID], [SchoolID], [EffectiveFrom], [EffectiveTo], [Reference], [Remark])
        SELECT   [ID],
                 [IDNo],
                 [PersonID],
                 [SchoolID],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [Reference],
                 [Remark]
        FROM     [dbo].[Teacher]
        ORDER BY [ID] ASC;
        
    END

DROP TABLE [dbo].[Teacher];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Teacher]', N'Teacher';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[User]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_User] (
    [ID]                          BIGINT         NOT NULL,
    [SystemID]                    INT            NULL,
    [PersonID]                    BIGINT         NULL,
    [SchoolID]                    INT            NULL,
    [IsDisable]                   BIT            NULL,
    [LastSuccessfulLoginTS]       DATETIME2 (7)  NULL,
    [LastFailedLoginTS]           DATETIME2 (7)  NULL,
    [ConsecutiveFailedLoginCount] INT            NULL,
    [CurrentPasswordID]           BIGINT         NULL,
    [BirthDate]                   DATETIME2 (7)  NULL,
    [DeceasedDate]                DATETIME2 (7)  NULL,
    [Reference]                   NVARCHAR (50)  NULL,
    [Remark]                      NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[User])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_User] ([ID], [SystemID], [PersonID], [SchoolID], [IsDisable], [LastSuccessfulLoginTS], [LastFailedLoginTS], [ConsecutiveFailedLoginCount], [CurrentPasswordID], [Reference], [Remark])
        SELECT   [ID],
                 [SystemID],
                 [PersonID],
                 [SchoolID],
                 [IsDisable],
                 [LastSuccessfulLoginTS],
                 [LastFailedLoginTS],
                 [ConsecutiveFailedLoginCount],
                 [CurrentPasswordID],
                 [Reference],
                 [Remark]
        FROM     [dbo].[User]
        ORDER BY [ID] ASC;
        
    END

DROP TABLE [dbo].[User];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_User]', N'User';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[StudentAcademicYear]...';


GO
CREATE TABLE [dbo].[StudentAcademicYear] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [SchoolID]        INT            NULL,
    [StudentID]       INT            NULL,
    [AcademicYear]    INT            NULL,
    [BehavioralPoint] REAL           NULL,
    [ClassLevelID]    INT            NULL,
    [DeductedPoint]   REAL           NULL,
    [GPA]             REAL           NULL,
    [Reference]       NVARCHAR (200) NULL,
    [Remark]          NVARCHAR (400) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[StudentSemester]...';


GO
CREATE TABLE [dbo].[StudentSemester] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [SchoolID]        INT            NULL,
    [StudentID]       INT            NULL,
    [SemesterID]      INT            NULL,
    [BehavioralPoint] REAL           NULL,
    [ClassLevelID]    INT            NULL,
    [DeductedPoint]   REAL           NULL,
    [GPA]             REAL           NULL,
    [Reference]       NVARCHAR (200) NULL,
    [Remark]          NVARCHAR (400) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO

GO
PRINT N'Update complete.';


GO