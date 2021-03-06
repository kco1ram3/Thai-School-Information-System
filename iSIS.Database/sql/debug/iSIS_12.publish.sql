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
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQL2014\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQL2014\MSSQL\DATA\"

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
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET RECOVERY FULL 
            WITH ROLLBACK IMMEDIATE;
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
The column [dbo].[Absence].[CourseSectionID] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Absence])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[Admission].[Description] is being dropped, data loss could occur.

The column [dbo].[Admission].[Title] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Admission])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[AdmissionTest].[Description] is being dropped, data loss could occur.

The column [dbo].[AdmissionTest].[Title] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[AdmissionTest])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[AdmitCurriculum].[DescriptionMLSID] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[AdmitCurriculum])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[ChartOfAccount].[Description] is being dropped, data loss could occur.

The column [dbo].[ChartOfAccount].[IncreaseBalanceBy] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[ChartOfAccount])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column EffectiveFrom on table [dbo].[Configuration] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[Configuration])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[CourseSectionPerformance].[CourseSectionAppraisalID] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[CourseSectionPerformance])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[Ledger].[Description] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Ledger])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[Organization].[ChartOfAccountID] is being dropped, data loss could occur.

The column [dbo].[Organization].[FiscalYearEndDate] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Organization])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[PerformanceMeasurement].[CourseSectionID] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[PerformanceMeasurement])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The type for column CitizenOfCountryID in table [dbo].[Person] is currently  NCHAR (3) NULL but is being changed to  INT NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Person])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping [dbo].[PartyAddress].[PartyAddress_UIX_PartyIDEffectivePeriod]...';


GO
DROP INDEX [PartyAddress_UIX_PartyIDEffectivePeriod]
    ON [dbo].[PartyAddress];


GO
PRINT N'Dropping [dbo].[PartyIdentity].[PartyIdentity_UIX_PartyIDEffectivePeriod]...';


GO
DROP INDEX [PartyIdentity_UIX_PartyIDEffectivePeriod]
    ON [dbo].[PartyIdentity];


GO
PRINT N'Dropping [dbo].[PersonName].[PersonName_UIX_PersonIDEffectivePeriod]...';


GO
DROP INDEX [PersonName_UIX_PersonIDEffectivePeriod]
    ON [dbo].[PersonName];


GO
PRINT N'Dropping [dbo].[Punishment].[Punishment_StudentID]...';


GO
DROP INDEX [Punishment_StudentID]
    ON [dbo].[Punishment];


GO
PRINT N'Dropping [dbo].[ReceiptItem].[ReceiptItem_IX]...';


GO
DROP INDEX [ReceiptItem_IX]
    ON [dbo].[ReceiptItem];


GO
PRINT N'Dropping [dbo].[ReceiptTemplateItem].[ReceiptTemplateItem]...';


GO
DROP INDEX [ReceiptTemplateItem]
    ON [dbo].[ReceiptTemplateItem];


GO
PRINT N'Dropping [dbo].[ReceivableItem].[ReceivableItem_IX]...';


GO
DROP INDEX [ReceivableItem_IX]
    ON [dbo].[ReceivableItem];


GO
PRINT N'Dropping DF__Accountin__Begin__540C7B00...';


GO
ALTER TABLE [dbo].[AccountingPeriod] DROP CONSTRAINT [DF__Accountin__Begin__540C7B00];


GO
PRINT N'Dropping DF__Accountin__Endin__55009F39...';


GO
ALTER TABLE [dbo].[AccountingPeriod] DROP CONSTRAINT [DF__Accountin__Endin__55009F39];


GO
PRINT N'Dropping DF__ChartOfAc__Balan__3C34F16F...';


GO
ALTER TABLE [dbo].[ChartOfAccount] DROP CONSTRAINT [DF__ChartOfAc__Balan__3C34F16F];


GO
PRINT N'Dropping DF__JournalEn__Balan__44CA3770...';


GO
ALTER TABLE [dbo].[JournalEntry] DROP CONSTRAINT [DF__JournalEn__Balan__44CA3770];


GO
PRINT N'Altering [dbo].[Absence]...';


GO
ALTER TABLE [dbo].[Absence] DROP COLUMN [CourseSectionID];


