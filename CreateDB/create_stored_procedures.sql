print '' print '*** using database character_creator ***' print ''
GO
USE [character_creator]
GO

CREATE PROCEDURE [dbo].[sp_get_all_users]
AS
	BEGIN
		SELECT		[UserID],[Email],[ProfilePicture],[AccountBio],[Active]
		FROM		[UserAccount]
	END
GO

CREATE PROCEDURE [dbo].[sp_get_user_by_email]
	(
		@Email						[nvarchar](100)
	)
AS
	BEGIN
		SELECT		[UserID],[Email],[ProfilePicture],[AccountBio],[Active]
		FROM		[UserAccount]
		WHERE		[Email] = @Email
	END
GO



CREATE PROCEDURE [dbo].[sp_authenticate_user]
	(
		@UserID			[nvarchar](20),
		@PasswordHash	[nvarchar](100)
	)
AS
	BEGIN
		SELECT		COUNT([UserID])
		FROM		[UserAccount]
		WHERE		[UserID] = @UserID
		  AND		[PasswordHash] = @PasswordHash
		  AND		[Active] = 1
	END
GO

CREATE PROCEDURE [dbo].[sp_create_new_account]
	(
		@UserID			[nvarchar](20),
		@Email			[nvarchar](100),
		@PasswordHash	[nvarchar](100)
	)
AS
	BEGIN
		INSERT INTO [dbo].[UserAccount]
			([UserID],[Email],[PasswordHash])
		VALUES
			(@UserID,@Email,@PasswordHash)
		SELECT SCOPE_IDENTITY()
	END
GO

CREATE PROCEDURE [dbo].[sp_update_account_email]
	(
		@UserID			[nvarchar](20),
		@OldEmail		[nvarchar](100),
		@NewEmail		[nvarchar](100)
	)
AS
	BEGIN
		UPDATE		[UserAccount]
		SET			[Email] = @NewEmail
		WHERE		[UserID] = @UserID
			AND		[Email]= @OldEmail
		RETURN @@ROWCOUNT
	END
GO

CREATE PROCEDURE [dbo].[sp_update_account_password]
	(
		@UserID				[nvarchar](20),
		@Email				[nvarchar](100),
		@OldPasswordHash	[nvarchar](100),
		@NewPasswordHash	[nvarchar](100)
	)
AS
	BEGIN
		UPDATE		[UserAccount]
		SET			[PasswordHash] = @NewPasswordHash
		WHERE		[UserID] = @UserID
			AND		[Email] = @Email
			AND		[PasswordHash] = @OldPasswordHash
		RETURN @@ROWCOUNT
	END
GO

CREATE PROCEDURE [dbo].[sp_update_account_bio]
	(
		@UserID				[nvarchar](20),
		@OldAccountBio		[nvarchar](500),
		@NewAccountBio		[nvarchar](500)
	)
AS
	BEGIN
		UPDATE		[UserAccount]
		SET			[AccountBio] = @NewAccountBio
		WHERE		[UserID] = @UserID
			AND		[AccountBio] = @OldAccountBio
		RETURN @@ROWCOUNT
	END
GO

CREATE PROCEDURE [dbo].[sp_search_accounts_by_username]
	(
			@UserID				[nvarchar](20)
	)
AS
	BEGIN
		SELECT		[UserID]
		FROM		[UserAccount]
		WHERE		[UserID] = @UserID
	END
GO

CREATE PROCEDURE [dbo].[sp_view_account_profile]
	(
		@UserID						[nvarchar](20)
	)
AS
	BEGIN
		SELECT		[UserID],[Email],[ProfilePicture],[AccountBio],[Active]
		FROM		[UserAccount]
		WHERE		[UserID] = @UserID
	END
GO

CREATE PROCEDURE [dbo].[sp_get_friend_status]
	(
		@UserID						[nvarchar](20),
		@UserFriendID				[nvarchar](20)
	)
AS
	BEGIN
		SELECT		[UserFriendStatus],[UserFriendDate]
		FROM		[UserFriend]
		WHERE		[UserID] = @UserID
			AND		[UserFriendID] = @UserFriendID
	END
GO


CREATE PROCEDURE [dbo].[sp_block_user]
	(
		@Blocker					[nvarchar](20),
		@Blocked					[nvarchar](20)
	)
