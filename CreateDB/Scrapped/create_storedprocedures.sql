USE [character_creator]
GO


CREATE PROCEDURE [dbo].[sp_deactivate_account]
	(
		@UserID			[nvarchar](20),
		@PasswordHash	[nvarchar](100)
	)
AS
	BEGIN
		UPDATE	[UserAccount]
		SET		[Active] = 0
		WHERE	[UserID] = @UserID
			AND	[PasswordHash] = @PasswordHash
		RETURN @@ROWCOUNT
	END
GO

CREATE PROCEDURE [dbo].[sp_update_account_profile_picture]
	(
		@UserID				[nvarchar](20),
		@OldProfilePicture	[nvarchar](250),
		@NewProfilePicture	[nvarchar](250)
	)
AS
	BEGIN
		UPDATE		[UserAccount]
		SET			[ProfilePicture] = @NewProfilePicture
		WHERE		[UserID] = @UserID
			AND		[ProfilePicture] = @OldProfilePicture
		RETURN @@ROWCOUNT
	END
GO













CREATE PROCEDURE [dbo].[sp_remove_access_for_character]
	(
		@UserID					[nvarchar](20),
		@CharacterID			[int],
		@PermissionID			[nvarchar](20)
	)
AS
	BEGIN
		DELETE FROM		[UserPermission]
		WHERE			[UserID] = @UserID
			AND			[CharacterID] = @CharacterID
			AND			[PermissionID] = @PermissionID
	END
GO



CREATE PROCEDURE [dbo].[sp_add_character_nickname]
	(
		@CharacterID				[int],
		@CharacterNickname			[nvarchar](25),
		@NicknameDescription		[nvarchar](50)
	)
AS
	BEGIN
		INSERT INTO [CharacterNickname]
		([CharacterID],[CharacterNickname],[NicknameDescription])
		VALUES
		(@CharacterID,@CharacterNickname,@NicknameDescription)
	END
GO

CREATE PROCEDURE [dbo].[sp_update_character_nickname]
	(
		@CharacterID				[int],
		@OldNickname				[nvarchar](25),
		@OldDescription				[nvarchar](50),
		@NewNickname				[nvarchar](25),
		@NewDescription				[nvarchar](50)
	)
AS
	BEGIN
		UPDATE		[CharacterNickname]
		SET			[CharacterNickname] = @NewNickname,
					[NicknameDescription] = @NewDescription
		WHERE		[CharacterID] = @CharacterID
			AND		[CharacterNickname] = @OldNickname
			AND		[NicknameDescription] = @OldDescription
		RETURN @@ROWCOUNT
	END
GO

CREATE PROCEDURE [dbo].[sp_remove_character_nickname]
	(
		@CharacterID				[int],
		@CharacterNickname			[nvarchar](25)
	)
AS
	BEGIN
		DELETE FROM		[CharacterNickname]
		WHERE			[CharacterID] = @CharacterID
			AND			[CharacterNickname] = @CharacterNickname
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_character_nicknames]
	(
		@CharacterID				[int]
	)
AS
	BEGIN
		SELECT		[CharacterNickname],[NicknameDescription]
		FROM		[CharacterNickname]
		WHERE		[CharacterID] = @CharacterID
	END
GO

/*
CREATE PROCEDURE [dbo].[sp_view_all_genders]
AS
	BEGIN
		SELECT		[GenderID],[GenderDescription]
		FROM		[Gender]
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_sexes]
AS
	BEGIN
		SELECT		[GenderID],[GenderDescription]
		FROM		[Gender]
		WHERE		[GenderBinary] = 1
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_sexualities]
AS
	BEGIN
		SELECT		[SexualityID],[SexualityDescription]
		FROM		[Sexuality]
	END
GO
*/




CREATE PROCEDURE [dbo].[sp_create_new_skill_type]
	(
		@SkillID			[nvarchar](25),
		@SkillCategory		[nvarchar](25),
		@SkillDescription	[nvarchar](50),
		@CreatorID			[nvarchar](20)
	)
