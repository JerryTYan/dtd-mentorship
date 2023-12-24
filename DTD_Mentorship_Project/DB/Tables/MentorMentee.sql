CREATE TABLE [dbo].[MentorMentee]
(
	[MentorMenteeId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[MentorId] INT NOT NULL,
	[MenteeId] INT NOT NULL,
	CONSTRAINT [FK_MentorMentee_Mentor] FOREIGN KEY ([MentorId]) REFERENCES [User]([UserId]),
	CONSTRAINT [FK_MentorMentee_Mentee] FOREIGN KEY ([MenteeId]) REFERENCES [User]([UserId]),
)
