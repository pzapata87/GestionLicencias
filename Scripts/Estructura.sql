/****** Object:  Database [GLicenciasBD]    Script Date: 07/06/2015 22:26:15 ******/
CREATE DATABASE [GLicenciasBD]
GO
USE [GLicenciasBD]
GO
/****** Object:  Table [dbo].[Fiscalizacion]    Script Date: 07/06/2015 22:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fiscalizacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaProgramada] [datetime] NOT NULL,
	[Comentario] [nvarchar](500) NULL,
	[FiscalizadorId] [int] NOT NULL,
	[LicenciaId] [int] NOT NULL,
	[Estado] [nvarchar](1) NOT NULL,
	[Observacion] [nvarchar](1000) NULL,
	[Detalle] [nvarchar](1000) NULL,
	[FechaReal] [datetime] NULL,
	[Imagenes] nvarchar(max)  NULL
 CONSTRAINT [PK_Fiscalizacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fiscalizador]    Script Date: 07/06/2015 22:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fiscalizador](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Fiscalizador] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Licencia]    Script Date: 07/06/2015 22:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocalId] [int] NOT NULL,
	[Responsable] [nvarchar](100) NOT NULL,
	[NumLicencia] [nvarchar](max) NOT NULL,
	[FechaLicencia] [datetime] NOT NULL,
	[UriImagen] [nvarchar](100) NULL,
 CONSTRAINT [PK_Licencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Local]    Script Date: 07/06/2015 22:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Local](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Direccion] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Local] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 07/06/2015 22:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RolUsuario]    Script Date: 07/06/2015 22:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolUsuario](
	[UsuarioId] [int] NOT NULL,
	[RolId] [int] NOT NULL,
 CONSTRAINT [PK_RolUsuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC,
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 07/06/2015 22:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_FK_FiscalizadorFiscalizacion]    Script Date: 07/06/2015 22:26:16 ******/
CREATE NONCLUSTERED INDEX [IX_FK_FiscalizadorFiscalizacion] ON [dbo].[Fiscalizacion]
(
	[FiscalizadorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_LicenciaFiscalizacion]    Script Date: 07/06/2015 22:26:16 ******/
CREATE NONCLUSTERED INDEX [IX_FK_LicenciaFiscalizacion] ON [dbo].[Fiscalizacion]
(
	[LicenciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_LocalLicencia]    Script Date: 07/06/2015 22:26:16 ******/
CREATE NONCLUSTERED INDEX [IX_FK_LocalLicencia] ON [dbo].[Licencia]
(
	[LocalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_RolRolUsuario]    Script Date: 07/06/2015 22:26:16 ******/
CREATE NONCLUSTERED INDEX [IX_FK_RolRolUsuario] ON [dbo].[RolUsuario]
(
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Fiscalizacion]  WITH CHECK ADD  CONSTRAINT [FK_FiscalizadorFiscalizacion] FOREIGN KEY([FiscalizadorId])
REFERENCES [dbo].[Fiscalizador] ([Id])
GO
ALTER TABLE [dbo].[Fiscalizacion] CHECK CONSTRAINT [FK_FiscalizadorFiscalizacion]
GO
ALTER TABLE [dbo].[Fiscalizacion]  WITH CHECK ADD  CONSTRAINT [FK_LicenciaFiscalizacion] FOREIGN KEY([LicenciaId])
REFERENCES [dbo].[Licencia] ([Id])
GO
ALTER TABLE [dbo].[Fiscalizacion] CHECK CONSTRAINT [FK_LicenciaFiscalizacion]
GO
ALTER TABLE [dbo].[Licencia]  WITH CHECK ADD  CONSTRAINT [FK_LocalLicencia] FOREIGN KEY([LocalId])
REFERENCES [dbo].[Local] ([Id])
GO
ALTER TABLE [dbo].[Licencia] CHECK CONSTRAINT [FK_LocalLicencia]
GO
ALTER TABLE [dbo].[RolUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolRolUsuario] FOREIGN KEY([RolId])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[RolUsuario] CHECK CONSTRAINT [FK_RolRolUsuario]
GO
ALTER TABLE [dbo].[RolUsuario]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolUsuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[RolUsuario] CHECK CONSTRAINT [FK_UsuarioRolUsuario]
GO