AS
	BEGIN
		INSERT INTO		[SkillType]
			([SkillID],[SkillCategory],[SkillDescription],[CreatorID],[Custom])
		VALUES
			(@SkillID,@SkillCategory,@SkillDescription,@CreatorID,1)
	END
GO

CREATE PROCEDURE [dbo].[sp_delete_skill_type]
	(
		@SkillID			[nvarchar](25),
		@CreatorID			[nvarchar](20)
	)
AS
	BEGIN
		DELETE FROM		[SkillType]
		WHERE			[SkillID] = @SkillID
			AND			[CreatorID] = @CreatorID
			AND			[Custom] = 1
	END
GO

CREATE PROCEDURE [dbo].[sp_update_skill_type]
	(
		@SkillID				[nvarchar](25),
		@OldSkillCategory		[nvarchar](25),
		@NewSkillCategory		[nvarchar](25),
		@OldSkillDescription	[nvarchar](50),
		@NewSkillDescription	[nvarchar](50),
		@CreatorID				[nvarchar](20)
	)
AS
	BEGIN
		UPDATE		[SkillType]
		SET			[SkillCategory] = @NewSkillCategory,
					[SkillDescription] = @NewSkillDescription
		WHERE		[SkillID] = @SkillID
			AND		[SkillCategory] = @OldSkillCategory
			AND		[SkillDescription] = @OldSkillDescription
			AND		[CreatorID] = @CreatorID
		RETURN @@ROWCOUNT
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_skill_categories]
AS
	BEGIN
		SELECT		[SkillCategoryID]
		FROM		[SkillCategory]
	END
GO



CREATE PROCEDURE [dbo].[sp_view_all_custom_skills]
	(
		@CreatorID			[nvarchar](20)
	)
AS
	BEGIN
		SELECT		[SkillID],[SkillCategory],[SkillDescription]
		FROM		[SkillType]
		WHERE		[Custom] = 1
			AND		[CreatorID] = @CreatorID
	END
GO






CREATE PROCEDURE [dbo].[sp_create_new_trait]
	(
		@TraitID				[nvarchar](25),
		@TraitConnotation		[nvarchar](10),
		@TraitDescription		[nvarchar](100),
		@CreatorID				[nvarchar](20)
	)
AS
	BEGIN
		INSERT INTO		[Trait]
			([TraitID],[TraitConnotation],[TraitDescription],[CreatorID])
		VALUES
			(@TraitID,@TraitConnotation,@TraitDescription,@CreatorID)
	END
GO

CREATE PROCEDURE [dbo].[sp_delete_trait]
	(
		@TraitID		[nvarchar](25),
		@CreatorID		[nvarchar](20)
	)
AS
	BEGIN
		DELETE FROM		[Trait]
		WHERE			[TraitID] = @TraitID
			AND			[CreatorID] = @CreatorID
			AND			[Custom] = 1
		RETURN @@ROWCOUNT
	END
GO

CREATE PROCEDURE [dbo].[sp_update_trait]
	(
		@TraitID					[nvarchar](25),
		@OldTraitConnotation		[nvarchar](10),
		@NewTraitConnotation		[nvarchar](10),
		@OldTraitDescription		[nvarchar](100),
		@NewTraitDescription		[nvarchar](100),
		@CreatorID					[nvarchar](20)
	)
AS
	BEGIN
		UPDATE		[Trait]
		SET			[TraitConnotation] = @NewTraitConnotation,
					[TraitDescription] = @NewTraitDescription
		WHERE		[TraitID] = @TraitID
			AND		[TraitConnotation] = @OldTraitConnotation
			AND		[TraitDescription] = @OldTraitDescription
			AND		[CreatorID] = @CreatorID
	END
GO


CREATE PROCEDURE [dbo].[sp_view_all_custom_traits]
	(
		@CreatorID					[nvarchar](20)
	)
AS
	BEGIN
		SELECT		[TraitID],[TraitConnotation],[TraitDescription]
		FROM		[Trait]
		WHERE		[CreatorID] = @CreatorID
			AND		[Custom] = 1
	END
