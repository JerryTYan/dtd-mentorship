CREATE TABLE [dbo].[Table1]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [UserId] INT NULL,



	CONSTRAINT [FK_Address_UserId] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]), 

)