AS
	BEGIN
		DELETE FROM		[UserFriend]
		WHERE			[UserID] = @Blocker
			AND			[UserFriendID] = @Blocked
		DELETE FROM		[UserFriend]
		WHERE			[UserID] = @Blocked
			AND			[UserFriendID] = @Blocker
		INSERT INTO [dbo].[UserFriend]
			([UserID],[UserFriendID],[UserFriendStatus])
		VALUES
			(@Blocker,@Blocked,'blocked'),
			(@Blocked,@Blocker,'blocker')
		DELETE FROM		[UserPermission]
		WHERE			[CreatorID] = @Blocker
			AND			[UserID] = @Blocked
		DELETE FROM		[UserPermission]
		WHERE			[CreatorID] = @Blocked
			AND			[UserID] = @Blocker
	END
GO


CREATE PROCEDURE [dbo].[sp_unblock_user]
	(
		@Blocker					[nvarchar](20),
		@Blocked					[nvarchar](20)
	)
AS
	BEGIN
		DELETE FROM		[UserFriend]
		WHERE			[UserID] = @Blocker
			AND			[UserFriendID] = @Blocked
			AND			[UserFriendStatus] = 'blocked'
		DELETE FROM		[UserFriend]
		WHERE			[UserID] = @Blocked
			AND			[UserFriendID] = @Blocker
			AND			[UserFriendStatus] = 'blocker'
	END
GO


CREATE PROCEDURE [dbo].[sp_send_friend_request]
	(
		@UserID						[nvarchar](20),
		@UserFriendID				[nvarchar](20)
	)
AS
	BEGIN
		INSERT INTO [dbo].[UserFriend]
			([UserID],[UserFriendID],[UserFriendStatus])
		VALUES
			(@UserID,@UserFriendID,'pending'),
			(@UserFriendID,@UserID,'waiting')
	END
GO

CREATE PROCEDURE [dbo].[sp_view_pending_requests]
	(
		@UserID						[nvarchar](20)
	)
AS
	BEGIN
		SELECT		[UserFriendID]
		FROM		[UserFriend]
		WHERE		[UserID] = @UserID
			AND		[UserFriendStatus] = 'pending'
	END
GO

CREATE PROCEDURE [dbo].[sp_cancel_pending_friend_requests]
	(
		@UserID						[nvarchar](20),
		@UserFriendID				[nvarchar](20)
	)
AS
	BEGIN
		DELETE FROM		[UserFriend]
		WHERE			[UserID] = @UserID
			AND			[UserFriendID] = @UserFriendID
			AND			[UserFriendStatus] = 'pending'
		DELETE FROM		[UserFriend]
		WHERE			[UserID] = @UserFriendID
			AND			[UserFriendID] = @UserID
			AND			[UserFriendStatus] = 'waiting'
	END
GO

CREATE PROCEDURE [dbo].[sp_view_friend_requests]
	(
		@UserID						[nvarchar](20)
	)
AS
	BEGIN
		SELECT		[UserFriendID]
		FROM		[UserFriend]
		WHERE		[UserID] = @UserID
			AND		[UserFriendStatus] = 'waiting'
	END
GO

CREATE PROCEDURE [dbo].[sp_accept_friend_request]
	(
		@UserID						[nvarchar](20),
		@UserFriendID				[nvarchar](20)
	)
AS
	BEGIN
		UPDATE		[UserFriend]
		SET			[UserFriendStatus] = 'friend',
					[UserFriendDate] = GETDATE()
		WHERE		[UserID] = @UserID
			AND		[UserFriendID] = @UserFriendID
			AND		[UserFriendStatus] = 'waiting'
		UPDATE		[UserFriend]
		SET			[UserFriendStatus] = 'friend',
					[UserFriendDate] = GETDATE()
		WHERE		[UserID] = @UserFriendID
			AND		[UserFriendID] = @UserID
			AND		[UserFriendStatus] = 'pending'
		RETURN @@ROWCOUNT
	END
GO

CREATE PROCEDURE [dbo].[sp_deny_friend_request]
	(
		@UserID						[nvarchar](20),
		@UserFriendID				[nvarchar](20)
	)
AS
	BEGIN
		DELETE FROM		[UserFriend]
		WHERE			[UserID] = @UserID
			AND			[UserFriendID] = @UserFriendID
			AND			[UserFriendStatus] = 'waiting'
		DELETE FROM		[UserFriend]
		WHERE			[UserID] = @UserFriendID
			AND			[UserFriendID] = @UserID
			AND			[UserFriendStatus] = 'pending'
	END
