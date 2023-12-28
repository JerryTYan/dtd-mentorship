CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [StreetAddress] NVARCHAR(200),
    [City] NVARCHAR(200),
    [State] NVARCHAR(200),
    [ZipCode] NVARCHAR(200),

)
