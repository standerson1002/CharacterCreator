/* drop the database if it exists */
print '' print '*** dropping database character_creator ***'
GO
IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'character_creator')
BEGIN
	DROP DATABASE [character_creator];
END
GO
print '' print '*** creating database character_creator ***' print ''
GO
CREATE DATABASE [character_creator]
GO
USE [character_creator]
GO


print '' print '*** creating app user table ***'
GO
CREATE TABLE [dbo].[UserAccount] (
	[UserID]			[nvarchar](20)				NOT NULL,
	[Email]				[nvarchar](100)				NOT NULL,
	[ProfilePicture]	[nvarchar](250)				NOT NULL	DEFAULT '',
	[AccountBio]		[nvarchar](500)				NOT NULL	DEFAULT '',
	[PasswordHash]		[nvarchar](100)				NOT NULL	DEFAULT '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
	[Active]			[bit]						NOT NULL	DEFAULT 1,
	
	CONSTRAINT [pk_userid] PRIMARY KEY ([UserID] ASC),
	CONSTRAINT [ak_email] UNIQUE([Email] ASC)
)
GO

print '' print '*** creating user friend status table ***'
GO
CREATE TABLE [dbo].[UserFriendStatusType] (
	[UserFriendStatusID]	[nvarchar](20)			NOT NULL,

	CONSTRAINT [pk_userfriendstatusid] PRIMARY KEY ([UserFriendStatusID] ASC)
)
GO

print '' print '*** creating user friend table ***'
GO
CREATE TABLE [dbo].[UserFriend] (
	[UserID]				[nvarchar](20)				NOT NULL,
	[UserFriendID]			[nvarchar](20)				NOT NULL,
	[UserFriendStatus]		[nvarchar](20)				NOT NULL,
	[UserFriendDate]		[date]						NULL		DEFAULT '2000-01-01',

	CONSTRAINT [fk_userfriend_userid] FOREIGN KEY ([UserID])
		REFERENCES [UserAccount]([UserID]),
	CONSTRAINT [fk_userfriend_userfriendid] FOREIGN KEY ([UserFriendID])
		REFERENCES [UserAccount]([UserID]),
	CONSTRAINT [fk_userfriend_userfriendstatus] FOREIGN KEY ([UserFriendStatus])
		REFERENCES [UserFriendStatusType]([UserFriendStatusID])
)
GO

print '' print '*** creating permission type table ***'
GO
CREATE TABLE [dbo].[PermissionType] (
	[PermissionID]			[nvarchar](20)		NOT NULL,
	[PermissionDescription]	[nvarchar](100)		NOT NULL,
	
	CONSTRAINT [pk_permissionid] PRIMARY KEY ([PermissionID] ASC)
)
GO



print '' print '*** creating user character table ***'
GO
CREATE TABLE [dbo].[UserCharacter] (
	[CharacterID]				[int] IDENTITY(1000000, 1)	NOT NULL,
	[CreatorID]					[nvarchar](20)				NOT NULL,
	[CharacterName]				[nvarchar](50)				NOT NULL,
	[CharacterFirstName]		[nvarchar](50)				NULL,
	[CharacterLastName]			[nvarchar](50)				NULL,
	[CharacterMiddleName]		[nvarchar](50)				NULL,
	[CreatedAt]					[date]						NOT NULL	DEFAULT GETDATE(),
	[LastEdited]				[date]						NOT NULL	DEFAULT GETDATE(),
	[Active]					[bit]						NOT NULL	DEFAULT 1,

	CONSTRAINT [pk_characterid] PRIMARY KEY ([CharacterID] ASC),
	CONSTRAINT [fk_usercharacter_creatorid] FOREIGN KEY ([CreatorID])
		REFERENCES [UserAccount]([UserID])
)
GO


print '' print '*** creating user permission table ***'
GO
CREATE TABLE [dbo].[UserPermission] (
	[UserID]			[nvarchar](20)				NOT NULL,
	[CreatorID]			[nvarchar](20)				NOT NULL,
	[CharacterID]		[int]						NOT NULL,
	[PermissionID]		[nvarchar](20)				NOT NULL,
	
	CONSTRAINT [fk_userpermission_userid] FOREIGN KEY ([UserID])
		REFERENCES [UserAccount]([UserID]),
	CONSTRAINT [fk_userpermission_creatorid] FOREIGN KEY ([CreatorID])
		REFERENCES [UserAccount]([UserID]),
	CONSTRAINT [fk_userpermission_characterid] FOREIGN KEY ([CharacterID])
		REFERENCES [UserCharacter]([CharacterID]),
	CONSTRAINT [fk_userpermission_permissionid] FOREIGN KEY ([PermissionID])
		REFERENCES [PermissionType]([PermissionID])
)
GO



