CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FirstName] NVARCHAR(200),
	[LastName] NVARCHAR(200),
	[Email] NVARCHAR(200),
	[Password] NVARCHAR(200),
	[Mentor] Bit,
	[Intern] Bit,
	[Mentorship] BIT,
)
