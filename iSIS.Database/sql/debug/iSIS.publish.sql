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
The type for column ID in table [dbo].[A] is currently  BIGINT IDENTITY (1, 1) NOT NULL but is being changed to  INT IDENTITY (1, 1) NOT NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[A])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The type for column ClassLevelID in table [dbo].[ClassLevelSection] is currently  BIGINT NULL but is being changed to  INT NULL. Data loss could occur.

The type for column ID in table [dbo].[ClassLevelSection] is currently  BIGINT IDENTITY (1, 1) NOT NULL but is being changed to  INT IDENTITY (1, 1) NOT NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[ClassLevelSection])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The type for column ClassLevelSectionID in table [dbo].[Classroom] is currently  BIGINT NULL but is being changed to  INT NULL. Data loss could occur.

The type for column ID in table [dbo].[Classroom] is currently  BIGINT IDENTITY (1, 1) NOT NULL but is being changed to  INT IDENTITY (1, 1) NOT NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Classroom])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[ClassroomStudent].[ClassSectionID] is being dropped, data loss could occur.

The type for column ClassLevelID in table [dbo].[ClassroomStudent] is currently  BIGINT NULL but is being changed to  INT NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[ClassroomStudent])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[ClassroomTeacher].[ClassSectionID] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[ClassroomTeacher])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The type for column CreditHours in table [dbo].[Course] is currently  FLOAT (53) NULL but is being changed to  REAL NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Course])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[DesiredOutcome].[CurriculumID] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[DesiredOutcome])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Starting rebuilding table [dbo].[A]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_A] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [Code]            NVARCHAR (30)  NULL,
    [EffectiveFrom]   DATETIME2 (7)  NULL,
    [EffectiveTo]     DATETIME2 (7)  NULL,
    [Reference]       NVARCHAR (200) NULL,
    [Remark]          NVARCHAR (400) NULL,
    [ClassLevelID]    BIGINT         NULL,
    [SchoolID]        INT            NULL,
    [ShortTitleMLSID] BIGINT         NULL,
    [TitleMLSID]      BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[A])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_A] ON;
        INSERT INTO [dbo].[tmp_ms_xx_A] ([ID], [Code], [EffectiveFrom], [EffectiveTo], [Reference], [Remark], [ClassLevelID], [SchoolID], [ShortTitleMLSID], [TitleMLSID])
        SELECT   [ID],
                 [Code],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [Reference],
                 [Remark],
                 [ClassLevelID],
                 [SchoolID],
                 [ShortTitleMLSID],
                 [TitleMLSID]
        FROM     [dbo].[A]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_A] OFF;
    END

DROP TABLE [dbo].[A];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_A]', N'A';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[ClassLevel]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ClassLevel] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [CategoryID]      INT            NULL,
    [Code]            NVARCHAR (30)  NULL,
    [EffectiveFrom]   DATETIME2 (7)  NULL,
    [EffectiveTo]     DATETIME2 (7)  NULL,
    [Reference]       NVARCHAR (200) NULL,
    [Remark]          NVARCHAR (400) NULL,
    [LevelNo]         INT            NULL,
    [ShortTitleMLSID] BIGINT         NULL,
    [TitleMLSID]      BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ClassLevel])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ClassLevel] ON;
        INSERT INTO [dbo].[tmp_ms_xx_ClassLevel] ([ID], [CategoryID], [Code], [EffectiveFrom], [EffectiveTo], [Reference], [Remark], [ShortTitleMLSID], [TitleMLSID], [LevelNo])
        SELECT   [ID],
                 [CategoryID],
                 [Code],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [Reference],
                 [Remark],
                 [ShortTitleMLSID],
                 [TitleMLSID],
                 [LevelNo]
        FROM     [dbo].[ClassLevel]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ClassLevel] OFF;
    END

DROP TABLE [dbo].[ClassLevel];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ClassLevel]', N'ClassLevel';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[ClassLevelSection]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ClassLevelSection] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [EffectiveFrom]   DATETIME2 (7)  NULL,
    [EffectiveTo]     DATETIME2 (7)  NULL,
    [Reference]       NVARCHAR (200) NULL,
    [Remark]          NVARCHAR (400) NULL,
    [ClassLevelID]    INT            NULL,
    [SchoolID]        INT            NULL,
    [ShortTitleMLSID] BIGINT         NULL,
    [TitleMLSID]      BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ClassLevelSection])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ClassLevelSection] ON;
        INSERT INTO [dbo].[tmp_ms_xx_ClassLevelSection] ([ID], [EffectiveFrom], [EffectiveTo], [Reference], [Remark], [ClassLevelID], [SchoolID], [ShortTitleMLSID], [TitleMLSID])
        SELECT   [ID],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [Reference],
                 [Remark],
                 [ClassLevelID],
                 [SchoolID],
                 [ShortTitleMLSID],
                 [TitleMLSID]
        FROM     [dbo].[ClassLevelSection]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ClassLevelSection] OFF;
    END

