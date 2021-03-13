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
PRINT N'L''opération de refactorisation de changement de nom avec la clé 13c99f5b-1cb4-49cc-b0f6-a54046165e91 est ignorée, l''élément [dbo].[EncounterItem].[Id] (SqlSimpleColumn) ne sera pas renommé en IdEncounter';


GO
PRINT N'Création de [dbo].[EncounterItem]...';


GO
CREATE TABLE [dbo].[EncounterItem] (
    [IdItem]      INT NOT NULL,
    [IdEncounter] INT NOT NULL
);


GO
-- Étape de refactorisation pour mettre à jour le serveur cible avec des journaux de transactions déployés

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '13c99f5b-1cb4-49cc-b0f6-a54046165e91')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('13c99f5b-1cb4-49cc-b0f6-a54046165e91')

GO

GO
PRINT N'Mise à jour terminée.';


GO
