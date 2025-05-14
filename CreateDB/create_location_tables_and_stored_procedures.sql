USE [character_creator]
GO

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

CREATE PROCEDURE [dbo].[sp_create_location]
	(
		@LocationName						[nvarchar](50),
		@LocationCountry					[nvarchar](50),
		@LocationSubdivision				[int],
		@LocationCity						[int],
		@LocationAddress					[nvarchar](50),
		@LocationDescription				[nvarchar](100),
		@CreatorID							[nvarchar](20)
	)
AS
	BEGIN
		INSERT INTO		[Location]
			([LocationName],[LocationCountry],[LocationSubdivision],[LocationCity],[LocationAddress],[LocationDescription],[CreatorID])
		VALUES
			(@LocationName,@LocationCountry,@LocationSubdivision,@LocationCity,@LocationAddress,@LocationDescription,@CreatorID)
	END
GO

CREATE PROCEDURE [dbo].[sp_update_location]
	(
		@LocationID							[int],
		@OldLocationName					[nvarchar](50),
		@NewLocationName					[nvarchar](50),
		@OldLocationCountry					[nvarchar](50),
		@NewLocationCountry					[nvarchar](50),
		@OldLocationSubdivision				[int],
		@NewLocationSubdivision				[int],
		@OldLocationCity					[int],
		@NewLocationCity					[int],
		@OldLocationAddress					[nvarchar](50),
		@NewLocationAddress					[nvarchar](50),
		@OldLocationDescription				[nvarchar](100),
		@NewLocationDescription				[nvarchar](100)
	)
AS
	BEGIN
		UPDATE		[Location]
		SET			[LocationName] = @NewLocationName,
					[LocationCountry] = @NewLocationCountry,
					[LocationSubdivision] = @NewLocationSubdivision,
					[LocationCity] = @NewLocationCity,
					[LocationAddress] = @NewLocationAddress,
					[LocationDescription] = @NewLocationDescription
		WHERE		[LocationID] = @LocationID
			AND		[LocationName] = @OldLocationName OR ([LocationName] IS NULL AND @OldLocationName IS NULL)
			AND		[LocationCountry] = @OldLocationCountry OR ([LocationCountry] IS NULL AND @OldLocationCountry IS NULL)
			AND		[LocationSubdivision] = @OldLocationSubdivision OR ([LocationSubdivision] IS NULL AND @OldLocationSubdivision IS NULL)
			AND		[LocationCity] = @OldLocationCity OR ([LocationCity] IS NULL AND @OldLocationCity IS NULL)
			AND		[LocationAddress] = @OldLocationAddress OR ([LocationAddress] IS NULL AND @OldLocationAddress IS NULL)
			AND		[LocationDescription] = @OldLocationDescription OR ([LocationDescription] IS NULL AND @OldLocationDescription IS NULL)
	END
GO

CREATE PROCEDURE [dbo].[sp_delete_location]
	(
		@CreatorID				[nvarchar](20),
		@LocationID				[int]
	)
AS
	BEGIN
		DELETE FROM	[Location]
		WHERE		[CreatorID] = @CreatorID
			AND		[LocationID] = @LocationID
	END
GO

DROP PROCEDURE IF EXISTS [sp_view_all_locations]
GO
CREATE PROCEDURE [dbo].[sp_view_all_locations]
	(
		@CreatorID				[nvarchar](20)
	)
AS
	BEGIN
		SELECT	[LocationID],[LocationName],[LocationCountry],[LocationSubdivision],[SubdivisionName],[LocationCity],[CityName],[LocationAddress],[LocationDescription]
		FROM	[Location]
		LEFT JOIN	[Subdivision]
			ON	[Location].[LocationSubdivision] = [Subdivision].[SubdivisionID]
		JOIN	[City]
			ON	[Location].[LocationCity] = [City].[CityID]
		WHERE	[Location].[CreatorID] = @CreatorID
	END
GO

DROP PROCEDURE IF EXISTS [sp_view_location_by_locationid]
GO
CREATE PROCEDURE [dbo].[sp_view_location_by_locationid]
	(
		@LocationID				[int]
	)
AS
	BEGIN
		SELECT	[LocationName],[LocationCountry],[LocationSubdivision],[SubdivisionName],[LocationCity],[CityName],[LocationAddress],[LocationDescription],[Location].[CreatorID]
		FROM	[Location]
		LEFT JOIN	[Subdivision]
			ON	[Location].[LocationSubdivision] = [Subdivision].[SubdivisionID]
		LEFT JOIN	[City]
			ON	[Location].[LocationCity] = [City].[CityID]
		WHERE	[LocationID] = @LocationID
	END
GO

-- CREATE PROCEDURE [dbo].[sp_create_new_country]
-- CREATE PROCEDURE [dbo].[sp_update_country]
-- CREATE PROCEDURE [dbo].[sp_delete_country]
-- CREATE PROCEDURE [dbo].[sp_view_all_custom_countries]

CREATE PROCEDURE [dbo].[sp_view_all_countries]
AS
	BEGIN
		SELECT	[CountryID],[CountryDescription]
		FROM	[Country]
		WHERE	[Custom] = 0
	END
GO


-- CREATE PROCEDURE [dbo].[sp_create_new_subdivision]
-- CREATE PROCEDURE [dbo].[sp_update_subdivision]
-- CREATE PROCEDURE [dbo].[sp_delete_subdivision]
-- CREATE PROCEDURE [dbo].[sp_view_all_custom_subdivisions]

DROP PROCEDURE IF EXISTS [sp_view_all_custom_subdivisions]
GO
CREATE PROCEDURE [dbo].[sp_view_all_subdivisions]
AS
	BEGIN
		SELECT	[SubdivisionID],[SubdivisionName],[SubdivisionCountry],[SubdivisionType],[SubdivisionDescription]
		FROM	[Subdivision]
		WHERE	[Custom] = 0
	END
GO

-- CREATE PROCEDURE [dbo].[sp_create_new_city]
-- CREATE PROCEDURE [dbo].[sp_update_city]
-- CREATE PROCEDURE [dbo].[sp_delete_city]
-- CREATE PROCEDURE [dbo].[sp_view_all_custom_cities]

CREATE PROCEDURE [dbo].[sp_view_all_cities]
AS
	BEGIN
		SELECT	[CityID],[CityName],[CityCountry],[CitySubdivision],[SubdivisionName],[CityDescription]
		FROM	[City]
		LEFT JOIN	[Subdivision]
			ON	[City].[CitySubdivision] = [Subdivision].[SubdivisionID]
		WHERE	[City].[Custom] = 0
	END
GO
