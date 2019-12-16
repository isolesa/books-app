CREATE TABLE [dbo].[Books]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[Language] NVARCHAR(50) NOT NULL,
	[PublishedAt] DATE NOT NULL,
	[CreatedAt] DATETIME NOT NULL,
	[IdPublisher] INT NOT NULL, 
	[IdAuthor] INT NOT NULL, 
    CONSTRAINT [FK_Books_Publishers] FOREIGN KEY ([IdPublisher]) REFERENCES [Publishers]([Id]) ON DELETE CASCADE, 
    CONSTRAINT [FK_Books_Authors] FOREIGN KEY ([IdAuthor]) REFERENCES [Authors]([Id])
)
