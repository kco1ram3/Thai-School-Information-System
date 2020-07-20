CREATE TABLE [dbo].[Teacher]
(
	[ID] INT NOT NULL PRIMARY KEY, 
	IDNo nvarchar(20),
    [CategoryID] INT NULL, 
    [PersonID] INT NULL, 
    [SchoolID] INT NULL,
    [EffectiveFrom] DATETIME2 NULL, 
    [EffectiveTo] DATETIME2 NULL, 
    [Reference] NVARCHAR(50) NULL, 
    [Remark] NVARCHAR(500) NULL, 

	StartAcademicYear int, 
    StartSemesterID INT NULL,
	StartSemesterNo int, 
    StatusID INT NULL, 
)