GO

CREATE PROCEDURE [dbo].[sp_remove_friend]
	(
		@UserID						[nvarchar](20),
		@UserFriendID				[nvarchar](20)
	)
AS
	BEGIN
		DELETE FROM		[UserFriend]
		WHERE			[UserID] = @UserID
			AND			[UserFriendID] = @UserFriendID
			AND			[UserFriendStatus] = 'friend'
		DELETE FROM		[UserFriend]
		WHERE			[UserID] = @UserFriendID
			AND			[UserFriendID] = @UserID
			AND			[UserFriendStatus] = 'friend'
		DELETE FROM		[UserPermission]
		WHERE			[CreatorID] = @UserID
			AND			[UserID] = @UserFriendID
		DELETE FROM		[UserPermission]
		WHERE			[CreatorID] = @UserFriendID
			AND			[UserID] = @UserID
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_friends]
	(
		@UserID						[nvarchar](20)
	)
AS
	BEGIN
		SELECT		[UserFriendID],[UserFriendDate]
		FROM		[UserFriend]
		WHERE		[UserID] = @UserID
			AND		[UserFriendStatus] = 'friend'
		ORDER BY	[UserFriendDate]
	END
GO

CREATE PROCEDURE [dbo].[sp_create_new_character]
	(
		@UserID					[nvarchar](20),
		@CharacterName			[nvarchar](50)
	)
AS
	BEGIN
		INSERT INTO		[UserCharacter]
			([CreatorID],[CharacterName])
		VALUES
			(@UserID,@CharacterName)
	END
GO

CREATE PROCEDURE [dbo].[sp_deactivate_character]
	(
		@UserID					[nvarchar](20),
		@CharacterID			[int],
		@CharacterName			[nvarchar](50)
	)
AS
	BEGIN
		UPDATE		[UserCharacter]
		SET			[Active] = 0
		WHERE		[CreatorID] = @UserID
			AND		[CharacterID] = @CharacterID
			AND		[CharacterName] = @CharacterName
	END
GO

CREATE PROCEDURE [dbo].[sp_view_character_list]
	(
		@UserID					[nvarchar](20)
	)
AS
	BEGIN
		SELECT		[CharacterID],[CharacterName],
					[CharacterFirstName],[CharacterLastName],[CharacterMiddleName],
					[CreatedAt],[LastEdited]
		FROM		[UserCharacter]
		WHERE		[CreatorID] = @UserID
			AND		[Active] = 1
		ORDER BY	[LastEdited] DESC
	END
GO

CREATE PROCEDURE [dbo].[sp_view_character_by_characterid]
	(
		@CharacterID			[int]
	)
AS
	BEGIN
		SELECT		[CreatorID],[CharacterName],
					[CharacterFirstName],[CharacterLastName],[CharacterMiddleName],
					[CreatedAt],[LastEdited]
		FROM		[UserCharacter]
		WHERE		[CharacterID] = @CharacterID
			AND		[Active] = 1
	END
GO

CREATE PROCEDURE [dbo].[sp_give_access_for_character]
	(
		@UserID					[nvarchar](20),
		@CreatorID				[nvarchar](20),
		@CharacterID			[int],
		@AccessType				[nvarchar](20)
	)
AS
	BEGIN
		DELETE FROM		[UserPermission]
		WHERE			[UserID] = @UserID
			AND			[CharacterID] = @CharacterID
		INSERT INTO		[UserPermission]
			([UserID],[CreatorID],[CharacterID],[PermissionID])
		VALUES
			(@UserID,@CreatorID,@CharacterID,@AccessType)
	END
GO

CREATE PROCEDURE [dbo].[sp_view_access_for_character]
	(
		@CharacterID			[int]
	)
AS
	BEGIN
		SELECT	[UserID],[PermissionID]
		FROM	[UserPermission]
		WHERE	[CharacterID] = @CharacterID
	END
GO

CREATE PROCEDURE [dbo].[sp_remove_access_for_character]
	(
		@UserID					[nvarchar](20),
		@CharacterID			[int]
	)
AS
	BEGIN
		DELETE FROM		[UserPermission]
		WHERE			[UserID] = @UserID
			AND			[CharacterID] = @CharacterID
	END
GO

CREATE PROCEDURE [dbo].[sp_view_friends_without_access]
	(
		@UserID					[nvarchar](20),
		@CharacterID			[int]
	)
