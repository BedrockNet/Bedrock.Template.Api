/****** Uncomment to check data ******/
/*
SELECT *
  FROM [dbo].[RockType]
*/  

/****** Drop constraints ******/

/****** Clear table ******/
DELETE FROM [dbo].[RockType]
GO

/****** Add data ******/ 
INSERT INTO [dbo].[RockType]
    ([Id], [Name], [Description], [SortOrder])
VALUES
    (1, 'Igneous', 'Igneous', 1),
    (2, 'Metamorphic', 'Metamorphic', 2),
	(3, 'Sedimentary', 'Sedimentary', 3)

GO

/****** Add constraints ******/

--GO