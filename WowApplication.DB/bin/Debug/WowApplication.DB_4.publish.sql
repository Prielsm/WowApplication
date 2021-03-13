/*
Script de déploiement pour WowApplication

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "WowApplication"
:setvar DefaultFilePrefix "WowApplication"
:setvar DefaultDataPath "C:\Users\User\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\User\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Création de [dbo].[Item]...';


GO
CREATE TABLE [dbo].[Item] (
    [Id]           INT            NOT NULL,
    [Name]         NVARCHAR (255) NOT NULL,
    [IdEncounter]  INT            NOT NULL,
    [Type]         NVARCHAR (50)  NOT NULL,
    [SubType]      NVARCHAR (50)  NULL,
    [CreatureName] NVARCHAR (255) NULL,
    [Icon]         NVARCHAR (MAX) NULL,
    [Media]        NVARCHAR (MAX) NULL,
    [IsObtained]   BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de contrainte sans nom sur [dbo].[Encounter]...';


GO
ALTER TABLE [dbo].[Encounter]
    ADD UNIQUE NONCLUSTERED ([Id] ASC);


GO
PRINT N'Création de contrainte sans nom sur [dbo].[Instance]...';


GO
ALTER TABLE [dbo].[Instance]
    ADD UNIQUE NONCLUSTERED ([Id] ASC);


GO
PRINT N'Création de contrainte sans nom sur [dbo].[Item]...';


GO
ALTER TABLE [dbo].[Item]
    ADD DEFAULT 0 FOR [IsObtained];


GO
PRINT N'Création de [dbo].[FK_Item_Encounter]...';


GO
ALTER TABLE [dbo].[Item] WITH NOCHECK
    ADD CONSTRAINT [FK_Item_Encounter] FOREIGN KEY ([IdEncounter]) REFERENCES [dbo].[Encounter] ([Id]);


GO
PRINT N'Création de [dbo].[FK_Encounter_Instance]...';


GO
ALTER TABLE [dbo].[Encounter] WITH NOCHECK
    ADD CONSTRAINT [FK_Encounter_Instance] FOREIGN KEY ([IdInstance]) REFERENCES [dbo].[Instance] ([Id]);


GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Item] WITH CHECK CHECK CONSTRAINT [FK_Item_Encounter];

ALTER TABLE [dbo].[Encounter] WITH CHECK CHECK CONSTRAINT [FK_Encounter_Instance];


GO
PRINT N'Mise à jour terminée.';


GO
