﻿alter table Admission drop column 
	OrientationDate, 
	RegistrationDate;

alter table Admission add
	AdmittedClassLevelID int,

	ApplicationFormURL nvarchar(200),
	ApplicationInfoURL nvarchar(200),
	ApplicationReceiptTemplateID bigint,

	RegistrationFormURL nvarchar(200),
	RegistrationInfoURL nvarchar(200),
	RegistrationReceiptTemplateID bigint,

	RegisterFrom DateTime,
	RegisterTo DateTime
	;

alter table StudentApplication add
	AdmissionID int,
	AdmissionTestRoomID int
;

CREATE TABLE [dbo].[ReceiptTemplateItem]
(
	[ID] BIGINT Identity(1,1) NOT NULL PRIMARY KEY, 
    [SeqNo] INT NULL, 
    [ReceiptTemplateID] INT NULL, 
    [ReceivableItemID] INT NULL, 
    [DefaultAmount] REAL NULL, 
    [DefaultAmountPerUnit] REAL NULL, 
    [DefaultUnits] INT NULL

);

CREATE TABLE [dbo].ReceiptTemplate
(
	[ID] BIGINT Identity(1,1) NOT NULL PRIMARY KEY, 
    [SchoolID] INT NULL, 
    [ReceiptNote] NVARCHAR(100) NULL, 
    [TotalAmount] REAL NULL

);

drop table [dbo].[ReceivableItem];

CREATE TABLE [dbo].[ReceivableItem]
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY, 
	DefaultAmount money,
    [EffectiveFrom] DATETIME2 NULL, 
    [EffectiveTo] DATETIME2 NULL, 
    [Reference] NVARCHAR(50) NULL, 
    [Remark] NVARCHAR(50) NULL, 
    [SeqNo] INT NULL, 
    [SchoolID] INT NULL,
	TitleMLSID bigint,
)
