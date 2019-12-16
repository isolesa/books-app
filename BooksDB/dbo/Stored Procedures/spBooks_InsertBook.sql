CREATE PROCEDURE [dbo].[spBooks_InsertBook]
	@Title NVARCHAR(50),
	@Language NVARCHAR(50),
	@PublishedAt DATE,
	@CreatedAt DATETIME,
	@IdPublisher INT,
	@IdAuthor INT
AS
BEGIN
	INSERT INTO Books 
	VALUES(@Title, @Language, @PublishedAt, @CreatedAt, @IdPublisher, @IdAuthor) 
    SELECT SCOPE_IDENTITY();
END