GO
ALTER TABLE [dbo].[Absence]
    ADD [ClassSectionID] INT NULL;


GO
PRINT N'Starting rebuilding table [dbo].[AccountingPeriod]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_AccountingPeriod] (
    [ID]               INT           IDENTITY (1, 1) NOT NULL,
    [AccountID]        INT           NULL,
    [Balance]          MONEY         DEFAULT (0) NOT NULL,
    [BeginningBalance] MONEY         DEFAULT (0) NOT NULL,
    [EndingBalance]    MONEY         DEFAULT (0) NOT NULL,
    [FiscalYear]       INT           NOT NULL,
    [PeriodNo]         INT           NOT NULL,
    [BeginDate]        DATETIME2 (7) NULL,
    [EndDate]          DATETIME2 (7) NULL,
    [ClosedDate]       DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[AccountingPeriod])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_AccountingPeriod] ON;
        INSERT INTO [dbo].[tmp_ms_xx_AccountingPeriod] ([ID], [AccountID], [BeginningBalance], [EndingBalance], [FiscalYear], [PeriodNo], [BeginDate], [EndDate], [ClosedDate])
        SELECT   [ID],
                 [AccountID],
                 [BeginningBalance],
                 [EndingBalance],
                 [FiscalYear],
                 [PeriodNo],
                 [BeginDate],
                 [EndDate],
                 [ClosedDate]
        FROM     [dbo].[AccountingPeriod]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_AccountingPeriod] OFF;
    END

DROP TABLE [dbo].[AccountingPeriod];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_AccountingPeriod]', N'AccountingPeriod';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[AccountingPeriod].[AccountingPeriod_UIX]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [AccountingPeriod_UIX]
    ON [dbo].[AccountingPeriod]([AccountID] ASC, [FiscalYear] ASC, [PeriodNo] ASC);


GO
PRINT N'Altering [dbo].[Admission]...';


GO
ALTER TABLE [dbo].[Admission] DROP COLUMN [Description], COLUMN [Title];


GO
PRINT N'Altering [dbo].[AdmissionTest]...';


GO
ALTER TABLE [dbo].[AdmissionTest] DROP COLUMN [Description], COLUMN [Title];


GO
ALTER TABLE [dbo].[AdmissionTest]
    ADD [DescriptionMLSID] BIGINT NULL,
        [TitleMLSID]       BIGINT NULL;


GO
PRINT N'Starting rebuilding table [dbo].[AdmitCurriculum]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_AdmitCurriculum] (
    [ID]                      INT            IDENTITY (1, 1) NOT NULL,
    [AdmissionID]             INT            NULL,
    [AdmittedClassLevelID]    INT            NULL,
    [ApplicationFormURL]      NVARCHAR (500) NULL,
    [Capacity]                INT            NULL,
    [CurriculumID]            INT            NULL,
    [Description]             NVARCHAR (500) NULL,
    [DrawingFrom]             DATETIME2 (7)  NULL,
    [DrawingTo]               DATETIME2 (7)  NULL,
    [ForLocalPeopleOnly]      BIT            NULL,
    [RegisterFrom]            DATETIME2 (7)  NULL,
    [RegisterTo]              DATETIME2 (7)  NULL,
    [TestFrom]                DATETIME2 (7)  NULL,
    [TestTo]                  DATETIME2 (7)  NULL,
    [TestResultPublishedDate] DATETIME2 (7)  NULL,
    [Title]                   NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[AdmitCurriculum])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_AdmitCurriculum] ON;
        INSERT INTO [dbo].[tmp_ms_xx_AdmitCurriculum] ([ID], [AdmissionID], [Capacity], [CurriculumID], [AdmittedClassLevelID], [ApplicationFormURL], [Description], [DrawingFrom], [DrawingTo], [ForLocalPeopleOnly], [RegisterFrom], [RegisterTo], [TestFrom], [TestTo], [TestResultPublishedDate], [Title])
        SELECT   [ID],
                 [AdmissionID],
                 [Capacity],
                 [CurriculumID],
                 [AdmittedClassLevelID],
                 [ApplicationFormURL],
                 [Description],
                 [DrawingFrom],
                 [DrawingTo],
                 [ForLocalPeopleOnly],
                 [RegisterFrom],
                 [RegisterTo],
                 [TestFrom],
                 [TestTo],
                 [TestResultPublishedDate],
                 [Title]
        FROM     [dbo].[AdmitCurriculum]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_AdmitCurriculum] OFF;
    END

