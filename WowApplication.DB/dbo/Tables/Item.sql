CREATE TABLE [dbo].[Item]
(
	[Id] INT NOT NULL PRIMARY KEY UNIQUE, 
    [Name] NVARCHAR(255) NOT NULL, 
    [Type] NVARCHAR(50) NULL, 
    [SubType] NVARCHAR(50) NULL, 
    [CreatureName] NVARCHAR(255) NULL, 
    [Icon] NVARCHAR(MAX) NULL, 
    [Media] NVARCHAR(MAX) NULL, 
    [IsObtained] BIT NOT NULL DEFAULT 0, 


)
