CREATE TABLE [dbo].[Instance]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(255) NOT NULL, 
    [Type] NVARCHAR(50) NOT NULL, 
    [Location] NVARCHAR(255) NOT NULL, 
    [Zone] NVARCHAR(50) NULL, 
    [Picture ] NVARCHAR(255) NULL, 
    [PictureOpacity] NVARCHAR(255) NULL, 
    [Video] NVARCHAR(255) NULL
)
