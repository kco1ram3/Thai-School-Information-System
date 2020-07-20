CREATE TABLE [dbo].[Language]
(
	LanguageCode nchar(5) primary key,
    SeqNo int,
    ShortTitle nvarchar(20),
    SmallImageBytes varbinary(max),
    Title nvarchar(40),
)