GO



/*

CREATE PROCEDURE [dbo].[sp_add_character_relationship]
	(
		@CharacterID						[int],
		@RelationshipID						[nvarchar](50),
		@PersonName							[nvarchar](50),
		@CharacterRelationshipDescription	[nvarchar](100)
	)
AS
	BEGIN
		INSERT INTO		[CharacterRelationship]
			([CharacterID],[RelationshipID],[PersonName],[CharacterRelationshipDescription])
		VALUES
			(@CharacterID,@RelationshipID,@PersonName,@CharacterRelationshipDescription)
	END
GO

CREATE PROCEDURE [dbo].[sp_remove_character_relationship]
	(
		@CharacterID						[int],
		@RelationshipID						[nvarchar](50),
		@PersonName							[nvarchar](50)
	)
AS
	BEGIN
		DELETE FROM		[CharacterRelationship]
		WHERE			[CharacterID] = @CharacterID
			AND			[RelationshipID] = @RelationshipID
			AND			[PersonName] = @PersonName
		RETURN @@ROWCOUNT
	END
GO

CREATE PROCEDURE [dbo].[sp_update_character_relationship]
	(
		@CharacterID							[int],
		@OldRelationshipID						[nvarchar](50),
		@NewRelationshipID						[nvarchar](50),
		@OldPersonName							[nvarchar](50),
		@NewPersonName							[nvarchar](50),
		@OldCharacterRelationshipDescription	[nvarchar](100),
		@NewCharacterRelationshipDescription	[nvarchar](100)
	)
AS
	BEGIN
		UPDATE		[CharacterRelationship]
		SET			[RelationshipID] = @NewRelationshipID,
					[PersonName] = @NewPersonName,
					[CharacterRelationshipDescription] = @NewCharacterRelationshipDescription
		WHERE		[CharacterID] = @CharacterID
			AND		[RelationshipID] = @OldRelationshipID
			AND		[PersonName] = @OldPersonName
			AND		[CharacterRelationshipDescription] = @OldCharacterRelationshipDescription
	END
GO

CREATE PROCEDURE [dbo].[sp_create_new_relationship_type]
	(
		@RelationshipID				[nvarchar](25),
		@RelationshipDescription	[nvarchar](100),
		@CreatorID					[nvarchar](20)
	)
AS
	BEGIN
		INSERT INTO		[RelationshipType]
			([RelationshipID],[RelationshipDescription],[CreatorID],[Custom])
		VALUES
			(@RelationshipID,@RelationshipDescription,@CreatorID,1)
	END
GO

CREATE PROCEDURE [dbo].[sp_delete_relationship_type]
	(
		@RelationshipID				[nvarchar](25),
		@CreatorID					[nvarchar](20)
	)
AS
	BEGIN
		DELETE FROM		[RelationshipType]
		WHERE			[RelationshipID] = @RelationshipID
			AND			[CreatorID] = @CreatorID
			AND			[Custom] = 1
		RETURN @@ROWCOUNT
	END
GO

CREATE PROCEDURE [dbo].[sp_update_relationship_type]
	(
		@RelationshipID					[nvarchar](25),
		@OldRelationshipDescription		[nvarchar](100),
		@NewRelationshipDescription		[nvarchar](100),
		@CreatorID						[nvarchar](20)
	)
AS
	BEGIN
		UPDATE		[RelationshipType]
		SET			[RelationshipDescription] = @NewRelationshipDescription
		WHERE		[RelationshipID] = @RelationshipID
			AND		[RelationshipDescription] = @OldRelationshipDescription
			AND		[CreatorID] = @CreatorID
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_relationship_types]
AS
	BEGIN
		SELECT		[RelationshipID],[RelationshipDescription]
		FROM		[RelationshipType]
		WHERE		[Custom] = 0
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_custom_relationship_types]
	(
		@CreatorID				[nvarchar](20)
	)
AS
	BEGIN
		SELECT		[RelationshipID],[RelationshipDescription]
		FROM		[RelationshipType]
		WHERE		[CreatorID] = @CreatorID
			AND		[Custom] = 1
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_character_relationships]
	(
		@CharacterID						[int],
		@RelationshipID						[nvarchar](50),
		@PersonName							[nvarchar](50)
	)
AS
	BEGIN
		SELECT		[CharacterID],[RelationshipID],[PersonName],[CharacterRelationshipDescription]
		FROM		[CharacterRelationship]
		WHERE		[CharacterID] = @CharacterID
			AND		[RelationshipID] = @RelationshipID
			AND		[PersonName] = @PersonName
	END
GO



CREATE PROCEDURE [dbo].[sp_add_character_event]
	(
		@CharacterID				[int],
		@EventID					[nvarchar](25),
		@EventLocation				[int],
		@EventDate					[date],
		@EventDescription			[nvarchar](100)
	)
AS
	BEGIN
		INSERT INTO		[CharacterEvent]
			([CharacterID],[EventID],[EventLocation],[EventDate],[EventDescription])
		VALUES
			(@CharacterID,@EventID,@EventLocation,@EventDate,@EventDescription)
	END
GO

CREATE PROCEDURE [dbo].[sp_remove_character_event]
	(
		@CharacterEventID			[int]
	)
AS
	BEGIN
		DELETE FROM		[CharacterEvent]
		WHERE			[CharacterEventID] = @CharacterEventID
	END
GO

CREATE PROCEDURE [dbo].[sp_create_new_event_type]
	(
		@EventID					[nvarchar](25),
		@EventDescription			[nvarchar](50),
		@CreatorID					[nvarchar](20)
	)
AS
	BEGIN
		INSERT INTO		[EventType]
			([EventID],[EventDescription],[CreatorID],[Custom])
		VALUES
			(@EventID,@EventDescription,@CreatorID,1)
	END
GO

CREATE PROCEDURE [dbo].[sp_delete_event_type]
	(
		@EventID					[nvarchar](25),
		@CreatorID					[nvarchar](20)
	)
AS
	BEGIN
		DELETE FROM		[EventType]
		WHERE			[EventID] = @EventID
			AND			[CreatorID] = @CreatorID
			AND			[Custom] = 1
	END
GO

CREATE PROCEDURE [dbo].[sp_update_event_type]
	(
		@EventID						[nvarchar](25),
		@OldEventDescription			[nvarchar](50),
		@NewEventDescription			[nvarchar](50),
		@CreatorID						[nvarchar](20)
	)
AS
	BEGIN
		UPDATE		[EventType]
		SET			[EventDescription] = @NewEventDescription
		WHERE		[EventID] = @EventID
			AND		[EventDescription] = @OldEventDescription
			AND		[CreatorID] = @CreatorID
	END
GO

CREATE PROCEDURE [dbo].[sp_update_character_event]
	(
		@CharacterEventID				[int],
		@OldEventLocation				[int],
		@NewEventLocation				[int],
		@OldEventDate					[date],
		@NewEventDate					[date],
		@OldEventDescription			[nvarchar](100),
		@NewEventDescription			[nvarchar](100)
	)
AS
	BEGIN
		UPDATE		[CharacterEvent]
		SET			[EventLocation] = @NewEventLocation,
					[EventDate] = @NewEventDate,
					[EventDescription] = @NewEventDescription
		WHERE		[CharacterEventID] = @CharacterEventID
			AND		[EventLocation] = @OldEventLocation
			AND		[EventDate] = @OldEventDate
			AND		[EventDescription] = @OldEventDescription
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_event_types]
AS
	BEGIN
		SELECT		[EventID],[EventDescription]
		FROM		[EventType]
		WHERE		[Custom] = 0
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_custom_event_types]
	(
		@CreatorID					[nvarchar](20)
	)
AS
	BEGIN
		SELECT		[EventID],[EventDescription]
		FROM		[EventType]
		WHERE		[CreatorID] = @CreatorID
			AND		[Custom] = 1
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_character_events]
	(
		@CharacterID				[int]
	)
AS
	BEGIN
		SELECT		[EventID],[EventLocation],[EventDate],[EventDescription]
		FROM		[CharacterEvent]
		WHERE		[CharacterID] = @CharacterID
	END
GO


*/










