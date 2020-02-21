
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/19/2020 23:40:48
-- Generated from EDMX file: S:\DEV\Drater\Models\DraterBDD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [drater];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Eleve_Classe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Eleve] DROP CONSTRAINT [FK_Eleve_Classe];
GO
IF OBJECT_ID(N'[dbo].[FK_Retard_Eleve]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Retard] DROP CONSTRAINT [FK_Retard_Eleve];
GO
IF OBJECT_ID(N'[dbo].[FK_Vote_Eleve_Eleve]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vote_Eleve] DROP CONSTRAINT [FK_Vote_Eleve_Eleve];
GO
IF OBJECT_ID(N'[dbo].[FK_Vote_Eleve_Retard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vote_Eleve] DROP CONSTRAINT [FK_Vote_Eleve_Retard];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Classe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Classe];
GO
IF OBJECT_ID(N'[dbo].[Eleve]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Eleve];
GO
IF OBJECT_ID(N'[dbo].[Retard]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Retard];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Vote_Eleve]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vote_Eleve];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Classe'
CREATE TABLE [dbo].[Classe] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [libelle] nvarchar(255)  NOT NULL,
    [promo] datetime  NOT NULL
);
GO

-- Creating table 'Eleve'
CREATE TABLE [dbo].[Eleve] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [pseudo] nvarchar(255)  NOT NULL,
    [mail] nvarchar(255)  NOT NULL,
    [mdp] nvarchar(255)  NOT NULL,
    [idClasse] bigint  NOT NULL,
    [photo_profile] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'Retard'
CREATE TABLE [dbo].[Retard] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [titre] nvarchar(25)  NOT NULL,
    [description] nvarchar(500)  NOT NULL,
    [idEleve] bigint  NOT NULL,
    [pj] nvarchar(500)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Vote_Eleve'
CREATE TABLE [dbo].[Vote_Eleve] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [idEleve] bigint  NOT NULL,
    [idRetard] bigint  NOT NULL,
    [dateVote] datetime  NOT NULL,
    [valeur] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Classe'
ALTER TABLE [dbo].[Classe]
ADD CONSTRAINT [PK_Classe]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Eleve'
ALTER TABLE [dbo].[Eleve]
ADD CONSTRAINT [PK_Eleve]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Retard'
ALTER TABLE [dbo].[Retard]
ADD CONSTRAINT [PK_Retard]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'Vote_Eleve'
ALTER TABLE [dbo].[Vote_Eleve]
ADD CONSTRAINT [PK_Vote_Eleve]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idClasse] in table 'Eleve'
ALTER TABLE [dbo].[Eleve]
ADD CONSTRAINT [FK_Eleve_Classe]
    FOREIGN KEY ([idClasse])
    REFERENCES [dbo].[Classe]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Eleve_Classe'
CREATE INDEX [IX_FK_Eleve_Classe]
ON [dbo].[Eleve]
    ([idClasse]);
GO

-- Creating foreign key on [idEleve] in table 'Retard'
ALTER TABLE [dbo].[Retard]
ADD CONSTRAINT [FK_Retard_Eleve]
    FOREIGN KEY ([idEleve])
    REFERENCES [dbo].[Eleve]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Retard_Eleve'
CREATE INDEX [IX_FK_Retard_Eleve]
ON [dbo].[Retard]
    ([idEleve]);
GO

-- Creating foreign key on [idEleve] in table 'Vote_Eleve'
ALTER TABLE [dbo].[Vote_Eleve]
ADD CONSTRAINT [FK_Vote_Eleve_Eleve]
    FOREIGN KEY ([idEleve])
    REFERENCES [dbo].[Eleve]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vote_Eleve_Eleve'
CREATE INDEX [IX_FK_Vote_Eleve_Eleve]
ON [dbo].[Vote_Eleve]
    ([idEleve]);
GO

-- Creating foreign key on [idRetard] in table 'Vote_Eleve'
ALTER TABLE [dbo].[Vote_Eleve]
ADD CONSTRAINT [FK_Vote_Eleve_Retard]
    FOREIGN KEY ([idRetard])
    REFERENCES [dbo].[Retard]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vote_Eleve_Retard'
CREATE INDEX [IX_FK_Vote_Eleve_Retard]
ON [dbo].[Vote_Eleve]
    ([idRetard]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------