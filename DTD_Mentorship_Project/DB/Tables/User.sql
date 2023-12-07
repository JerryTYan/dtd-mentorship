CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FirstName] NVARCHAR(200),
	[LastName] NVARCHAR(200),
	[Email] NVARCHAR(200),
	[Password] NVARCHAR(200),
	[OngoingMentorship] BIT NOT NULL,
	[Image] NVARCHAR(200), 
    [Identity] NVARCHAR(200) NOT NULL, 
    [Degree] NVARCHAR(200) NULL, 
    [Availability] DATETIME NULL
)