DROP TABLE [dbo].[ClassLevelSection];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ClassLevelSection]', N'ClassLevelSection';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Classroom]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Classroom] (
    [ID]                  INT    IDENTITY (1, 1) NOT NULL,
    [ClassLevelSectionID] INT    NULL,
    [SchoolID]            INT    NULL,
    [RoomID]              BIGINT NULL,
    [SemesterID]          BIGINT NULL,
    [SemesterNo]          INT    NULL,
    [AcademicYear]        INT    NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Classroom])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Classroom] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Classroom] ([ID], [ClassLevelSectionID], [SchoolID], [RoomID], [SemesterID], [SemesterNo], [AcademicYear])
        SELECT   [ID],
                 [ClassLevelSectionID],
                 [SchoolID],
                 [RoomID],
                 [SemesterID],
                 [SemesterNo],
                 [AcademicYear]
        FROM     [dbo].[Classroom]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Classroom] OFF;
    END

DROP TABLE [dbo].[Classroom];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Classroom]', N'Classroom';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[ClassroomStudent]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ClassroomStudent] (
    [ID]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [EffectiveFrom]   DATETIME2 (7)  NULL,
    [EffectiveTo]     DATETIME2 (7)  NULL,
    [Reference]       NVARCHAR (200) NULL,
    [Remark]          NVARCHAR (400) NULL,
    [ClassLevelID]    INT            NULL,
    [ClassroomID]     INT            NULL,
    [GPA]             FLOAT (53)     NULL,
    [SchoolID]        INT            NULL,
    [StudentID]       INT            NULL,
    [ShortTitleMLSID] BIGINT         NULL,
    [TitleMLSID]      BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ClassroomStudent])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ClassroomStudent] ON;
        INSERT INTO [dbo].[tmp_ms_xx_ClassroomStudent] ([ID], [EffectiveFrom], [EffectiveTo], [Reference], [Remark], [ClassLevelID], [SchoolID], [ShortTitleMLSID], [TitleMLSID], [ClassroomID], [GPA], [StudentID])
        SELECT   [ID],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [Reference],
                 [Remark],
                 [ClassLevelID],
                 [SchoolID],
                 [ShortTitleMLSID],
                 [TitleMLSID],
                 [ClassroomID],
                 [GPA],
                 [StudentID]
        FROM     [dbo].[ClassroomStudent]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ClassroomStudent] OFF;
    END

DROP TABLE [dbo].[ClassroomStudent];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ClassroomStudent]', N'ClassroomStudent';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[ClassroomTeacher]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ClassroomTeacher] (
    [ID]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [CategoryID]      INT            NULL,
    [ClassroomID]     INT            NULL,
    [TeacherID]       INT            NULL,
    [EffectiveFrom]   DATETIME2 (7)  NULL,
    [EffectiveTo]     DATETIME2 (7)  NULL,
    [Reference]       NVARCHAR (200) NULL,
    [Remark]          NVARCHAR (400) NULL,
    [ClassLevelID]    BIGINT         NULL,
    [SchoolID]        INT            NULL,
    [ShortTitleMLSID] BIGINT         NULL,
    [TitleMLSID]      BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ClassroomTeacher])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ClassroomTeacher] ON;
        INSERT INTO [dbo].[tmp_ms_xx_ClassroomTeacher] ([ID], [CategoryID], [EffectiveFrom], [EffectiveTo], [Reference], [Remark], [ClassLevelID], [SchoolID], [ShortTitleMLSID], [TitleMLSID], [ClassroomID], [TeacherID])
        SELECT   [ID],
                 [CategoryID],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [Reference],
                 [Remark],
                 [ClassLevelID],
                 [SchoolID],
                 [ShortTitleMLSID],
                 [TitleMLSID],
                 [ClassroomID],
                 [TeacherID]
        FROM     [dbo].[ClassroomTeacher]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ClassroomTeacher] OFF;
    END