DROP TABLE [dbo].[AdmitCurriculum];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_AdmitCurriculum]', N'AdmitCurriculum';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[ChartOfAccount]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ChartOfAccount] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [Balance]          MONEY          DEFAULT (0) NOT NULL,
    [CurrentPeriodID]  INT            NULL,
    [Discriminator]    TINYINT        NOT NULL,
    [DescriptionMLSID] BIGINT         NULL,
    [EffectiveFrom]    DATETIME2 (7)  NULL,
    [EffectiveTo]      DATETIME2 (7)  NULL,
    [MonthsPerPeriod]  INT            NULL,
    [OrganizationID]   INT            NULL,
    [ParentCategoryID] INT            NULL,
    [PostingRule]      TINYINT        NULL,
    [Reference]        NVARCHAR (200) NULL,
    [Remark]           NVARCHAR (500) NULL,
    [RootCategoryID]   INT            NULL,
    [ShortTitleMLSID]  BIGINT         NULL,
    [TitleMLSID]       BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ChartOfAccount])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ChartOfAccount] ON;
        INSERT INTO [dbo].[tmp_ms_xx_ChartOfAccount] ([ID], [Balance], [Discriminator], [EffectiveFrom], [EffectiveTo], [OrganizationID], [ParentCategoryID], [Reference], [Remark], [RootCategoryID], [ShortTitleMLSID], [TitleMLSID], [CurrentPeriodID], [MonthsPerPeriod])
        SELECT   [ID],
                 [Balance],
                 [Discriminator],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [OrganizationID],
                 [ParentCategoryID],
                 [Reference],
                 [Remark],
                 [RootCategoryID],
                 [ShortTitleMLSID],
                 [TitleMLSID],
                 [CurrentPeriodID],
                 [MonthsPerPeriod]
        FROM     [dbo].[ChartOfAccount]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ChartOfAccount] OFF;
    END

DROP TABLE [dbo].[ChartOfAccount];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ChartOfAccount]', N'ChartOfAccount';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[ChartOfAccount].[ChartOfAccount_IX]...';


GO
CREATE NONCLUSTERED INDEX [ChartOfAccount_IX]
    ON [dbo].[ChartOfAccount]([OrganizationID] ASC, [RootCategoryID] ASC, [ParentCategoryID] ASC);


GO
PRINT N'Starting rebuilding table [dbo].[Configuration]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Configuration] (
    [ID]                                     INT           IDENTITY (1, 1) NOT NULL,
    [SystemID]                               INT           NOT NULL,
    [EffectiveFrom]                          DATETIME2 (7) NOT NULL,
    [EffectiveTo]                            DATETIME2 (7) NULL,
    [AcademicLevelRootID]                    INT           NULL,
    [BloodGroupRootID]                       INT           NULL,
    [CourseCategoryRootID]                   INT           NULL,
    [GenderRootID]                           INT           NULL,
    [MajorRootID]                            INT           NULL,
    [OccupationRootID]                       INT           NULL,
    [RaceRootID]                             INT           NULL,
    [RelativeCategoryID]                     INT           NULL,
    [ReligionRootID]                         INT           NULL,
    [StudentStatusRootID]                    INT           NULL,
    [SchoolPositionRootID]                   INT           NULL,
    [SchoolSupervisorCategoryRootID]         INT           NULL,
    [DefaultCountryCode]                     NCHAR (3)     NULL,
    [DefaultDateCultureName]                 NVARCHAR (30) NULL,
    [DefaultDateFormat]                      NVARCHAR (50) NULL,
    [DefaultLanguageCode]                    NCHAR (5)     NULL,
    [CurriculumCourseCategoryRootID]         INT           NULL,
    [RoyalDecorationRootID]                  INT           NULL,
    [GuardianCategoryID]                     INT           NULL,
    [FatherCategoryID]                       INT           NULL,
    [MotherCategoryID]                       INT           NULL,
    [PersonPersonRelationshipCategoryRootID] INT           NULL,
    [EducationLevelRootID]                   INT           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Configuration])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Configuration] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Configuration] ([ID], [SystemID], [EffectiveFrom], [EffectiveTo], [AcademicLevelRootID], [BloodGroupRootID], [CourseCategoryRootID], [GenderRootID], [MajorRootID], [OccupationRootID], [RaceRootID], [RelativeCategoryID], [ReligionRootID], [StudentStatusRootID], [SchoolPositionRootID], [SchoolSupervisorCategoryRootID], [DefaultCountryCode], [DefaultDateCultureName], [DefaultDateFormat], [DefaultLanguageCode], [CurriculumCourseCategoryRootID], [RoyalDecorationRootID], [GuardianCategoryID], [FatherCategoryID], [MotherCategoryID], [PersonPersonRelationshipCategoryRootID], [EducationLevelRootID])
        SELECT   [ID],
                 [SystemID],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [AcademicLevelRootID],
                 [BloodGroupRootID],
                 [CourseCategoryRootID],
                 [GenderRootID],
                 [MajorRootID],
                 [OccupationRootID],
                 [RaceRootID],
                 [RelativeCategoryID],
                 [ReligionRootID],
                 [StudentStatusRootID],
                 [SchoolPositionRootID],
                 [SchoolSupervisorCategoryRootID],
                 [DefaultCountryCode],
                 [DefaultDateCultureName],
                 [DefaultDateFormat],
                 [DefaultLanguageCode],
                 [CurriculumCourseCategoryRootID],
                 [RoyalDecorationRootID],
                 [GuardianCategoryID],
                 [FatherCategoryID],
                 [MotherCategoryID],
                 [PersonPersonRelationshipCategoryRootID],
                 [EducationLevelRootID]
        FROM     [dbo].[Configuration]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Configuration] OFF;
    END

