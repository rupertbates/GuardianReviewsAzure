
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/26/2010 14:29:30
-- Generated from EDMX file: e:\projects\GuardianReviewsAzure\GuardianReviews.Data\GuardianReviews.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GuardianReviews];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Reviews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reviews];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Reviews'
CREATE TABLE [dbo].[Reviews] (
    [Id] nchar(50)  NOT NULL,
    [Title] nchar(100)  NOT NULL,
    [PublicationDate] datetime  NOT NULL,
    [ReviewType] int  NOT NULL,
    [StarRating] int  NULL,
    [WebUrl] nchar(250)  NULL
);
GO

-- Creating table 'MusicTypes'
CREATE TABLE [dbo].[MusicTypes] (
    [Id] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ReviewMusicType'
CREATE TABLE [dbo].[ReviewMusicType] (
    [Reviews_Id] nchar(50)  NOT NULL,
    [MusicTypes_Id] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [PK_Reviews]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MusicTypes'
ALTER TABLE [dbo].[MusicTypes]
ADD CONSTRAINT [PK_MusicTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Reviews_Id], [MusicTypes_Id] in table 'ReviewMusicType'
ALTER TABLE [dbo].[ReviewMusicType]
ADD CONSTRAINT [PK_ReviewMusicType]
    PRIMARY KEY NONCLUSTERED ([Reviews_Id], [MusicTypes_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Reviews_Id] in table 'ReviewMusicType'
ALTER TABLE [dbo].[ReviewMusicType]
ADD CONSTRAINT [FK_ReviewMusicType_Review]
    FOREIGN KEY ([Reviews_Id])
    REFERENCES [dbo].[Reviews]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MusicTypes_Id] in table 'ReviewMusicType'
ALTER TABLE [dbo].[ReviewMusicType]
ADD CONSTRAINT [FK_ReviewMusicType_MusicType]
    FOREIGN KEY ([MusicTypes_Id])
    REFERENCES [dbo].[MusicTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ReviewMusicType_MusicType'
CREATE INDEX [IX_FK_ReviewMusicType_MusicType]
ON [dbo].[ReviewMusicType]
    ([MusicTypes_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------