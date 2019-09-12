
CREATE PROCEDURE proc_SearchRocks
	@Id INT
AS
BEGIN
	
	SET NOCOUNT ON;
    
	SELECT [Name],
	       [Description]
     FROM Rock r
    WHERE r.Id = @Id
END