AS
	BEGIN
		SELECT	[UserFriendID]
		FROM	[UserFriend]
		JOIN	[UserPermission]
			ON	[UserFriend].[UserFriendID] = [UserPermission].[UserID]
		JOIN	[UserAccount]
			ON	[UserFriend].[UserFriendID] = [UserAccount].[UserID]
		WHERE	[UserFriend].[UserID] = @UserID
			AND	[UserFriendStatus] = "Friend"
			AND	[UserPermission].[PermissionID] IS NULL
	END
GO


CREATE PROCEDURE [dbo].[sp_view_access_characters]
	(
		@UserID					[nvarchar](20)
	)
AS
	BEGIN
		SELECT		[UserPermission].[CharacterID],[UserPermission].[CreatorID],[CharacterName],[PermissionID]
		FROM		[UserPermission]
		JOIN		[UserCharacter]
			ON		[UserPermission].[CharacterID] = [UserCharacter].[CharacterID]
		WHERE		[UserID] = @UserID
			AND		[Active] = 1
	END
GO

CREATE PROCEDURE [dbo].[sp_update_last_edited]
	(
		@CharacterID				[int]
	)
AS
	BEGIN
		UPDATE		[UserCharacter]
		SET			[LastEdited] = GETDATE()
		WHERE		[CharacterID] = @CharacterID
	END
GO



CREATE PROCEDURE [dbo].[sp_update_user_character]
	(
		@CharacterID				[int],
		@OldCharacterName			[nvarchar](50),
		@NewCharacterName			[nvarchar](50),
		@OldFirstName				[nvarchar](50),
		@NewFirstName				[nvarchar](50),
		@OldLastName				[nvarchar](50),
		@NewLastName				[nvarchar](50),
		@OldMiddleName				[nvarchar](50),
		@NewMiddleName				[nvarchar](50)
	)
AS
	BEGIN
		UPDATE		[UserCharacter]
		SET			[CharacterName] = @NewCharacterName,
					[CharacterFirstName] = @NewFirstName,
					[CharacterLastName] = @NewLastName,
					[CharacterMiddleName] = @NewMiddleName,
					[LastEdited] = GETDATE()
		WHERE		[CharacterID] = @CharacterID
			AND		[CharacterName] = @OldCharacterName
			AND		([CharacterFirstName] = @OldFirstName OR ([CharacterFirstName] IS NULL AND @OldFirstName IS NULL))
			AND		([CharacterLastName] = @OldLastName OR ([CharacterLastName] IS NULL AND @OldLastName IS NULL))
			AND		([CharacterMiddleName] = @OldMiddleName OR ([CharacterMiddleName] IS NULL AND @OldMiddleName IS NULL))
	END
GO

CREATE PROCEDURE [dbo].[sp_add_character_skill]
	(
		@CharacterID					[int],
		@SkillID						[nvarchar](25),
		@CharacterSkillDescription		[nvarchar](100)
	)
AS
	BEGIN
		INSERT INTO		[CharacterSkill]
			([CharacterID],[SkillID],[CharacterSkillDescription])
		VALUES
			(@CharacterID,@SkillID,@CharacterSkillDescription)
		EXEC sp_update_last_edited @CharacterID
	END
GO

CREATE PROCEDURE [dbo].[sp_remove_character_skill]
	(
		@CharacterID				[int],
		@SkillID					[nvarchar](25)
	)
AS
	BEGIN
		DELETE FROM		[CharacterSkill]
		WHERE			[CharacterID] = @CharacterID
			AND			[SkillID] = @SkillID
		EXEC sp_update_last_edited @CharacterID
	END
GO

CREATE PROCEDURE [dbo].[sp_update_character_skill]
	(
		@CharacterID					[int],
		@SkillID						[nvarchar](25),
		@OldCharacterSkillDescription	[nvarchar](100),
		@NewCharacterSkillDescription	[nvarchar](100)
	)
AS
	BEGIN
		UPDATE		[CharacterSkill]
		SET			[CharacterSkillDescription] = @NewCharacterSkillDescription
		WHERE		[CharacterID] = @CharacterID
			AND		[CharacterSkillDescription] = @OldCharacterSkillDescription
		EXEC sp_update_last_edited @CharacterID
		RETURN @@ROWCOUNT
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_skill_types]
AS
	BEGIN
		SELECT		[SkillID],[SkillCategory],[SkillDescription]
		FROM		[SkillType]
		WHERE		[Custom] = 0
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_character_skills]
	(
		@CharacterID		[int]
	)