CREATE PROCEDURE [dbo].[sp_add_character_fact]
	(
		@CharacterID				[int],
		@FactTitle					[nvarchar](25),
		@FactDescription			[nvarchar](100)
	)
AS
	BEGIN
		INSERT INTO		[CharacterFact]
			([CharacterID],[FactTitle],[FactDescription])
		VALUES
			(@CharacterID,@FactTitle,@FactDescription)
	END
GO

CREATE PROCEDURE [dbo].[sp_remove_character_fact]
	(
		@CharacterID				[int],
		@FactTitle					[nvarchar](25),
		@FactDescription			[nvarchar](100)
	)
AS
	BEGIN
		DELETE FROM		[CharacterFact]
		WHERE			[CharacterID] = @CharacterID
			AND			[FactTitle] = @FactTitle
			AND			[FactDescription] = @FactDescription
	END
GO

CREATE PROCEDURE [dbo].[sp_update_character_fact]
	(
		@CharacterID				[int],
		@OldFactTitle				[nvarchar](25),
		@NewFactTitle				[nvarchar](25),
		@OldFactDescription			[nvarchar](100),
		@NewFactDescription			[nvarchar](100)
	)
AS
	BEGIN
		UPDATE		[CharacterFact]
		SET			[FactTitle] = @NewFactTitle,
					[FactDescription] = @NewFactDescription
		WHERE		[CharacterID] = @CharacterID
			AND		[FactTitle] = @OldFactTitle
			AND		[FactDescription] = @OldFactDescription
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_character_facts]
	(
		@CharacterID				[int]
	)
