USE [DVD]
GO
/****** Object:  Table [dbo].[DvdCatalog]    Script Date: 4/12/2016 3:10:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DvdCatalog](
	[DvdID] [int] IDENTITY(1,1) NOT NULL,
	[DirectorID] [int] NOT NULL,
	[StudioID] [int] NOT NULL,
	[DvdTitle] [varchar](50) NOT NULL,
	[ReleaseDate] [date] NOT NULL,
	[MPAARating] [varchar](50) NOT NULL,
	[BorrowerComments] [varchar](300) NULL,
 CONSTRAINT [PK_DVDCatalog] PRIMARY KEY CLUSTERED 
(
	[DvdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DvdCatalog] ON 

INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments]) VALUES (12, 1, 2, N'Frozen', CAST(N'2013-11-19' AS Date), N'2', N'Yo, dis movie ain''t no good.')
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments]) VALUES (13, 2, 2, N'Pirates of the Caribbean 1', CAST(N'2003-06-28' AS Date), N'3', NULL)
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments]) VALUES (14, 2, 2, N'Pirates of the Caribbean 2', CAST(N'2006-07-07' AS Date), N'3', NULL)
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments]) VALUES (15, 2, 2, N'Pirates of the Caribbean 3', CAST(N'2007-05-25' AS Date), N'3', N'Movie was too cute.')
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments]) VALUES (16, 3, 3, N'The Matrix', CAST(N'1999-03-31' AS Date), N'4', N'Spoiler: Harry dies!')
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments]) VALUES (17, 4, 1, N'Jurassic Park', CAST(N'1993-06-11' AS Date), N'3', N'Movie was hilarious!')
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments]) VALUES (18, 5, 6, N'Titanic', CAST(N'1997-12-19' AS Date), N'PG-13', N'Wasn''t even that scary.')
SET IDENTITY_INSERT [dbo].[DvdCatalog] OFF
ALTER TABLE [dbo].[DvdCatalog]  WITH CHECK ADD  CONSTRAINT [FK_DVDCatalog_Director] FOREIGN KEY([DirectorID])
REFERENCES [dbo].[Director] ([DirectorID])
GO
ALTER TABLE [dbo].[DvdCatalog] CHECK CONSTRAINT [FK_DVDCatalog_Director]
GO
ALTER TABLE [dbo].[DvdCatalog]  WITH CHECK ADD  CONSTRAINT [FK_DVDCatalog_Studio] FOREIGN KEY([StudioID])
REFERENCES [dbo].[Studio] ([StudioID])
GO
ALTER TABLE [dbo].[DvdCatalog] CHECK CONSTRAINT [FK_DVDCatalog_Studio]
GO