AS
	BEGIN
		SELECT		[CharacterID],[SkillID],[CharacterSkillDescription]
		FROM		[CharacterSkill]
		WHERE		[CharacterID] = @CharacterID
	END
GO

CREATE PROCEDURE [dbo].[sp_add_character_trait]
	(
		@CharacterID			[int],
		@TraitID				[nvarchar](25)
	)
AS
	BEGIN
		INSERT INTO		[CharacterTrait]
			([CharacterID],[TraitID])
		VALUES
			(@CharacterID,@TraitID)
		EXEC sp_update_last_edited @CharacterID
		RETURN @@ROWCOUNT
	END
GO

CREATE PROCEDURE [dbo].[sp_remove_character_trait]
	(
		@CharacterID			[int],
		@TraitID				[nvarchar](25)
	)
AS
	BEGIN
		DELETE FROM		[CharacterTrait]
		WHERE			[CharacterID] = @CharacterID
			AND			[TraitID] = @TraitID
		EXEC sp_update_last_edited @CharacterID
		RETURN @@ROWCOUNT
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_traits]
AS
	BEGIN
		SELECT		[TraitID],[TraitConnotation],[TraitDescription]
		FROM		[Trait]
		WHERE		[Custom] = 0
	END
GO

CREATE PROCEDURE [dbo].[sp_view_all_character_traits]
	(
		@CharacterID			[int]
	)
AS
	BEGIN
		SELECT		[CharacterID],[TraitDescription],[TraitConnotation],[CharacterTrait].[TraitID]
		FROM		[CharacterTrait]
		JOIN		[Trait]
			ON		[CharacterTrait].[TraitID] = [Trait].[TraitID]
		WHERE		[CharacterID] = @CharacterID
	END
GO


CREATE PROCEDURE [dbo].[sp_add_character_like_or_dislike]
	(
		@CharacterID								[int],
		@LikeDislikeType							[nvarchar](10),
		@CharacterLikeDislike						[nvarchar](25),
		@CharacterLikeDislikeDescription			[nvarchar](50)
	)
AS
	BEGIN
		INSERT INTO		[CharacterLikeDislike]
			([CharacterID],[LikeDislikeType],[CharacterLikeDislike],[CharacterLikeDislikeDescription])
		VALUES
			(@CharacterID,@LikeDislikeType,@CharacterLikeDislike,@CharacterLikeDislikeDescription)
		EXEC sp_update_last_edited @CharacterID
	END
GO

CREATE PROCEDURE [dbo].[sp_remove_character_like_or_dislike]
	(
		@CharacterID								[int],
		@LikeDislikeType							[nvarchar](10),
		@CharacterLikeDislike						[nvarchar](25)
	)
AS
	BEGIN
		DELETE FROM		[CharacterLikeDislike]
		WHERE			[CharacterID] = @CharacterID
			AND			[LikeDislikeType] = @LikeDislikeType
			AND			[CharacterLikeDislike] = @CharacterLikeDislike
		EXEC sp_update_last_edited @CharacterID
	END
GO


CREATE PROCEDURE [dbo].[sp_update_character_like_or_dislike]
	(
		@CharacterID								[int],
		@OldCharacterLikeDislike					[nvarchar](25),
		@NewCharacterLikeDislike					[nvarchar](25),
		@OldCharacterLikeDislikeDescription			[nvarchar](50),
		@NewCharacterLikeDislikeDescription			[nvarchar](50)
	)
AS
	BEGIN
		UPDATE		[CharacterLikeDislike]
		SET			[CharacterLikeDislike] = @NewCharacterLikeDislike,
					[CharacterLikeDislikeDescription] = @NewCharacterLikeDislikeDescription

		WHERE		[CharacterID] = @CharacterID
			AND		[CharacterLikeDislike] = @OldCharacterLikeDislike
			AND		[CharacterLikeDislikeDescription] = @OldCharacterLikeDislikeDescription
		EXEC sp_update_last_edited @CharacterID
	END
GO


CREATE PROCEDURE [dbo].[sp_view_all_character_likes_and_dislikes]
	(
		@CharacterID					[int]
	)
AS
	BEGIN
		SELECT		[LikeDislikeType],[CharacterLikeDislike],[CharacterLikeDislikeDescription]
		FROM		[CharacterLikeDislike]
		WHERE		[CharacterID] = @CharacterID
	END
GO


