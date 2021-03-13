CREATE TABLE [dbo].[EncounterItem]
(
	[IdItem] INT NOT NULL, 
    [IdEncounter] INT NOT NULL,
	
	CONSTRAINT PK_EncounterItem PRIMARY KEY CLUSTERED (IdItem asc, IdEncounter asc),
	CONSTRAINT FK_Encounter_Item FOREIGN KEY ([IdItem]) REFERENCES [Item] ON DELETE CASCADE,
	CONSTRAINT FK_Item_Encounter FOREIGN KEY ([IdEncounter]) REFERENCES [Encounter] ON DELETE CASCADE,
)
