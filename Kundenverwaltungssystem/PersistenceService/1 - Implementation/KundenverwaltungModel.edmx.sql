
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/03/2016 13:14:26
-- Generated from EDMX file: D:\Uni\Bachelor\7. Semester (BA)\Implementation\Entity Framework\Kundenverwaltungssystem\PersistenceService\1 - Implementation\KundenverwaltungModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KundenverwaltungEFDesigner];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AngelegtVon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kunden] DROP CONSTRAINT [FK_AngelegtVon];
GO
IF OBJECT_ID(N'[dbo].[FK_KursKunde_Kunde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KursKunde] DROP CONSTRAINT [FK_KursKunde_Kunde];
GO
IF OBJECT_ID(N'[dbo].[FK_KursKunde_Kurs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KursKunde] DROP CONSTRAINT [FK_KursKunde_Kurs];
GO
IF OBJECT_ID(N'[dbo].[FK_KursRechnungsposition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rechnungspositionen] DROP CONSTRAINT [FK_KursRechnungsposition];
GO
IF OBJECT_ID(N'[dbo].[FK_KursRezeptionist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kurse] DROP CONSTRAINT [FK_KursRezeptionist];
GO
IF OBJECT_ID(N'[dbo].[FK_RechnungKunde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rechnungen] DROP CONSTRAINT [FK_RechnungKunde];
GO
IF OBJECT_ID(N'[dbo].[FK_RechnungRechnungsposition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rechnungspositionen] DROP CONSTRAINT [FK_RechnungRechnungsposition];
GO
IF OBJECT_ID(N'[dbo].[FK_Rezeptionist_inherits_Mitarbeiter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mitarbeiter_Rezeptionist] DROP CONSTRAINT [FK_Rezeptionist_inherits_Mitarbeiter];
GO
IF OBJECT_ID(N'[dbo].[FK_Trainer_inherits_Mitarbeiter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mitarbeiter_Trainer] DROP CONSTRAINT [FK_Trainer_inherits_Mitarbeiter];
GO
IF OBJECT_ID(N'[dbo].[FK_TrainerKurs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kurse] DROP CONSTRAINT [FK_TrainerKurs];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Kunden]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kunden];
GO
IF OBJECT_ID(N'[dbo].[Kurse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kurse];
GO
IF OBJECT_ID(N'[dbo].[KursKunde]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KursKunde];
GO
IF OBJECT_ID(N'[dbo].[Mitarbeiter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mitarbeiter];
GO
IF OBJECT_ID(N'[dbo].[Mitarbeiter_Rezeptionist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mitarbeiter_Rezeptionist];
GO
IF OBJECT_ID(N'[dbo].[Mitarbeiter_Trainer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mitarbeiter_Trainer];
GO
IF OBJECT_ID(N'[dbo].[Rechnungen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rechnungen];
GO
IF OBJECT_ID(N'[dbo].[Rechnungspositionen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rechnungspositionen];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Kunden'
CREATE TABLE [dbo].[Kunden] (
    [Kundennummer] int IDENTITY(1,1) NOT NULL,
    [Vorname] nvarchar(max)  NOT NULL,
    [Nachname] nvarchar(max)  NOT NULL,
    [Telefonnummer] nvarchar(max)  NOT NULL,
    [Adresse_Strasse] nvarchar(max)  NOT NULL,
    [Adresse_Hausnummer] nvarchar(max)  NOT NULL,
    [Adresse_PLZ] nvarchar(max)  NOT NULL,
    [Adresse_Ort] nvarchar(max)  NOT NULL,
    [EmailAdresse_Email] nvarchar(max)  NOT NULL,
    [Geburtsdatum] datetime  NOT NULL,
    [Kundenstatus] int  NOT NULL,
    [AngelegtVon_ID] int  NOT NULL
);
GO

-- Creating table 'Mitarbeiter'
CREATE TABLE [dbo].[Mitarbeiter] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Vorname] nvarchar(max)  NOT NULL,
    [Nachname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Rechnungen'
CREATE TABLE [dbo].[Rechnungen] (
    [Rechnungsnummer] int IDENTITY(1,1) NOT NULL,
    [Bezahlt] bit  NOT NULL,
    [AbrechnungsZeitraum_Monat] int  NOT NULL,
    [AbrechnungsZeitraum_Jahr] int  NOT NULL,
    [Kunde_Kundennummer] int  NOT NULL
);
GO

-- Creating table 'Rechnungspositionen'
CREATE TABLE [dbo].[Rechnungspositionen] (
    [Rechnungspositionsnummer] int IDENTITY(1,1) NOT NULL,
    [Kosten] decimal(18,0)  NOT NULL,
    [KursId] int  NOT NULL,
    [RechnungRechnungsposition_Rechnungsposition_Rechnungsnummer] int  NOT NULL
);
GO

-- Creating table 'Kurse'
CREATE TABLE [dbo].[Kurse] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Titel] nvarchar(max)  NOT NULL,
    [Beschreibung] nvarchar(max)  NOT NULL,
    [MaximaleTeilnehmeranzahl] int  NOT NULL,
    [Kursstatus] int  NOT NULL,
    [Veranstaltungszeit_StartZeitpunkt] datetime  NOT NULL,
    [Veranstaltungszeit_EndZeitpunkt] datetime  NOT NULL,
    [Kursleiter_ID] int  NOT NULL,
    [AngelegtVon_ID] int  NOT NULL
);
GO

-- Creating table 'Mitarbeiter_Rezeptionist'
CREATE TABLE [dbo].[Mitarbeiter_Rezeptionist] (
    [ID] int  NOT NULL
);
GO

-- Creating table 'Mitarbeiter_Trainer'
CREATE TABLE [dbo].[Mitarbeiter_Trainer] (
    [ID] int  NOT NULL
);
GO

-- Creating table 'KursKunde'
CREATE TABLE [dbo].[KursKunde] (
    [KursKunde_Kunde_ID] int  NOT NULL,
    [Teilnehmer_Kundennummer] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Kundennummer] in table 'Kunden'
ALTER TABLE [dbo].[Kunden]
ADD CONSTRAINT [PK_Kunden]
    PRIMARY KEY CLUSTERED ([Kundennummer] ASC);
GO

-- Creating primary key on [ID] in table 'Mitarbeiter'
ALTER TABLE [dbo].[Mitarbeiter]
ADD CONSTRAINT [PK_Mitarbeiter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Rechnungsnummer] in table 'Rechnungen'
ALTER TABLE [dbo].[Rechnungen]
ADD CONSTRAINT [PK_Rechnungen]
    PRIMARY KEY CLUSTERED ([Rechnungsnummer] ASC);
GO

-- Creating primary key on [Rechnungspositionsnummer] in table 'Rechnungspositionen'
ALTER TABLE [dbo].[Rechnungspositionen]
ADD CONSTRAINT [PK_Rechnungspositionen]
    PRIMARY KEY CLUSTERED ([Rechnungspositionsnummer] ASC);
GO

-- Creating primary key on [ID] in table 'Kurse'
ALTER TABLE [dbo].[Kurse]
ADD CONSTRAINT [PK_Kurse]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Mitarbeiter_Rezeptionist'
ALTER TABLE [dbo].[Mitarbeiter_Rezeptionist]
ADD CONSTRAINT [PK_Mitarbeiter_Rezeptionist]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Mitarbeiter_Trainer'
ALTER TABLE [dbo].[Mitarbeiter_Trainer]
ADD CONSTRAINT [PK_Mitarbeiter_Trainer]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [KursKunde_Kunde_ID], [Teilnehmer_Kundennummer] in table 'KursKunde'
ALTER TABLE [dbo].[KursKunde]
ADD CONSTRAINT [PK_KursKunde]
    PRIMARY KEY CLUSTERED ([KursKunde_Kunde_ID], [Teilnehmer_Kundennummer] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AngelegtVon_ID] in table 'Kunden'
ALTER TABLE [dbo].[Kunden]
ADD CONSTRAINT [FK_AngelegtVon]
    FOREIGN KEY ([AngelegtVon_ID])
    REFERENCES [dbo].[Mitarbeiter_Rezeptionist]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AngelegtVon'
CREATE INDEX [IX_FK_AngelegtVon]
ON [dbo].[Kunden]
    ([AngelegtVon_ID]);
GO

-- Creating foreign key on [RechnungRechnungsposition_Rechnungsposition_Rechnungsnummer] in table 'Rechnungspositionen'
ALTER TABLE [dbo].[Rechnungspositionen]
ADD CONSTRAINT [FK_RechnungRechnungsposition]
    FOREIGN KEY ([RechnungRechnungsposition_Rechnungsposition_Rechnungsnummer])
    REFERENCES [dbo].[Rechnungen]
        ([Rechnungsnummer])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RechnungRechnungsposition'
CREATE INDEX [IX_FK_RechnungRechnungsposition]
ON [dbo].[Rechnungspositionen]
    ([RechnungRechnungsposition_Rechnungsposition_Rechnungsnummer]);
GO

-- Creating foreign key on [Kunde_Kundennummer] in table 'Rechnungen'
ALTER TABLE [dbo].[Rechnungen]
ADD CONSTRAINT [FK_RechnungKunde]
    FOREIGN KEY ([Kunde_Kundennummer])
    REFERENCES [dbo].[Kunden]
        ([Kundennummer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RechnungKunde'
CREATE INDEX [IX_FK_RechnungKunde]
ON [dbo].[Rechnungen]
    ([Kunde_Kundennummer]);
GO

-- Creating foreign key on [Kursleiter_ID] in table 'Kurse'
ALTER TABLE [dbo].[Kurse]
ADD CONSTRAINT [FK_TrainerKurs]
    FOREIGN KEY ([Kursleiter_ID])
    REFERENCES [dbo].[Mitarbeiter_Trainer]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrainerKurs'
CREATE INDEX [IX_FK_TrainerKurs]
ON [dbo].[Kurse]
    ([Kursleiter_ID]);
GO

-- Creating foreign key on [KursKunde_Kunde_ID] in table 'KursKunde'
ALTER TABLE [dbo].[KursKunde]
ADD CONSTRAINT [FK_KursKunde_Kurs]
    FOREIGN KEY ([KursKunde_Kunde_ID])
    REFERENCES [dbo].[Kurse]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Teilnehmer_Kundennummer] in table 'KursKunde'
ALTER TABLE [dbo].[KursKunde]
ADD CONSTRAINT [FK_KursKunde_Kunde]
    FOREIGN KEY ([Teilnehmer_Kundennummer])
    REFERENCES [dbo].[Kunden]
        ([Kundennummer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KursKunde_Kunde'
CREATE INDEX [IX_FK_KursKunde_Kunde]
ON [dbo].[KursKunde]
    ([Teilnehmer_Kundennummer]);
GO

-- Creating foreign key on [KursId] in table 'Rechnungspositionen'
ALTER TABLE [dbo].[Rechnungspositionen]
ADD CONSTRAINT [FK_KursRechnungsposition]
    FOREIGN KEY ([KursId])
    REFERENCES [dbo].[Kurse]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KursRechnungsposition'
CREATE INDEX [IX_FK_KursRechnungsposition]
ON [dbo].[Rechnungspositionen]
    ([KursId]);
GO

-- Creating foreign key on [AngelegtVon_ID] in table 'Kurse'
ALTER TABLE [dbo].[Kurse]
ADD CONSTRAINT [FK_KursRezeptionist]
    FOREIGN KEY ([AngelegtVon_ID])
    REFERENCES [dbo].[Mitarbeiter_Rezeptionist]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KursRezeptionist'
CREATE INDEX [IX_FK_KursRezeptionist]
ON [dbo].[Kurse]
    ([AngelegtVon_ID]);
GO

-- Creating foreign key on [ID] in table 'Mitarbeiter_Rezeptionist'
ALTER TABLE [dbo].[Mitarbeiter_Rezeptionist]
ADD CONSTRAINT [FK_Rezeptionist_inherits_Mitarbeiter]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Mitarbeiter]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Mitarbeiter_Trainer'
ALTER TABLE [dbo].[Mitarbeiter_Trainer]
ADD CONSTRAINT [FK_Trainer_inherits_Mitarbeiter]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Mitarbeiter]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------