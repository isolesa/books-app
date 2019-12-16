CREATE PROCEDURE [dbo].[spBooks_GetBooks]
AS
BEGIN
	SELECT b.*, CONCAT(a.FirstName, ' ',a.LastName) AS Author
	FROM Books b INNER JOIN Authors a ON b.IdAuthor = a.Id
END
