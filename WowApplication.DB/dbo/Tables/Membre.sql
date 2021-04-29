CREATE TABLE [dbo].[Membre]
(
	[idMembre]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [FirstName]    NVARCHAR (50)  NOT NULL,
    [Email]     NVARCHAR (256) NOT NULL,
    [Password]  NVARCHAR (256) NOT NULL,
    [Salt] NVARCHAR(250) NULL, 
    CONSTRAINT [PK_membre] PRIMARY KEY CLUSTERED ([idMembre] ASC)
)
