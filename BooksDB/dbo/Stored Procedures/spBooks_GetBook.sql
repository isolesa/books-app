CREATE PROCEDURE [dbo].[spBooks_GetBook]
	@id int
AS
BEGIN
	SELECT b.*, CONCAT(a.FirstName, ' ',a.LastName) AS Author
	FROM Books b INNER JOIN Authors a ON b.IdAuthor = a.Id
	WHERE b.Id = @id;
END