DROP TABLE [dbo].[Configuration];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Configuration]', N'Configuration';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[CourseSectionPerformance]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_CourseSectionPerformance] (
    [ID]                       BIGINT         IDENTITY (1, 1) NOT NULL,
    [CourseSectionAppriasalID] INT            NULL,
    [CourseSectionStudentID]   INT            NULL,
    [AppraisalDate]            DATETIME2 (7)  NULL,
    [Score]                    REAL           NULL,
    [Remark]                   NVARCHAR (400) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[CourseSectionPerformance])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_CourseSectionPerformance] ON;
        INSERT INTO [dbo].[tmp_ms_xx_CourseSectionPerformance] ([ID], [CourseSectionStudentID], [AppraisalDate], [Score], [Remark])
        SELECT   [ID],
                 [CourseSectionStudentID],
                 [AppraisalDate],
                 [Score],
                 [Remark]
        FROM     [dbo].[CourseSectionPerformance]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_CourseSectionPerformance] OFF;
    END

DROP TABLE [dbo].[CourseSectionPerformance];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_CourseSectionPerformance]', N'CourseSectionPerformance';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Curriculum]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Curriculum] (
    [ID]                    INT            IDENTITY (1, 1) NOT NULL,
    [EffectiveFrom]         DATETIME2 (7)  NULL,
    [EffectiveTo]           DATETIME2 (7)  NULL,
    [CurriculumFrameworkID] INT            NULL,
    [ShortTitleMLSID]       BIGINT         NULL,
    [TitleMLSID]            BIGINT         NULL,
    [SchoolID]              INT            NULL,
    [StartingClassLevelID]  INT            NULL,
    [EndingClassLevelID]    INT            NULL,
    [Reference]             NVARCHAR (200) NULL,
    [Remark]                NVARCHAR (400) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Curriculum])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Curriculum] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Curriculum] ([ID], [EffectiveFrom], [EffectiveTo], [CurriculumFrameworkID], [ShortTitleMLSID], [TitleMLSID], [Reference], [Remark], [SchoolID], [StartingClassLevelID], [EndingClassLevelID])
        SELECT   [ID],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [CurriculumFrameworkID],
                 [ShortTitleMLSID],
                 [TitleMLSID],
                 [Reference],
                 [Remark],
                 [SchoolID],
                 [StartingClassLevelID],
                 [EndingClassLevelID]
        FROM     [dbo].[Curriculum]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Curriculum] OFF;
    END

