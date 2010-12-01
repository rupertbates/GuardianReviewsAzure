
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9C01D0F3588B3FCA]') AND parent_object_id = OBJECT_ID('MusicTypes'))
alter table MusicTypes  drop constraint FK9C01D0F3588B3FCA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB669828A588B3FCA]') AND parent_object_id = OBJECT_ID('ReviewTypes'))
alter table ReviewTypes  drop constraint FKB669828A588B3FCA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6D28D6525D538F5D]') AND parent_object_id = OBJECT_ID('Reviews'))
alter table Reviews  drop constraint FK6D28D6525D538F5D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8A74AD0FF86557E7]') AND parent_object_id = OBJECT_ID('MusicReview'))
alter table MusicReview  drop constraint FK8A74AD0FF86557E7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6AAE9FA113FF0418]') AND parent_object_id = OBJECT_ID('MusicReviews_MusicTypes'))
alter table MusicReviews_MusicTypes  drop constraint FK6AAE9FA113FF0418


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6AAE9FA185400AB3]') AND parent_object_id = OBJECT_ID('MusicReviews_MusicTypes'))
alter table MusicReviews_MusicTypes  drop constraint FK6AAE9FA185400AB3


    if exists (select * from dbo.sysobjects where id = object_id(N'Enumerations') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Enumerations

    if exists (select * from dbo.sysobjects where id = object_id(N'MusicTypes') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table MusicTypes

    if exists (select * from dbo.sysobjects where id = object_id(N'ReviewTypes') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ReviewTypes

    if exists (select * from dbo.sysobjects where id = object_id(N'Reviews') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Reviews

    if exists (select * from dbo.sysobjects where id = object_id(N'MusicReview') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table MusicReview

    if exists (select * from dbo.sysobjects where id = object_id(N'MusicReviews_MusicTypes') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table MusicReviews_MusicTypes

    if exists (select * from dbo.sysobjects where id = object_id(N'hibernate_unique_key') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table hibernate_unique_key

    create table Enumerations (
        Id INT not null,	
       DisplayName NVARCHAR(255) null,
       primary key (Id)
    )

    create table MusicTypes (
        EnumerationFk INT not null,
       primary key (EnumerationFk)
    )

    create table ReviewTypes (
        EnumerationFk INT not null,
       primary key (EnumerationFk)
    )

    create table Reviews (
        Id INT not null,
       Body NVARCHAR(MAX) null,
       Title NVARCHAR(255) null,
       PublicationDate DATETIME null,
       StarRating INT null,
       WebUrl NVARCHAR(255) null,
       ReviewTypeFk INT null,
       primary key (Id)
    )

    create table MusicReview (
        ReviewFk INT not null,
       primary key (ReviewFk)
    )

    create table MusicReviews_MusicTypes (
        MusicReviewFk INT not null,
       MusicTypesFk INT not null
    )

    alter table MusicTypes 
        add constraint FK9C01D0F3588B3FCA 
        foreign key (EnumerationFk) 
        references Enumerations

    alter table ReviewTypes 
        add constraint FKB669828A588B3FCA 
        foreign key (EnumerationFk) 
        references Enumerations

    alter table Reviews 
        add constraint FK6D28D6525D538F5D 
        foreign key (ReviewTypeFk) 
        references ReviewTypes

    alter table MusicReview 
        add constraint FK8A74AD0FF86557E7 
        foreign key (ReviewFk) 
        references Reviews

    alter table MusicReviews_MusicTypes 
        add constraint FK6AAE9FA113FF0418 
        foreign key (MusicTypesFk) 
        references MusicTypes

    alter table MusicReviews_MusicTypes 
        add constraint FK6AAE9FA185400AB3 
        foreign key (MusicReviewFk) 
        references MusicReview

    create table hibernate_unique_key (
         next_hi INT 
    )

    insert into hibernate_unique_key values ( 1 )