DROP TABLE [dbo].[ClassroomTeacher];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ClassroomTeacher]', N'ClassroomTeacher';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Country]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Country] (
    [ID]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [Code]            NVARCHAR (30)  NULL,
    [CurrencyCode]    NCHAR (3)      NULL,
    [EffectiveFrom]   DATETIME2 (7)  NULL,
    [EffectiveTo]     DATETIME2 (7)  NULL,
    [Reference]       NVARCHAR (200) NULL,
    [Remark]          NVARCHAR (400) NULL,
    [ClassLevelID]    BIGINT         NULL,
    [SchoolID]        INT            NULL,
    [ShortTitleMLSID] BIGINT         NULL,
    [TitleMLSID]      BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Country])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Country] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Country] ([ID], [Code], [EffectiveFrom], [EffectiveTo], [Reference], [Remark], [ClassLevelID], [SchoolID], [ShortTitleMLSID], [TitleMLSID], [CurrencyCode])
        SELECT   [ID],
                 [Code],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [Reference],
                 [Remark],
                 [ClassLevelID],
                 [SchoolID],
                 [ShortTitleMLSID],
                 [TitleMLSID],
                 [CurrencyCode]
        FROM     [dbo].[Country]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Country] OFF;
    END

DROP TABLE [dbo].[Country];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Country]', N'Country';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Altering [dbo].[Course]...';


GO
ALTER TABLE [dbo].[Course] ALTER COLUMN [CreditHours] REAL NULL;


GO
PRINT N'Altering [dbo].[Curriculum]...';


GO
ALTER TABLE [dbo].[Curriculum]
    ADD [Reference] NVARCHAR (200) NULL,
        [Remark]    NVARCHAR (400) NULL;


GO
PRINT N'Starting rebuilding table [dbo].[DesiredOutcome]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_DesiredOutcome] (
    [ID]                    BIGINT         IDENTITY (1, 1) NOT NULL,
    [Discriminator]         TINYINT        NULL,
    [Code]                  NVARCHAR (30)  NULL,
    [CurriculumFrameworkID] INT            NULL,
    [ParentID]              BIGINT         NULL,
    [EffectiveFrom]         DATETIME2 (7)  NULL,
    [EffectiveTo]           DATETIME2 (7)  NULL,
    [Reference]             NVARCHAR (200) NULL,
    [Remark]                NVARCHAR (400) NULL,
    [ClassLevelID]          BIGINT         NULL,
    [ShortTitleMLSID]       BIGINT         NULL,
    [TitleMLSID]            BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[DesiredOutcome])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_DesiredOutcome] ON;
        INSERT INTO [dbo].[tmp_ms_xx_DesiredOutcome] ([ID], [Discriminator], [Code], [ParentID], [EffectiveFrom], [EffectiveTo], [Reference], [Remark], [ClassLevelID], [ShortTitleMLSID], [TitleMLSID])
        SELECT   [ID],
                 [Discriminator],
                 [Code],
                 [ParentID],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [Reference],
                 [Remark],
                 [ClassLevelID],
                 [ShortTitleMLSID],
                 [TitleMLSID]
        FROM     [dbo].[DesiredOutcome]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_DesiredOutcome] OFF;
    END

DROP TABLE [dbo].[DesiredOutcome];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_DesiredOutcome]', N'DesiredOutcome';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[Absence]...';


GO
CREATE TABLE [dbo].[Absence] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [AbsenceHours]   NVARCHAR (30)  NULL,
    [CategoryID]     INT            NULL,
    [Date]           DATETIME2 (7)  NULL,
    [Reference]      NVARCHAR (200) NULL,
    [Remark]         NVARCHAR (400) NULL,
    [StudentID]      INT            NULL,
    [ClassSectionID] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Admission]...';


