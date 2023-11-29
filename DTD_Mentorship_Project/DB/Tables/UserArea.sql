CREATE TABLE [dbo].[UserArea]
(
	[UserAreaId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[AreaId] INT NOT NULL,
	[UserId] INT NOT NULL,
	CONSTRAINT [FK_UserArea_Area] FOREIGN KEY ([AreaId]) REFERENCES [Area]([AreaId]),
	CONSTRAINT [FK_UserArea_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]),
)