print '' print '*** creating favorite type table ***'
GO
CREATE TABLE [dbo].[LikeDislikeType] (
	[LikeDislikeTypeID]				[nvarchar](10)		NOT NULL,
	
	CONSTRAINT [pk_likedisliketypeid] PRIMARY KEY ([LikeDislikeTypeID] ASC)
)
GO


print '' print '*** creating character like dislike table ***'
GO
CREATE TABLE [dbo].[CharacterLikeDislike] (
	[CharacterID]							[int]			NOT NULL,
	[LikeDislikeType]						[nvarchar](10)	NOT NULL,
	[CharacterLikeDislike]					[nvarchar](25)	NOT NULL,
	[CharacterLikeDislikeDescription]		[nvarchar](50)	NULL	DEFAULT '',
	
	CONSTRAINT [fk_characterlikedislike_characterid] FOREIGN KEY ([CharacterID])
		REFERENCES [UserCharacter]([CharacterID]),
	CONSTRAINT [fk_characterlikedislike_likedisliketype] FOREIGN KEY ([LikeDislikeType])
		REFERENCES [LikeDislikeType]([LikeDislikeTypeID])
)
GO


print '' print '*** creating trait table ***'
GO
CREATE TABLE [dbo].[Trait] (
	[TraitID]				[nvarchar](25)			NOT NULL,
	[TraitConnotation]		[nvarchar](10)			NOT NULL,
	[TraitDescription]		[nvarchar](100)			NOT NULL,
	[CreatorID]				[nvarchar](20)			NULL,
	[Custom]				[bit]					NOT NULL	DEFAULT 0,
	
	CONSTRAINT [pk_traitid] PRIMARY KEY ([TraitID] ASC),
	CONSTRAINT [fk_trait_creatorid] FOREIGN KEY ([CreatorID])
		REFERENCES [UserAccount]([UserID])
)
GO

print '' print '*** creating character trait table ***'
GO
CREATE TABLE [dbo].[CharacterTrait] (
	[CharacterID]			[int]				NOT NULL,
	[TraitID]				[nvarchar](25)		NOT NULL,

	CONSTRAINT [fk_charactertrait_characterid] FOREIGN KEY ([CharacterID])
		REFERENCES [UserCharacter]([CharacterID]),
	CONSTRAINT [fk_charactertrait_traitid] FOREIGN KEY ([TraitID])
		REFERENCES [Trait]([TraitID])
)
GO


print '' print '*** creating skill category table ***'
GO
CREATE TABLE [dbo].[SkillCategory] (
	[SkillCategoryID]		[nvarchar](25)				NOT NULL,
	
	CONSTRAINT [pk_skillcategoryid] PRIMARY KEY ([SkillCategoryID] ASC)
)
GO

print '' print '*** creating skill type table ***'
GO
CREATE TABLE [dbo].[SkillType] (
	[SkillID]				[nvarchar](25)		NOT NULL,
	[SkillCategory]			[nvarchar](25)		NOT NULL,
	[SkillDescription]		[nvarchar](50)		NULL,
	[CreatorID]				[nvarchar](20)		NULL,
	[Custom]				[bit]				NOT NULL	DEFAULT 0,
	
	CONSTRAINT [pk_skillid] PRIMARY KEY ([SkillID] ASC),
	CONSTRAINT [fk_skilltype_skillcategory] FOREIGN KEY([SkillCategory])
		REFERENCES [SkillCategory]([SkillCategoryID]),
	CONSTRAINT [fk_skilltype_creatorid] FOREIGN KEY ([CreatorID])
		REFERENCES [UserAccount]([UserID])
)
GO

print '' print '*** creating character skill table ***'
GO
CREATE TABLE [dbo].[CharacterSkill] (
	[CharacterID]				[int]				NOT NULL,
	[SkillID]					[nvarchar](25)		NOT NULL,
	[CharacterSkillDescription]	[nvarchar](100)		NULL,

	CONSTRAINT [fk_characterskill_characterid] FOREIGN KEY ([CharacterID])
		REFERENCES [UserCharacter]([CharacterID]),
	CONSTRAINT [fk_characterskill_skillid] FOREIGN KEY ([SkillID])
		REFERENCES [SkillType]([SkillID])
)
GO