AS
	BEGIN
		SELECT		[FactTitle],[FactDescription]
		FROM		[CharacterFact]
		WHERE		[CharacterID] = @CharacterID
	END
GO


CREATE PROCEDURE [dbo].[sp_add_character_image]
	(
		@CharacterID				[int],
		@ImageFile					[nvarchar](50),
		@ImageTitle					[nvarchar](25),
		@ImageDescription			[nvarchar](100)
	)
AS
	BEGIN
		INSERT INTO		[CharacterImage]
			([CharacterID],[ImageFile],[ImageTitle],[ImageDescription])
		VALUES
			(@CharacterID,@ImageFile,@ImageTitle,@ImageDescription)
	END
GO

CREATE PROCEDURE [dbo].[sp_remove_character_image]
	(
		@CharacterID				[int],
		@ImageFile					[nvarchar](50)
	)
AS
	BEGIN
		DELETE FROM		[CharacterImage]
		WHERE			[CharacterID] = @CharacterID
			AND			[ImageFile] = @ImageFile
	END
GO

CREATE PROCEDURE [dbo].[sp_update_character_image]
	(
		@CharacterID				[int],
		@OldImageFile				[nvarchar](50),
		@NewImageFile				[nvarchar](50),
		@OldImageTitle				[nvarchar](25),
		@NewImageTitle				[nvarchar](25),
		@OldImageDescription		[nvarchar](100),
		@NewImageDescription		[nvarchar](100)
	)
AS
	BEGIN
		UPDATE		[CharacterImage]
		SET			[ImageFile] = @NewImageFile,
					[ImageTitle] = @NewImageTitle,
					[ImageDescription] = @NewImageDescription
		WHERE		[CharacterID] = @CharacterID
			AND		[ImageFile] = @OldImageFile
			AND		[ImageTitle] = @OldImageTitle
			AND		[ImageDescription] = @OldImageDescription
		
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_character_images]
	(
		@CharacterID				[int]
	)
AS
	BEGIN
		SELECT		[ImageFile],[ImageTitle],[ImageDescription]
		FROM		[CharacterImage]
		WHERE		[CharacterID] = @CharacterID
	END
GO