DROP TABLE [dbo].[Curriculum];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Curriculum]', N'Curriculum';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[Curriculum].[Curriculum_UIX_School]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [Curriculum_UIX_School]
    ON [dbo].[Curriculum]([SchoolID] ASC, [EffectiveFrom] ASC, [EffectiveTo] ASC, [StartingClassLevelID] ASC, [EndingClassLevelID] ASC)
    ON [PRIMARY];


GO
PRINT N'Starting rebuilding table [dbo].[JournalEntry]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_JournalEntry] (
    [ID]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [Discriminator] TINYINT       NOT NULL,
    [AccountID]     INT           NULL,
    [Amount]        MONEY         NULL,
    [BalanceType]   TINYINT       DEFAULT (0) NOT NULL,
    [PeriodID]      INT           NULL,
    [PostedTS]      DATETIME2 (7) NULL,
    [SeqNo]         INT           NULL,
    [TransactionID] BIGINT        NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[JournalEntry])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_JournalEntry] ON;
        INSERT INTO [dbo].[tmp_ms_xx_JournalEntry] ([ID], [Discriminator], [AccountID], [Amount], [BalanceType], [PostedTS], [SeqNo], [TransactionID], [PeriodID])
        SELECT   [ID],
                 [Discriminator],
                 [AccountID],
                 [Amount],
                 [BalanceType],
                 [PostedTS],
                 [SeqNo],
                 [TransactionID],
                 [PeriodID]
        FROM     [dbo].[JournalEntry]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_JournalEntry] OFF;
    END

DROP TABLE [dbo].[JournalEntry];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_JournalEntry]', N'JournalEntry';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[JournalEntry].[JournalEntry_IX_Account]...';


GO
CREATE NONCLUSTERED INDEX [JournalEntry_IX_Account]
    ON [dbo].[JournalEntry]([AccountID] ASC);


GO
PRINT N'Creating [dbo].[JournalEntry].[JournalEntry_IX_Transaction]...';


GO
CREATE NONCLUSTERED INDEX [JournalEntry_IX_Transaction]
    ON [dbo].[JournalEntry]([TransactionID] ASC);


GO
PRINT N'Creating [dbo].[JournalEntry].[JournalEntry_IX_AccountingPeriod]...';


GO
CREATE NONCLUSTERED INDEX [JournalEntry_IX_AccountingPeriod]
    ON [dbo].[JournalEntry]([PeriodID] ASC);


GO
PRINT N'Starting rebuilding table [dbo].[Ledger]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Ledger] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [DescriptionMLSID] BIGINT         NULL,
    [EffectiveFrom]    DATETIME2 (7)  NULL,
    [EffectiveTo]      DATETIME2 (7)  NULL,
    [OrganizationID]   INT            NULL,
    [Reference]        NVARCHAR (200) NULL,
    [Remark]           NVARCHAR (500) NULL,
    [ShortTitleMLSID]  BIGINT         NULL,
    [TitleMLSID]       BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Ledger])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Ledger] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Ledger] ([ID], [EffectiveFrom], [EffectiveTo], [OrganizationID], [Reference], [Remark], [ShortTitleMLSID], [TitleMLSID])
        SELECT   [ID],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [OrganizationID],
                 [Reference],
                 [Remark],
                 [ShortTitleMLSID],
                 [TitleMLSID]
        FROM     [dbo].[Ledger]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Ledger] OFF;
    END

DROP TABLE [dbo].[Ledger];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Ledger]', N'Ledger';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[Ledger].[Ledger_IX]...';


GO
CREATE NONCLUSTERED INDEX [Ledger_IX]
    ON [dbo].[Ledger]([OrganizationID] ASC);


GO
PRINT N'Altering [dbo].[Organization]...';


GO
ALTER TABLE [dbo].[Organization] DROP COLUMN [ChartOfAccountID], COLUMN [FiscalYearEndDate];


