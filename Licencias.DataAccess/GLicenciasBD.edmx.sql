
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/07/2015 20:46:39
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
IF OBJECT_ID(N'[dbo].[FK_LocalLicencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Licencia] DROP CONSTRAINT [FK_LocalLicencia];
GO
IF OBJECT_ID(N'[dbo].[FK_FiscalizadorFiscalizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fiscalizacion] DROP CONSTRAINT [FK_FiscalizadorFiscalizacion];
GO
IF OBJECT_ID(N'[dbo].[FK_LicenciaFiscalizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fiscalizacion] DROP CONSTRAINT [FK_LicenciaFiscalizacion];
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
IF OBJECT_ID(N'[dbo].[Fiscalizacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fiscalizacion];
GO
IF OBJECT_ID(N'[dbo].[Local]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Local];
GO
IF OBJECT_ID(N'[dbo].[Licencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Licencia];
GO
IF OBJECT_ID(N'[dbo].[Fiscalizador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fiscalizador];
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

-- Creating table 'Fiscalizacion'
CREATE TABLE [dbo].[Fiscalizacion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FechaProgramada] datetime  NOT NULL,
    [Comentario] nvarchar(500)  NULL,
    [FiscalizadorId] int  NOT NULL,
    [LicenciaId] int  NOT NULL,
    [Estado] nvarchar(1)  NOT NULL,
    [Observacion] nvarchar(1000)  NULL,
    [Detalle] nvarchar(1000)  NULL,
    [FechaReal] datetime  NULL
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
    [FechaLicencia] datetime  NOT NULL,
    [UriImagen] nvarchar(100)  NULL
);
GO

-- Creating table 'Fiscalizador'
CREATE TABLE [dbo].[Fiscalizador] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Apellido] nvarchar(50)  NOT NULL
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

-- Creating primary key on [Id] in table 'Fiscalizacion'
ALTER TABLE [dbo].[Fiscalizacion]
ADD CONSTRAINT [PK_Fiscalizacion]
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

-- Creating primary key on [Id] in table 'Fiscalizador'
ALTER TABLE [dbo].[Fiscalizador]
ADD CONSTRAINT [PK_Fiscalizador]
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

-- Creating foreign key on [FiscalizadorId] in table 'Fiscalizacion'
ALTER TABLE [dbo].[Fiscalizacion]
ADD CONSTRAINT [FK_FiscalizadorFiscalizacion]
    FOREIGN KEY ([FiscalizadorId])
    REFERENCES [dbo].[Fiscalizador]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FiscalizadorFiscalizacion'
CREATE INDEX [IX_FK_FiscalizadorFiscalizacion]
ON [dbo].[Fiscalizacion]
    ([FiscalizadorId]);
GO

-- Creating foreign key on [LicenciaId] in table 'Fiscalizacion'
ALTER TABLE [dbo].[Fiscalizacion]
ADD CONSTRAINT [FK_LicenciaFiscalizacion]
    FOREIGN KEY ([LicenciaId])
    REFERENCES [dbo].[Licencia]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LicenciaFiscalizacion'
CREATE INDEX [IX_FK_LicenciaFiscalizacion]
ON [dbo].[Fiscalizacion]
    ([LicenciaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------