CREATE PROCEDURE [dbo].[sp_add_character_job]
	(
		@CharacterID					[int],
		@CharacterJob					[nvarchar](50),
		@JobLocation					[int],
		@CharacterJobDescription		[nvarchar](100),
		@WhenStartedJob					[nvarchar](50),
		@WhenEndedJob					[nvarchar](50)
	)
AS
	BEGIN
		INSERT INTO		[CharacterJob]
			([CharacterID],[CharacterJob],[JobLocation],[CharacterJobDescription],[WhenStartedJob],[WhenEndedJob])
		VALUES
			(@CharacterID,@CharacterJob,@JobLocation,@CharacterJobDescription,@WhenStartedJob,@WhenEndedJob)
	END
GO

CREATE PROCEDURE [dbo].[sp_remove_character_job]
	(
		@CharacterID					[int],
		@CharacterJob					[nvarchar](50)
	)
AS
	BEGIN
		DELETE FROM		[CharacterJob]
		WHERE			[CharacterID] = @CharacterID
			AND			[CharacterJob] = @CharacterJob
	END
GO

CREATE PROCEDURE [dbo].[sp_create_new_job_type]
	(
		@JobID							[nvarchar](25),
		@JobDescription					[nvarchar](50),
		@CreatorID						[nvarchar](20)
	)
AS
	BEGIN
		INSERT INTO		[JobType]
			([JobID],[JobDescription],[CreatorID],[Custom])
		VALUES
			(@JobID,@JobDescription,@CreatorID,1)
	END
GO

CREATE PROCEDURE [dbo].[sp_delete_job_type]
	(
		@JobID							[nvarchar](25),
		@CreatorID						[nvarchar](20)
	
	)
AS
	BEGIN
		DELETE FROM		[JobType]
		WHERE			[JobID] = @JobID
			AND			[CreatorID] = @CreatorID
			AND			[Custom] = 1
	END
GO

CREATE PROCEDURE [dbo].[sp_update_job_type]
	(
		@JobID							[nvarchar](25),
		@OldJobDescription				[nvarchar](50),
		@NewJobDescription				[nvarchar](50),
		@CreatorID						[nvarchar](20)
	)
AS
	BEGIN
		UPDATE		[JobType]
		SET			[JobDescription] = @NewJobDescription
		WHERE		[JobID] = @JobID
			AND		[JobDescription] = @OldJobDescription
			AND		[CreatorID] = @CreatorID
			AND		[Custom] = 1
	END
GO

CREATE PROCEDURE [dbo].[sp_update_character_job]
	(
		@CharacterID					[int],
		@CharacterJob					[nvarchar](50),
		@OldJobLocation					[int],
		@NewJobLocation					[int],
		@OldCharacterJobDescription		[nvarchar](100),
		@NewCharacterJobDescription		[nvarchar](100),
		@OldWhenStartedJob				[nvarchar](50),
		@NewWhenStartedJob				[nvarchar](50),
		@OldWhenEndedJob				[nvarchar](50),
		@NewWhenEndedJob				[nvarchar](50)
	)
AS
	BEGIN
		UPDATE		[CharacterJob]
		SET			[JobLocation] = @NewJobLocation,
					[CharacterJobDescription] = @NewCharacterJobDescription,
					[WhenStartedJob] = @NewWhenStartedJob,
					[WhenEndedJob] = @NewWhenEndedJob
		WHERE		[CharacterID] = @CharacterID
			AND		[JobLocation] = @OldJobLocation
			AND		[CharacterJobDescription] = @OldCharacterJobDescription
			AND		[WhenStartedJob] = @OldWhenStartedJob
			AND		[WhenEndedJob] = @OldWhenEndedJob
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_job_types]
AS
	BEGIN
		SELECT		[JobID],[JobDescription]
		FROM		[JobType]
		WHERE		[Custom] = 0
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_custom_job_types]
	(
		@CreatorID					[nvarchar](20)
	)
