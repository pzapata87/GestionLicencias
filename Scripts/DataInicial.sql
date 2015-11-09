USE [GLicenciasBD]

GO
/***[Local]***/
SET IDENTITY_INSERT [dbo].[Local] ON 

GO
INSERT [dbo].[Local] ([Id], [Direccion]) VALUES (1, N'LOCAL 1')
GO
INSERT [dbo].[Local] ([Id], [Direccion]) VALUES (2, N'LOCAL 2')
GO
SET IDENTITY_INSERT [dbo].[Local] OFF
GO

/***[Local]***/
SET IDENTITY_INSERT [dbo].[Giro] ON 
GO
INSERT [dbo].[Giro] ([Id], [Descripcion], [FechaRegistro]) VALUES (1, N'GIRO 1', GETDATE())
GO
INSERT [dbo].[Giro] ([Id], [Descripcion], [FechaRegistro]) VALUES (2, N'GIRO 2', GETDATE())
GO
SET IDENTITY_INSERT [dbo].[Giro] OFF
GO

/***[Licencia]***/
SET IDENTITY_INSERT [dbo].[Licencia] ON 

GO
INSERT [dbo].[Licencia] ([Id], [LocalId], [Responsable], [NumLicencia], [FechaLicencia], [GiroId]) VALUES (1, 1, N'1', N'0001', CAST(0x0000A4B000000000 AS DateTime), 1)
GO
INSERT [dbo].[Licencia] ([Id], [LocalId], [Responsable], [NumLicencia], [FechaLicencia], [GiroId]) VALUES (2, 2, N'2', N'0002', CAST(0x0000A4B000000000 AS DateTime), 1)
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