GO
PRINT N'Starting rebuilding table [dbo].[PerformanceMeasurement]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_PerformanceMeasurement] (
    [ID]                     BIGINT        IDENTITY (1, 1) NOT NULL,
    [DescriptionMLSID]       BIGINT        NULL,
    [ClassLevelOutcomeID]    BIGINT        NULL,
    [ClassLevelID]           BIGINT        NULL,
    [EffectiveFrom]          DATETIME2 (7) NULL,
    [EffectiveTo]            DATETIME2 (7) NULL,
    [ClassSectionID]         INT           NULL,
    [SemesterID]             INT           NULL,
    [StudentID]              INT           NULL,
    [PerformanceIndicatorID] INT           NULL,
    [SequenceNo]             INT           NULL,
    [Point]                  REAL          NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[PerformanceMeasurement])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_PerformanceMeasurement] ON;
        INSERT INTO [dbo].[tmp_ms_xx_PerformanceMeasurement] ([ID], [DescriptionMLSID], [ClassLevelOutcomeID], [ClassLevelID], [EffectiveFrom], [EffectiveTo], [SemesterID], [StudentID], [PerformanceIndicatorID], [SequenceNo], [Point])
        SELECT   [ID],
                 [DescriptionMLSID],
                 [ClassLevelOutcomeID],
                 [ClassLevelID],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [SemesterID],
                 [StudentID],
                 [PerformanceIndicatorID],
                 [SequenceNo],
                 [Point]
        FROM     [dbo].[PerformanceMeasurement]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_PerformanceMeasurement] OFF;
    END

DROP TABLE [dbo].[PerformanceMeasurement];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_PerformanceMeasurement]', N'PerformanceMeasurement';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Person]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Person] (
    [ID]                 INT            NOT NULL,
    [CurrentNameID]      INT            NULL,
    [BloodGroupNodeID]   INT            NULL,
    [CitizenOfCountryID] INT            NULL,
    [GenderID]           INT            NULL,
    [EmailAddress]       NVARCHAR (50)  NULL,
    [HomePhoneNo]        NVARCHAR (50)  NULL,
    [MobilePhoneNo]      NVARCHAR (50)  NULL,
    [OccupationID]       INT            NULL,
    [OfficialIDNo]       NVARCHAR (20)  NULL,
    [RaceID]             INT            NULL,
    [ReligionID]         INT            NULL,
    [BirthDate]          DATETIME2 (7)  NULL,
    [BirthCertificate]   NVARCHAR (30)  NULL,
    [DeceasedDate]       DATETIME2 (7)  NULL,
    [DeathCertificate]   NVARCHAR (30)  NULL,
    [Reference]          NVARCHAR (50)  NULL,
    [Remark]             NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Person])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Person] ([ID], [CurrentNameID], [BloodGroupNodeID], [CitizenOfCountryID], [GenderID], [EmailAddress], [HomePhoneNo], [MobilePhoneNo], [OccupationID], [OfficialIDNo], [RaceID], [ReligionID], [BirthDate], [BirthCertificate], [DeceasedDate], [DeathCertificate], [Reference], [Remark])
        SELECT   [ID],
                 [CurrentNameID],
                 [BloodGroupNodeID],
                 [CitizenOfCountryID],
                 [GenderID],
                 [EmailAddress],
                 [HomePhoneNo],
                 [MobilePhoneNo],
                 [OccupationID],
                 [OfficialIDNo],
                 [RaceID],
                 [ReligionID],
                 [BirthDate],
                 [BirthCertificate],
                 [DeceasedDate],
                 [DeathCertificate],
                 [Reference],
                 [Remark]
        FROM     [dbo].[Person]
        ORDER BY [ID] ASC;
    END

DROP TABLE [dbo].[Person];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Person]', N'Person';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[PersonName]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_PersonName] (
    [ID]              INT            NOT NULL,
    [PersonID]        INT            NULL,
    [PrefixMLSID]     INT            NULL,
    [FirstNameMLSID]  BIGINT         NULL,
    [MiddleNameMLSID] BIGINT         NULL,
    [LastNameMLSID]   BIGINT         NULL,
    [EffectiveFrom]   DATETIME2 (7)  NULL,
    [EffectiveTo]     DATETIME2 (7)  NULL,
    [Reference]       NVARCHAR (50)  NULL,
    [Remark]          NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[PersonName])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_PersonName] ([ID], [PersonID], [PrefixMLSID], [FirstNameMLSID], [MiddleNameMLSID], [LastNameMLSID], [EffectiveFrom], [EffectiveTo], [Reference], [Remark])
        SELECT   [ID],
                 [PersonID],
                 [PrefixMLSID],
                 [FirstNameMLSID],
                 [MiddleNameMLSID],
                 [LastNameMLSID],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [Reference],
                 [Remark]
        FROM     [dbo].[PersonName]
        ORDER BY [ID] ASC;
    END

