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
/*
La colonne [dbo].[Instance].[Media] de la table [dbo].[Instance] doit être ajoutée mais la colonne ne comporte pas de valeur par défaut et n'autorise pas les valeurs NULL. Si la table contient des données, le script ALTER ne fonctionnera pas. Pour éviter ce problème, vous devez ajouter une valeur par défaut à la colonne, la marquer comme autorisant les valeurs Null ou activer la génération de smart-defaults en tant qu'option de déploiement.
*/

IF EXISTS (select top 1 1 from [dbo].[Instance])
    RAISERROR (N'Lignes détectées. Arrêt de la mise à jour du schéma en raison d''''un risque de perte de données.', 16, 127) WITH NOWAIT

GO
PRINT N'Début de la régénération de la table [dbo].[Instance]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Instance] (
    [Id]             INT            NOT NULL,
    [Name]           NVARCHAR (255) NOT NULL,
    [Type]           NVARCHAR (50)  NOT NULL,
    [Location]       NVARCHAR (255) NOT NULL,
    [Media]          NVARCHAR (255) NOT NULL,
    [Zone]           NVARCHAR (50)  NULL,
    [Picture ]       NVARCHAR (255) NULL,
    [PictureOpacity] NVARCHAR (255) NULL,
    [Video]          NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Instance])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Instance] ([Id], [Name], [Type], [Location], [Zone], [Picture ], [PictureOpacity], [Video])
        SELECT   [Id],
                 [Name],
                 [Type],
                 [Location],
                 [Zone],
                 [Picture ],
                 [PictureOpacity],
                 [Video]
        FROM     [dbo].[Instance]
        ORDER BY [Id] ASC;
    END

DROP TABLE [dbo].[Instance];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Instance]', N'Instance';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Mise à jour terminée.';


GO
