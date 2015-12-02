USE [GLicenciasBD]

GO

/***[Giro]***/
SET IDENTITY_INSERT [dbo].[Giro] ON 
GO
INSERT [dbo].[Giro] ([Id], [Descripcion], [FechaRegistro]) VALUES (1, N'GIRO 1', GETDATE())
GO
INSERT [dbo].[Giro] ([Id], [Descripcion], [FechaRegistro]) VALUES (2, N'GIRO 2', GETDATE())
GO
SET IDENTITY_INSERT [dbo].[Giro] OFF
GO

/***[Administrado]***/
SET IDENTITY_INSERT [dbo].[Administrado] ON 
GO
INSERT [dbo].[Administrado] ([Id], [NDocumento], [Nombres], [Telefono]) VALUES (1, N'12345678', N'Administrado 1', N'123456789')
GO
INSERT [dbo].[Administrado] ([Id], [NDocumento], [Nombres], [Telefono]) VALUES (2, N'87654321', N'Administrado 2', N'987654321')
GO
SET IDENTITY_INSERT [dbo].[Administrado] OFF
GO

/***[Criterio]***/
SET IDENTITY_INSERT [dbo].[Criterio] ON 
GO
INSERT [dbo].[Criterio] ([Id], [Descripcion], [FechaRegistro]) VALUES (1, N'CRITERIO 1', GETDATE())
GO
INSERT [dbo].[Criterio] ([Id], [Descripcion], [FechaRegistro]) VALUES (2, N'CRITERIO 2', GETDATE())
GO
SET IDENTITY_INSERT [dbo].[Criterio] OFF
GO

/***[Requisito]***/
SET IDENTITY_INSERT [dbo].[Requisito] ON 
GO
INSERT [dbo].[Requisito] ([Id], [Valor], [CriterioId], [GiroId], [FechaRegistro]) VALUES (1, N'REQUISITO 1', 1, 1, GETDATE())
GO
INSERT [dbo].[Requisito] ([Id], [Valor], [CriterioId], [GiroId], [FechaRegistro]) VALUES (2, N'REQUISITO 2', 1, 1, GETDATE())
GO
SET IDENTITY_INSERT [dbo].[Requisito] OFF
GO

/***[Licencia]***/
SET IDENTITY_INSERT [dbo].[Licencia] ON 

GO
INSERT [dbo].[Licencia] ([Id], [Direccion], [Responsable], [NumLicencia], [FechaLicencia], [GiroId], [UriImagen]) VALUES (1, N'Direccion 01', N'1', N'0001', CAST(0x0000A4B000000000 AS DateTime), 1, 'licencia001.jpg')
GO
INSERT [dbo].[Licencia] ([Id], [Direccion], [Responsable], [NumLicencia], [FechaLicencia], [GiroId], [UriImagen]) VALUES (2, N'Direccion 02', N'2', N'0002', CAST(0x0000A4B000000000 AS DateTime), 1, 'licencia001.jpg')
GO
SET IDENTITY_INSERT [dbo].[Licencia] OFF
GO

/***[Fiscalizador]***/
SET IDENTITY_INSERT [dbo].[Fiscalizador] ON 

GO
INSERT [dbo].[Fiscalizador] ([Id], [Nombre], [Apellido]) VALUES (1, N'FISCALIZADOR 1', N'FISCALIZADOR 1')
GO
INSERT [dbo].[Fiscalizador] ([Id], [Nombre], [Apellido]) VALUES (2, N'FISCALIZADOR 2', N'FISCALIZADOR 2')
GO
SET IDENTITY_INSERT [dbo].[Fiscalizador] OFF
GO
