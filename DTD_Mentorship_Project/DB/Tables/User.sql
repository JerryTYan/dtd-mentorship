CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FirstName] NVARCHAR(200),
	[LastName] NVARCHAR(200),
	[Email] NVARCHAR(200) NULL,
	[Password] NVARCHAR(200) NULL,
	[OngoingMentorship] BIT NULL,
	[Image] NVARCHAR(200), 
    [IdentityId] INT NULL, 
    [Degree] NVARCHAR(200) NULL, 
	[AddressId] INT NULL,
	[DateOfBirth] DATETIME NULL,
	[Company] NVARCHAR(200) NULL,
	[FieldOfWorkID] NVARCHAR(200) NULL, 
	[School] NVARCHAR(200) NULL,
	[CurrentPosition] NVARCHAR(200),

    CONSTRAINT [FK_User_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id]),

)
