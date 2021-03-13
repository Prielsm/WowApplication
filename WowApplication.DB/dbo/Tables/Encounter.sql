CREATE TABLE [dbo].[Encounter]
(
	[Id] INT NOT NULL PRIMARY KEY UNIQUE, 
    [Name] NVARCHAR(255) NOT NULL, 
    [IdInstance] INT NOT NULL, 
	[Media] NVARCHAR(MAX) NULL,
    
    CONSTRAINT FK_Encounter_Instance FOREIGN KEY ([IdInstance]) REFERENCES [Instance],

)