DROP TABLE [dbo].[PersonName];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_PersonName]', N'PersonName';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[ReceivableItem]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ReceivableItem] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [EffectiveFrom] DATETIME2 (7) NULL,
    [EffectiveTo]   DATETIME2 (7) NULL,
    [Reference]     NVARCHAR (50) NULL,
    [Remark]        NVARCHAR (50) NULL,
    [SeqNo]         INT           NULL,
    [SchoolID]      INT           NULL,
    [TitleMLSID]    BIGINT        NULL,
    [DefaultAmount] MONEY         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ReceivableItem])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ReceivableItem] ON;
        INSERT INTO [dbo].[tmp_ms_xx_ReceivableItem] ([ID], [DefaultAmount], [EffectiveFrom], [EffectiveTo], [Reference], [Remark], [SeqNo], [SchoolID], [TitleMLSID])
        SELECT   [ID],
                 [DefaultAmount],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [Reference],
                 [Remark],
                 [SeqNo],
                 [SchoolID],
                 [TitleMLSID]
        FROM     [dbo].[ReceivableItem]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ReceivableItem] OFF;
    END

DROP TABLE [dbo].[ReceivableItem];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ReceivableItem]', N'ReceivableItem';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[SchoolAdministrator]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_SchoolAdministrator] (
    [ID]            INT            NOT NULL,
    [CategoryID]    INT            NULL,
    [PersonID]      INT            NULL,
    [SchoolID]      INT            NULL,
    [EffectiveFrom] DATETIME2 (7)  NULL,
    [EffectiveTo]   DATETIME2 (7)  NULL,
    [Reference]     NVARCHAR (50)  NULL,
    [Remark]        NVARCHAR (500) NULL,
    [StatusID]      INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[SchoolAdministrator])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_SchoolAdministrator] ([ID], [CategoryID], [PersonID], [SchoolID], [EffectiveFrom], [EffectiveTo], [Reference], [Remark], [StatusID])
        SELECT   [ID],
                 [CategoryID],
                 [PersonID],
                 [SchoolID],
                 [EffectiveFrom],
                 [EffectiveTo],
                 [Reference],
                 [Remark],
                 [StatusID]
        FROM     [dbo].[SchoolAdministrator]
        ORDER BY [ID] ASC;
    END

DROP TABLE [dbo].[SchoolAdministrator];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_SchoolAdministrator]', N'SchoolAdministrator';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[ClassSection]...';


GO
CREATE TABLE [dbo].[ClassSection] (
    [ID]                  INT            IDENTITY (1, 1) NOT NULL,
    [ClassLevelSectionID] BIGINT         NULL,
    [CourseID]            BIGINT         NULL,
    [RoomID]              BIGINT         NULL,
    [SchoolID]            INT            NULL,
    [SemesterID]          BIGINT         NULL,
    [EffectiveFrom]       DATETIME2 (7)  NULL,
    [EffectiveTo]         DATETIME2 (7)  NULL,
    [Remark]              NVARCHAR (400) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[ClassSectionStudent]...';


GO
CREATE TABLE [dbo].[ClassSectionStudent] (
    [ID]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [ClassSectionID] BIGINT         NULL,
    [StudentID]      BIGINT         NULL,
    [GradeID]        INT            NULL,
    [GradePoint]     REAL           NULL,
    [AttendedHours]  REAL           NULL,
    [EffectiveFrom]  DATETIME2 (7)  NULL,
    [EffectiveTo]    DATETIME2 (7)  NULL,
    [Reference]      NVARCHAR (200) NULL,
    [Remark]         NVARCHAR (400) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[ClassSectionTeacher]...';


GO
CREATE TABLE [dbo].[ClassSectionTeacher] (
    [ID]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [ClassSectionID] BIGINT         NULL,
    [TeacherID]      BIGINT         NULL,
    [EffectiveFrom]  DATETIME2 (7)  NULL,
    [EffectiveTo]    DATETIME2 (7)  NULL,
    [Reference]      NVARCHAR (200) NULL,
    [Remark]         NVARCHAR (400) NULL,
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
