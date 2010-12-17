
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK59478D308622E1CB]') AND parent_object_id = OBJECT_ID('MusicReviewsToMusicTypes'))
alter table MusicReviewsToMusicTypes  drop constraint FK59478D308622E1CB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK59478D309DF0A8A]') AND parent_object_id = OBJECT_ID('MusicReviewsToMusicTypes'))
alter table MusicReviewsToMusicTypes  drop constraint FK59478D309DF0A8A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6D28D6529BC62AC]') AND parent_object_id = OBJECT_ID('Reviews'))
alter table Reviews  drop constraint FK6D28D6529BC62AC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5F89AD0F5687A200]') AND parent_object_id = OBJECT_ID('MusicReviews'))
alter table MusicReviews  drop constraint FK5F89AD0F5687A200


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB669828AEB69D95]') AND parent_object_id = OBJECT_ID('ReviewTypes'))
alter table ReviewTypes  drop constraint FKB669828AEB69D95


    if exists (select * from dbo.sysobjects where id = object_id(N'UsersToReviewTypes') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table UsersToReviewTypes

    if exists (select * from dbo.sysobjects where id = object_id(N'MusicReviewsToMusicTypes') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table MusicReviewsToMusicTypes

    if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users

    if exists (select * from dbo.sysobjects where id = object_id(N'Reviews') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Reviews

    if exists (select * from dbo.sysobjects where id = object_id(N'MusicReviews') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table MusicReviews

    if exists (select * from dbo.sysobjects where id = object_id(N'Log') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Log

    if exists (select * from dbo.sysobjects where id = object_id(N'ReviewTypes') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ReviewTypes

    if exists (select * from dbo.sysobjects where id = object_id(N'MusicTypes') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table MusicTypes

    create table UsersToReviewTypes (
        Id INT IDENTITY NOT NULL,
       primary key (Id)
    )

    create table MusicReviewsToMusicTypes (
        Id INT IDENTITY NOT NULL,
       MusicReviewId INT not null,
       MusicTypesId INT not null,
       primary key (Id)
    )

    create table Users (
        Id INT IDENTITY NOT NULL,
       ClaimedIdentifier NVARCHAR(255) null,
       FriendlyIdentifier NVARCHAR(255) null,
       FullName NVARCHAR(255) null,
       Email NVARCHAR(255) null,
       PostalCode NVARCHAR(255) null,
       OpenIdProvider NVARCHAR(255) null,
       OpenIdProviderVersion NVARCHAR(255) null,
       primary key (Id)
    )

    create table Reviews (
        Id INT IDENTITY NOT NULL,
       Body NVARCHAR(MAX) null,
       StandFirst NVARCHAR(2000) null,
       TrailText NVARCHAR(2000) null,
       Title NVARCHAR(255) null,
       PublicationDate DATETIME null,
       StarRating INT null,
       WebUrl NVARCHAR(255) null,
       ReviewTypeId INT null,
       primary key (Id)
    )

    create table MusicReviews (
        ReviewId INT not null,
       primary key (ReviewId)
    )

    create table Log (
        Id INT IDENTITY NOT NULL,
       Context NVARCHAR(512) null,
       Level NVARCHAR(512) null,
       Logger NVARCHAR(512) null,
       Message NVARCHAR(4000) null,
       Exception NVARCHAR(MAX) null,
       Date DATETIME null,
       Thread NVARCHAR(255) null,
       primary key (Id)
    )

    create table ReviewTypes (
        Id INT IDENTITY NOT NULL,
       ShowInUI BIT null,
       Name NVARCHAR(255) null,
       DisplayName NVARCHAR(255) null,
       UserId INT null,
       primary key (Id)
    )

    create table MusicTypes (
        Id INT IDENTITY NOT NULL,
       ShowInUI BIT null,
       Name NVARCHAR(255) null,
       DisplayName NVARCHAR(255) null,
       primary key (Id)
    )

    alter table MusicReviewsToMusicTypes 
        add constraint FK59478D308622E1CB 
        foreign key (MusicTypesId) 
        references MusicTypes

    alter table MusicReviewsToMusicTypes 
        add constraint FK59478D309DF0A8A 
        foreign key (MusicReviewId) 
        references MusicReviews

    alter table Reviews 
        add constraint FK6D28D6529BC62AC 
        foreign key (ReviewTypeId) 
        references ReviewTypes

    alter table MusicReviews 
        add constraint FK5F89AD0F5687A200 
        foreign key (ReviewId) 
        references Reviews

    alter table ReviewTypes 
        add constraint FKB669828AEB69D95 
        foreign key (UserId) 
        references Users