GO
CREATE TABLE [dbo].[Admission] (
    [ID]                    INT           IDENTITY (1, 1) NOT NULL,
    [AdmissionID]           INT           NULL,
    [SeqNo]                 INT           NULL,
    [ApplyFrom]             DATETIME2 (7) NULL,
    [ApplyTo]               DATETIME2 (7) NULL,
    [OrientationDate]       DATETIME2 (7) NULL,
    [RegistrationDate]      DATETIME2 (7) NULL,
    [TestResultPublishDate] DATETIME2 (7) NULL,
    [SemesterID]            INT           NULL,
    [SchoolID]              INT           NULL,
    [DescriptionMLSID]      BIGINT        NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[AdmissionTest]...';


GO
CREATE TABLE [dbo].[AdmissionTest] (
    [ID]               INT           IDENTITY (1, 1) NOT NULL,
    [AdmissionID]      INT           NULL,
    [SeqNo]            INT           NULL,
    [TestFrom]         DATETIME2 (7) NULL,
    [TestTo]           DATETIME2 (7) NULL,
    [DescriptionMLSID] BIGINT        NULL,
    [TitleMLSID]       BIGINT        NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[AdmitCurriculum]...';


GO
CREATE TABLE [dbo].[AdmitCurriculum] (
    [ID]               INT    IDENTITY (1, 1) NOT NULL,
    [AdmissionID]      INT    NULL,
    [Capacity]         INT    NULL,
    [CurriculumID]     INT    NULL,
    [DescriptionMLSID] BIGINT NULL,
    [TitleMLSID]       BIGINT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[AlternateSchool]...';


GO
CREATE TABLE [dbo].[AlternateSchool] (
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
    [Rank]                 INT            NULL,
    [Reference]            NVARCHAR (200) NULL,
    [Remark]               NVARCHAR (400) NULL,
    [StudentApplicationID] INT            NULL,
    [SchoolID]             INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Application]...';


GO
CREATE TABLE [dbo].[Application] (
    [ID]              INT            NOT NULL,
    [Code]            NVARCHAR (30)  NULL,
    [EffectiveFrom]   DATETIME2 (7)  NULL,
    [EffectiveTo]     DATETIME2 (7)  NULL,
    [Reference]       NVARCHAR (200) NULL,
    [Remark]          NVARCHAR (400) NULL,
    [TitleMLSID]      BIGINT         NULL,
    [ShortTitleMLSID] BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[CurriculumCourse]...';


GO
CREATE TABLE [dbo].[CurriculumCourse] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [EffectiveFrom] DATETIME2 (7)  NULL,
    [EffectiveTo]   DATETIME2 (7)  NULL,
    [CategoryID]    INT            NULL,
    [CurriculumID]  INT            NULL,
    [CourseID]      INT            NULL,
    [Reference]     NVARCHAR (200) NULL,
    [Remark]        NVARCHAR (400) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[CurriculumFramework]...';


GO
CREATE TABLE [dbo].[CurriculumFramework] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [EffectiveFrom]   DATETIME2 (7) NULL,
    [EffectiveTo]     DATETIME2 (7) NULL,
    [ShortTitleMLSID] BIGINT        NULL,
    [TitleMLSID]      BIGINT        NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Education]...';


GO
CREATE TABLE [dbo].[Education] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [PersonID]        INT            NULL,
    [EffectiveFrom]   DATETIME2 (7)  NULL,
    [EffectiveTo]     DATETIME2 (7)  NULL,
    [Reference]       NVARCHAR (200) NULL,
    [Remark]          NVARCHAR (400) NULL,
    [ClassLevelID]    BIGINT         NULL,
    [SchoolID]        INT            NULL,
    [ShortTitleMLSID] BIGINT         NULL,
    [TitleMLSID]      BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Experience]...';


GO
CREATE TABLE [dbo].[Experience] (
    [ID]                 INT            IDENTITY (1, 1) NOT NULL,
    [PersonID]           INT            NULL,
    [EffectiveFrom]      DATETIME2 (7)  NULL,
    [EffectiveTo]        DATETIME2 (7)  NULL,
    [Reference]          NVARCHAR (200) NULL,
    [Remark]             NVARCHAR (400) NULL,
    [OrganzationName]    NVARCHAR (200) NULL,
    [OrganzationAddress] NVARCHAR (200) NULL,
    [JobDescription]     NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Photo]...';


GO
CREATE TABLE [dbo].[Photo] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [PersonID]  INT            NULL,
    [Date]      DATETIME2 (7)  NULL,
    [Reference] NVARCHAR (200) NULL,
    [Remark]    NVARCHAR (400) NULL,
    [Image]     NTEXT          NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Role]...';


GO
CREATE TABLE [dbo].[Role] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [Code]             NVARCHAR (30)  NULL,
    [ApplicationID]    INT            NULL,
    [DescriptionMLSID] BIGINT         NULL,
    [ShortTitleMLSID]  BIGINT         NULL,
    [TitleMLSID]       BIGINT         NULL,
    [EffectiveFrom]    DATETIME2 (7)  NULL,
    [EffectiveTo]      DATETIME2 (7)  NULL,
    [Reference]        NVARCHAR (200) NULL,
    [Remark]           NVARCHAR (400) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[UserRole]...';


GO
CREATE TABLE [dbo].[UserRole] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [EffectiveFrom] DATETIME2 (7)  NULL,
    [EffectiveTo]   DATETIME2 (7)  NULL,
    [Reference]     NVARCHAR (200) NULL,
    [Remark]        NVARCHAR (400) NULL,
    [UserID]        INT            NULL,
    [RoleID]        INT            NULL,
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
