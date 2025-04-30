
print '' print '*** inserting pre-made races ***'
GO
INSERT INTO [dbo].[Race]
		([RaceID],[Category])
	VALUES
	('Human','Humanoid'),
	('Vampire','Fictional'),('Werewolf','Fictional'),
	('Dog','Animal'),('Cat','Animal'),
	('Ghost','Entity')
GO