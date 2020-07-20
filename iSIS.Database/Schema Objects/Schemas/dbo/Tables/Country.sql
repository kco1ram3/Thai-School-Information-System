CREATE TABLE [dbo].Country
(
	Alpha3Code nchar(3) NOT NULL PRIMARY KEY,
	Code nchar(3),
	Alpha2Code nchar(2),
	TitleMLSID bigint,
)
