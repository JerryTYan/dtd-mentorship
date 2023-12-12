CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [UserId] INT NULL,



	CONSTRAINT [FK_Address_UserId] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])

)
