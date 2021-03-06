USE [DVD]
GO
/****** Object:  Table [dbo].[Director]    Script Date: 4/7/2016 7:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Director](
	[DirectorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Director] PRIMARY KEY CLUSTERED 
(
	[DirectorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DVDCatalog]    Script Date: 4/7/2016 7:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DVDCatalog](
	[DvdID] [int] IDENTITY(1,1) NOT NULL,
	[DirectorID] [int] NOT NULL,
	[StudioID] [int] NOT NULL,
	[DvdTitle] [varchar](50) NOT NULL,
	[ReleaseDate] [date] NOT NULL,
	[MPAARating] [varchar](50) NOT NULL,
	[UserComments] [varchar](300) NULL,
 CONSTRAINT [PK_DVDCatalog] PRIMARY KEY CLUSTERED 
(
	[DvdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Director] ON 

INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (1, N'Jennifer', N'Lee')
INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (2, N'Gore', N'Verbinski')
INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (3, N'Wachowski', N'Bros.')
INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (4, N'Steven', N'Spielberg')
INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (5, N'James', N'Cameron')
SET IDENTITY_INSERT [dbo].[Director] OFF
SET IDENTITY_INSERT [dbo].[DVDCatalog] ON 

INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (1, 1, 2, N'Frozen', CAST(N'2013-11-19' AS Date), N'PG', NULL)
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (5, 2, 2, N'Pirates of the Caribbean 1', CAST(N'2003-06-28' AS Date), N'PG-13', NULL)
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (7, 2, 2, N'Pirates of the Caribbean 2', CAST(N'2006-07-07' AS Date), N'PG-13', NULL)
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (8, 2, 2, N'Pirates of the Caribbean 3', CAST(N'2007-05-25' AS Date), N'PG-13', NULL)
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (9, 3, 3, N'The Matrix', CAST(N'1999-03-31' AS Date), N'R', NULL)
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (10, 4, 1, N'Jurassic Park', CAST(N'1993-06-11' AS Date), N'PG-13', NULL)
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (11, 5, 6, N'Titanic', CAST(N'1997-12-19' AS Date), N'PG-13', NULL)
SET IDENTITY_INSERT [dbo].[DVDCatalog] OFF