AS
	BEGIN
		SELECT		[JobID],[JobDescription]
		FROM		[JobType]
		WHERE		[CreatorID] = @CreatorID
			AND		[Custom] = 1
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_character_jobs]
	(
		@CharacterID				[int]
	)
AS
	BEGIN
		SELECT		[CharacterJob],[JobLocation],[CharacterJobDescription],[WhenStartedJob],[WhenEndedJob]
		FROM		[CharacterJob]
		WHERE		[CharacterID] = @CharacterID
	END
GO



CREATE PROCEDURE [dbo].[sp_add_character_education]
	(
		@CharacterID							[int],
		@EducationID							[nvarchar](25),
		@EducationLocation						[int],
		@CharacterEducationDescription			[nvarchar](100)
	)
AS
	BEGIN
		INSERT INTO		[CharacterEducation]
			([CharacterID],[EducationID],[EducationLocation],[CharacterEducationDescription])
		VALUES
			(@CharacterID,@EducationID,@EducationLocation,@CharacterEducationDescription)
	END
GO

CREATE PROCEDURE [dbo].[sp_remove_character_education]
	(
		@CharacterID							[int],
		@EducationID							[nvarchar](25)
	)
AS
	BEGIN
		DELETE FROM		[CharacterEducation]
		WHERE			[CharacterID] = @CharacterID
			AND			[EducationID] = @EducationID
	END
GO

CREATE PROCEDURE [dbo].[sp_update_character_education]
	(
		@CharacterID							[int],
		@EducationID							[nvarchar](25),
		@OldEducationLocation					[int],
		@NewEducationLocation					[int],
		@OldCharacterEducationDescription		[nvarchar](100),
		@NewCharacterEducationDescription		[nvarchar](100)
	)
AS
	BEGIN
		UPDATE		[CharacterEducation]
		SET			[EducationLocation] = @NewEducationLocation,
					[CharacterEducationDescription] = @NewCharacterEducationDescription
		WHERE		[CharacterID] = @CharacterID
			AND		[EducationLocation] = @OldEducationLocation
			AND		[CharacterEducationDescription] = @NewCharacterEducationDescription
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_educations]
AS
	BEGIN
		SELECT		[EducationID],[EducationDescription]
		FROM		[EducationType]
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_character_educations]
	(
		@CharacterID							[int]
	)
AS
	BEGIN
		SELECT		[EducationID],[EducationLocation],[CharacterEducationDescription]
		FROM		[CharacterEducation]
		WHERE		[CharacterID] = @CharacterID
	END
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

CREATE PROCEDURE [dbo].[sp_view_all_locations]
	(
		@CreatorID				[nvarchar](20)
	)
AS
	BEGIN
		SELECT	[LocationID],[LocationName],[LocationCountry],[LocationSubdivision],[LocationCity],[LocationAddress],[LocationDescription]
		FROM	[Location]
		WHERE	[CreatorID] = @CreatorID
	END
GO

CREATE PROCEDURE [dbo].[sp_view_location_by_locationid]
	(
		@LocationID				[int]
	)
AS
	BEGIN
		SELECT	[LocationName],[LocationCountry],[LocationSubdivision],[LocationCity],[LocationAddress],[LocationDescription],[CreatorID]
		FROM	[Location]
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
		SELECT	[CityID],[CityName],[CityCountry],[CitySubdivision],[CityDescription]
		FROM	[City]
		WHERE	[Custom] = 0
	END
GO









-- CREATE PROCEDURE [dbo].[sp_add_character_language]
-- CREATE PROCEDURE [dbo].[sp_remove_character_language]
-- CREATE PROCEDURE [dbo].[sp_create_new_language]
-- CREATE PROCEDURE [dbo].[sp_delete_language]
-- CREATE PROCEDURE [dbo].[sp_update_language]
-- CREATE PROCEDURE [dbo].[sp_update_character_language]
-- CREATE PROCEDURE [dbo].[sp_view_all_languages]
-- CREATE PROCEDURE [dbo].[sp_view_all_custom_languages]
-- CREATE PROCEDURE [dbo].[sp_view_all_character_languages]













