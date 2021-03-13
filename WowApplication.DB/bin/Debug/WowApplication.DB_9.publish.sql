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
PRINT N'Création de [dbo].[EcounterItem]...';


GO
CREATE TABLE [dbo].[EcounterItem] (
    [IdItem]      INT NOT NULL,
    [IdEncounter] INT NOT NULL,
    CONSTRAINT [PK_EncounterItem] PRIMARY KEY CLUSTERED ([IdItem] ASC, [IdEncounter] ASC)
);


GO
PRINT N'Création de [dbo].[FK_Encounter_Item]...';


GO
ALTER TABLE [dbo].[EcounterItem] WITH NOCHECK
    ADD CONSTRAINT [FK_Encounter_Item] FOREIGN KEY ([IdItem]) REFERENCES [dbo].[Item] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Création de [dbo].[FK_Item_Encounter]...';


GO
ALTER TABLE [dbo].[EcounterItem] WITH NOCHECK
    ADD CONSTRAINT [FK_Item_Encounter] FOREIGN KEY ([IdEncounter]) REFERENCES [dbo].[Encounter] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[EcounterItem] WITH CHECK CHECK CONSTRAINT [FK_Encounter_Item];

ALTER TABLE [dbo].[EcounterItem] WITH CHECK CHECK CONSTRAINT [FK_Item_Encounter];


GO
PRINT N'Mise à jour terminée.';


GO
