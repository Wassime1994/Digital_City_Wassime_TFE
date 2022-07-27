CREATE TABLE [dbo].[Patient]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [LastName] VARCHAR(50) NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [Problem] VARCHAR(50) NOT NULL, 
    [Level] INT NOT NULL, 
    [Statut] VARCHAR(50) NOT NULL , 
    [Date_Entry] DATETIME NOT NULL, 

)
