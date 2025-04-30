/* ======================================================
	print '' print '*** creating character image table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[CharacterImage] (
	[CharacterID]		[int]					NOT NULL,
	[ImageFile]			[nvarchar](50)			NOT NULL,
	[ImageTitle]		[nvarchar](25)			NULL,
	[ImageDescription]	[nvarchar](100)			NULL,
	[NSFW]				[bit]					NOT NULL	DEFAULT 0,
	
	CONSTRAINT [fk_characterimage_characterid] FOREIGN KEY ([CharacterID])
		REFERENCES [UserCharacter]([CharacterID])
)
GO

 ======================================================
	print '' print '*** creating character fact table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[CharacterFact] (
	[CharacterID]		[int]					NOT NULL,
	[FactTitle]			[nvarchar](25)			NOT NULL,
	[FactDescription]	[nvarchar](100)			NOT NULL,
	
	CONSTRAINT [fk_characterfact_characterid] FOREIGN KEY ([CharacterID])
		REFERENCES [UserCharacter]([CharacterID])
)
GO

 ======================================================
	print '' print '*** creating character nickname table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[CharacterNickname] (
	[CharacterID]			[int]				NOT NULL,
	[CharacterNickname]		[nvarchar](25)		NOT NULL,
	[NicknameDescription]	[nvarchar](100)		NOT NULL,
	
	CONSTRAINT [fk_characternickname_characterid] FOREIGN KEY ([CharacterID])
		REFERENCES [UserCharacter]([CharacterID]),
	CONSTRAINT [ak_characternickname] UNIQUE([CharacterNickname] ASC)
)
GO

 ======================================================
	print '' print '*** creating language type table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[LanguageType] (
	[LanguageID]			[nvarchar](25)			NOT NULL,
	[LanguageDescription]	[nvarchar](100)			NULL,
	[CreatorID]				[nvarchar](20)			NULL,
	[Custom]				[bit]					NOT NULL	DEFAULT 0,
	
	CONSTRAINT [pk_languageid] PRIMARY KEY ([LanguageID] ASC),
	CONSTRAINT [fk_languagetype_creatorid] FOREIGN KEY ([CreatorID])
		REFERENCES [UserAccount]([UserID])
)
GO

 ======================================================
	print '' print '*** creating character language table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[CharacterLanguage] (
	[CharacterID]					[int]				NOT NULL,
	[LanguageID]					[nvarchar](25)		NOT NULL,
	[CharacterLanguageDescription]	[nvarchar](100)		NULL,
	
	CONSTRAINT [fk_characterlanguage_characterid] FOREIGN KEY ([CharacterID])
		REFERENCES [UserCharacter]([CharacterID]),
	CONSTRAINT [fk_characterlanguage_languageid] FOREIGN KEY ([LanguageID])
		REFERENCES [LanguageType]([LanguageID])
)
GO


 ======================================================
	print '' print '*** creating relationship type table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[RelationshipType] (
	[RelationshipID]			[nvarchar](25)		NOT NULL,
	[RelationshipDescription]	[nvarchar](50)		NULL,
	[CreatorID]					[nvarchar](20)		NULL,
	[Custom]					[bit]				NOT NULL	DEFAULT 0,
	
	CONSTRAINT [pk_relationshipid] PRIMARY KEY ([RelationshipID] ASC),
	CONSTRAINT [fk_relationshiptype_creatorid] FOREIGN KEY ([CreatorID])
		REFERENCES [UserAccount]([UserID])
)
GO

 ======================================================
	print '' print '*** creating character relationship table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[CharacterRelationship] (
	[CharacterID]						[int]				NOT NULL,
	[RelationshipID]					[nvarchar](25)		NOT NULL,
	[PersonName]						[nvarchar](50)		NOT NULL,
	[CharacterRelationshipDescription]	[nvarchar](100)		NOT NULL,
	
	CONSTRAINT [fk_characterrelationship_characterid] FOREIGN KEY ([CharacterID])
		REFERENCES [UserCharacter]([CharacterID]),
	CONSTRAINT [fk_characterrelationship_relationshipid] FOREIGN KEY ([RelationshipID])
		REFERENCES [RelationshipType]([RelationshipID])
)
GO

 ======================================================
	print '' print '*** creating country table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[Country] (
	[CountryID]				[nvarchar](50)			NOT NULL,
	[CountryNationality]	[nvarchar](50)			NOT NULL,
	[CountryDescription]	[nvarchar](100)			NOT NULL	DEFAULT 'A real country.',
	[CreatorID]				[nvarchar](20)			NULL,
	[Custom]				[bit]					NOT NULL	DEFAULT 0,
	
	CONSTRAINT [pk_countryid] PRIMARY KEY ([CountryID] ASC),
	CONSTRAINT [fk_country_creatorid] FOREIGN KEY ([CreatorID])
		REFERENCES [UserAccount]([UserID])
)
GO

 ======================================================
	print '' print '*** creating subdivision table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[Subdivision] (
	[SubdivisionID]				[int] IDENTITY(1000000, 1)	NOT NULL,
	[SubdivisionName]			[nvarchar](50)				NOT NULL,
	[SubdivisionCountry]		[nvarchar](50)				NOT NULL,
	[SubdivisionType]			[nvarchar](50)				NOT NULL,
	[SubdivisionDescription]	[nvarchar](100)				NOT NULL	DEFAULT 'A real subdivision.',
	[CreatorID]					[nvarchar](20)				NULL,
	[Custom]					[bit]						NOT NULL	DEFAULT 0,
	
	CONSTRAINT [pk_subdivisionid] PRIMARY KEY ([SubdivisionID] ASC),
	CONSTRAINT [fk_subdivision_country_id] FOREIGN KEY([SubdivisionCountry])
		REFERENCES [Country]([CountryID]),
	CONSTRAINT [fk_subdivision_creatorid] FOREIGN KEY ([CreatorID])
		REFERENCES [UserAccount]([UserID])
)
GO

 ======================================================
	print '' print '*** creating city table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[City] (
	[CityID]				[int] IDENTITY(1000000, 1)	NOT NULL,
	[CityName]				[nvarchar](50)				NOT NULL,
	[CityCountry]			[nvarchar](50)				NOT NULL,
	[CitySubdivision]		[int]						NULL,
	[CityDescription]		[nvarchar](100)				NOT NULL	DEFAULT 'A real city.',
	[CreatorID]				[nvarchar](20)				NULL,
	[Custom]				[bit]						NOT NULL	DEFAULT 0,
	
	CONSTRAINT [pk_cityid] PRIMARY KEY ([CityID] ASC),
	CONSTRAINT [fk_city_countryid] FOREIGN KEY([CityCountry])
		REFERENCES [Country]([CountryID]),
	CONSTRAINT [fk_city_subdivisionid] FOREIGN KEY([CitySubdivision])
		REFERENCES [Subdivision]([SubdivisionID]),
	CONSTRAINT [fk_city_creatorid] FOREIGN KEY ([CreatorID])
		REFERENCES [UserAccount]([UserID])
)
GO

 ======================================================
	print '' print '*** creating location table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[Location] (
	[LocationID]			[int] IDENTITY(1000000, 1)	NOT NULL,
	[LocationName]			[nvarchar](50)				NOT NULL,
	[LocationCountry]		[nvarchar](50)				NOT NULL,
	[LocationSubdivision]	[int]						NULL,
	[LocationCity]			[int]						NOT NULL,
	[LocationAddress]		[nvarchar](50)				NULL,
	[LocationDescription]	[nvarchar](100)				NULL,
	[CreatorID]				[nvarchar](20)				NULL,
	
	CONSTRAINT [pk_locationid] PRIMARY KEY ([LocationID] ASC),
	CONSTRAINT [fk_location_country] FOREIGN KEY ([LocationCountry])
		REFERENCES [Country]([CountryID]),
	CONSTRAINT [fk_location_subdivision] FOREIGN KEY ([LocationSubdivision])
		REFERENCES [Subdivision]([SubdivisionID]),
	CONSTRAINT [fk_location_city] FOREIGN KEY ([LocationCity])
		REFERENCES [City]([CityID]),
	CONSTRAINT [fk_location_creatorid] FOREIGN KEY ([CreatorID])
		REFERENCES [UserAccount]([UserID])
)
GO

 ======================================================
	print '' print '*** creating character nationality table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[CharacterNationality] (
	[CharacterID]			[int]				NOT NULL,
	[CountryID]				[nvarchar](50)		NOT NULL,
	
	CONSTRAINT [fk_characternationality_characterid] FOREIGN KEY ([CharacterID])
		REFERENCES [UserCharacter]([CharacterID]),
	CONSTRAINT [fk_characternationality_countryid] FOREIGN KEY ([CountryID])
		REFERENCES [Country]([CountryID])
)
GO


 ======================================================
	print '' print '*** creating event type table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[EventType] (
	[EventID]				[nvarchar](25)		NOT NULL,
	[EventDescription]		[nvarchar](100)		NOT NULL,
	[CreatorID]				[nvarchar](20)		NULL,
	[Custom]				[bit]				NOT NULL	DEFAULT 0,
	
	CONSTRAINT [pk_eventid] PRIMARY KEY ([EventID] ASC),
	CONSTRAINT [fk_eventtype_creatorid] FOREIGN KEY ([CreatorID])
		REFERENCES [UserAccount]([UserID])
)
GO

 ======================================================
	print '' print '*** creating character event table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[CharacterEvent] (
	[CharacterEventID]		[int] IDENTITY(1000000, 1)	NOT NULL,
	[CharacterID]			[int]						NOT NULL,
	[EventID]				[nvarchar](25)				NOT NULL,
	[EventLocation]			[int]						NULL,
	[EventDate]				[date]						NULL,
	[EventDescription]		[nvarchar](100)				NULL,
	
	CONSTRAINT [pk_charactereventid] PRIMARY KEY ([CharacterEventID] ASC),
	CONSTRAINT [fk_characterevent_characterid] FOREIGN KEY ([CharacterID])
		REFERENCES [UserCharacter]([CharacterID]),
	CONSTRAINT [fk_characterevent_eventid] FOREIGN KEY ([EventID])
		REFERENCES [EventType]([EventID]),
	CONSTRAINT [fk_characterevent_locationid] FOREIGN KEY ([EventLocation])
		REFERENCES [Location]([LocationID])
)
GO


 ======================================================
	print '' print '*** creating job type table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[JobType] (
	[JobID]					[nvarchar](25)		NOT NULL,
	[JobDescription]		[nvarchar](50)		NULL,
	[CreatorID]				[nvarchar](20)		NULL,
	[Custom]				[bit]				NOT NULL	DEFAULT 0,
	
	CONSTRAINT [pk_jobid] PRIMARY KEY ([JobID] ASC),
	CONSTRAINT [fk_jobtype_creatorid] FOREIGN KEY ([CreatorID])
		REFERENCES [UserAccount]([UserID])
)
GO

 ======================================================
	print '' print '*** creating character job table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[CharacterJob] (
	[CharacterID]				[int]				NOT NULL,
	[CharacterJob]				[nvarchar](25)		NOT NULL,
	[JobLocation]				[int]				NULL,
	[CharacterJobDescription]	[nvarchar](100)		NULL,
	[WhenStartedJob]			[nvarchar](50)		NULL,
	[WhenEndedJob]				[nvarchar](50)		NULL,
	
	CONSTRAINT [fk_characterjob_characterid] FOREIGN KEY ([CharacterID])
		REFERENCES [UserCharacter]([CharacterID]),
	CONSTRAINT [fk_characterjob_jobid] FOREIGN KEY ([CharacterJob])
		REFERENCES [JobType]([JobID]),
	CONSTRAINT [fk_characterjob_joblocation] FOREIGN KEY ([JobLocation])
		REFERENCES [Location]([LocationID])
)
GO

 ======================================================
	print '' print '*** creating education type table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[EducationType] (
	[EducationID]				[nvarchar](25)		NOT NULL,
	[EducationDescription]		[nvarchar](50)		NULL,
	[CreatorID]					[nvarchar](20)		NULL,
	[Custom]					[bit]				NOT NULL	DEFAULT 0,
	
	CONSTRAINT [pk_educationid] PRIMARY KEY ([EducationID] ASC),
	CONSTRAINT [fk_educationtype_creatorid] FOREIGN KEY ([CreatorID])
		REFERENCES [UserAccount]([UserID])
)
GO

 ======================================================
	print '' print '*** creating character education table ***'
	GO
  =====================================================
CREATE TABLE [dbo].[CharacterEducation] (
	[CharacterID]					[int]				NOT NULL,
	[EducationID]					[nvarchar](25)		NOT NULL,
	[EducationLocation]				[int]				NULL,
	[CharacterEducationDescription]	[nvarchar](100)		NULL,
	
	CONSTRAINT [fk_charactereducation_characterid] FOREIGN KEY ([CharacterID])
		REFERENCES [UserCharacter]([CharacterID]),
	CONSTRAINT [fk_charactereducation_educationid] FOREIGN KEY ([EducationID])
		REFERENCES [EducationType]([EducationID]),
	CONSTRAINT [fk_charactereducation_educationlocation] FOREIGN KEY ([EducationLocation])
		REFERENCES [Location]([LocationID])
)
GO
*/

