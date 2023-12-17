CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FirstName] NVARCHAR(200),
	[LastName] NVARCHAR(200),
	[Email] NVARCHAR(200) NOT NULL,
	[Password] NVARCHAR(200) NOT NULL,
	[OngoingMentorship] BIT NOT NULL,
	[Image] NVARCHAR(200), 
    [IdentityId] INT NOT NULL, 
    [Degree] NVARCHAR(200) NULL, 
    [Availability] DATETIME NULL,

	[DOB] DATETIME NULL,
	[SelectedUserTypeId] NVARCHAR(200) NOT NULL,
	[City] NVARCHAR(200) NULL,
	[State] NVARCHAR(200) NULL,
	[Company] NVARCHAR(200) NULL,

)
