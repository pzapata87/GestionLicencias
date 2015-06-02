
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2015 08:05:04
-- Generated from EDMX file: D:\Proyectos\Academico - Servicio Web\GestionLicencias\GestionLicencias\Licencias.DataAccess\GLicenciasBD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GLicenciasBD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsuarioRolUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolUsuario] DROP CONSTRAINT [FK_UsuarioRolUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_RolRolUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolUsuario] DROP CONSTRAINT [FK_RolRolUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioCronogramaFiscalizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CronogramaFiscalizacions] DROP CONSTRAINT [FK_UsuarioCronogramaFiscalizacion];
GO
IF OBJECT_ID(N'[dbo].[FK_LocalLicencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Licencias] DROP CONSTRAINT [FK_LocalLicencia];
GO
IF OBJECT_ID(N'[dbo].[FK_LicenciaCronogramaFiscalizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CronogramaFiscalizacions] DROP CONSTRAINT [FK_LicenciaCronogramaFiscalizacion];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[Rol]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rol];
GO
IF OBJECT_ID(N'[dbo].[RolUsuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RolUsuario];
GO
IF OBJECT_ID(N'[dbo].[CronogramaFiscalizacions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CronogramaFiscalizacions];
GO
IF OBJECT_ID(N'[dbo].[Locals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Locals];
GO
IF OBJECT_ID(N'[dbo].[Licencias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Licencias];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(20)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Rol'
CREATE TABLE [dbo].[Rol] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'RolUsuario'
CREATE TABLE [dbo].[RolUsuario] (
    [UsuarioId] int  NOT NULL,
    [RolId] int  NOT NULL
);
GO

-- Creating table 'CronogramaFiscalizacion'
CREATE TABLE [dbo].[CronogramaFiscalizacion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FechaFiscalizacion] datetime  NOT NULL,
    [Fiscalizador] nvarchar(max)  NOT NULL,
    [UsuarioId] int  NOT NULL,
    [Comentario] nvarchar(500)  NULL,
    [LicenciaId] int  NOT NULL
);
GO

-- Creating table 'Local'
CREATE TABLE [dbo].[Local] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Direccion] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Licencia'
CREATE TABLE [dbo].[Licencia] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LocalId] int  NOT NULL,
    [Responsable] nvarchar(100)  NOT NULL,
    [NumLicencia] nvarchar(max)  NOT NULL,
    [FechaLicencia] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rol'
ALTER TABLE [dbo].[Rol]
ADD CONSTRAINT [PK_Rol]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UsuarioId], [RolId] in table 'RolUsuario'
ALTER TABLE [dbo].[RolUsuario]
ADD CONSTRAINT [PK_RolUsuario]
    PRIMARY KEY CLUSTERED ([UsuarioId], [RolId] ASC);
GO

-- Creating primary key on [Id] in table 'CronogramaFiscalizacion'
ALTER TABLE [dbo].[CronogramaFiscalizacion]
ADD CONSTRAINT [PK_CronogramaFiscalizacion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Local'
ALTER TABLE [dbo].[Local]
ADD CONSTRAINT [PK_Local]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Licencia'
ALTER TABLE [dbo].[Licencia]
ADD CONSTRAINT [PK_Licencia]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UsuarioId] in table 'RolUsuario'
ALTER TABLE [dbo].[RolUsuario]
ADD CONSTRAINT [FK_UsuarioRolUsuario]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuario]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RolId] in table 'RolUsuario'
ALTER TABLE [dbo].[RolUsuario]
ADD CONSTRAINT [FK_RolRolUsuario]
    FOREIGN KEY ([RolId])
    REFERENCES [dbo].[Rol]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolRolUsuario'
CREATE INDEX [IX_FK_RolRolUsuario]
ON [dbo].[RolUsuario]
    ([RolId]);
GO

-- Creating foreign key on [UsuarioId] in table 'CronogramaFiscalizacion'
ALTER TABLE [dbo].[CronogramaFiscalizacion]
ADD CONSTRAINT [FK_UsuarioCronogramaFiscalizacion]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuario]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioCronogramaFiscalizacion'
CREATE INDEX [IX_FK_UsuarioCronogramaFiscalizacion]
ON [dbo].[CronogramaFiscalizacion]
    ([UsuarioId]);
GO

-- Creating foreign key on [LocalId] in table 'Licencia'
ALTER TABLE [dbo].[Licencia]
ADD CONSTRAINT [FK_LocalLicencia]
    FOREIGN KEY ([LocalId])
    REFERENCES [dbo].[Local]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocalLicencia'
CREATE INDEX [IX_FK_LocalLicencia]
ON [dbo].[Licencia]
    ([LocalId]);
GO

-- Creating foreign key on [LicenciaId] in table 'CronogramaFiscalizacion'
ALTER TABLE [dbo].[CronogramaFiscalizacion]
ADD CONSTRAINT [FK_LicenciaCronogramaFiscalizacion]
    FOREIGN KEY ([LicenciaId])
    REFERENCES [dbo].[Licencia]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LicenciaCronogramaFiscalizacion'
CREATE INDEX [IX_FK_LicenciaCronogramaFiscalizacion]
ON [dbo].[CronogramaFiscalizacion]
    ([LicenciaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------