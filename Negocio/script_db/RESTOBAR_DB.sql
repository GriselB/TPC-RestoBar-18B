USE [RESTOBAR_DB]
GO
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 5/6/2026 01:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INSUMOS]    Script Date: 5/6/2026 01:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INSUMOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MESAS]    Script Date: 5/6/2026 01:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MESAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MESAS] ON 
GO
INSERT [dbo].[MESAS] ([Id], [Numero], [Descripcion], [Activo]) VALUES (1, 1, N'Mesa del fondo', 1)
GO
INSERT [dbo].[MESAS] ([Id], [Numero], [Descripcion], [Activo]) VALUES (2, 2, N'Mesa terraza', 1)
GO
INSERT [dbo].[MESAS] ([Id], [Numero], [Descripcion], [Activo]) VALUES (3, 3, N'Mesa ventana', 1)
GO
INSERT [dbo].[MESAS] ([Id], [Numero], [Descripcion], [Activo]) VALUES (4, 4, N'Mesa bar', 1)
GO
INSERT [dbo].[MESAS] ([Id], [Numero], [Descripcion], [Activo]) VALUES (5, 5, N'Mesa salon', 1)
GO
INSERT [dbo].[MESAS] ([Id], [Numero], [Descripcion], [Activo]) VALUES (6, 6, N'Mesa entrada', 1)
GO
SET IDENTITY_INSERT [dbo].[MESAS] OFF
GO
ALTER TABLE [dbo].[INSUMOS] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[MESAS] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[INSUMOS]  WITH CHECK ADD  CONSTRAINT [FK_INSUMOS_CATEGORIAS] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[CATEGORIAS] ([Id])
GO
ALTER TABLE [dbo].[INSUMOS] CHECK CONSTRAINT [FK_INSUMOS_CATEGORIAS]
GO
