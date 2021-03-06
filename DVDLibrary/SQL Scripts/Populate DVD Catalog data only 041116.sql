USE [DVD]
GO
SET IDENTITY_INSERT [dbo].[DVDCatalog] ON 

GO
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (12, 1, 2, N'Frozen', CAST(N'2013-11-19' AS Date), N'PG', NULL)
GO
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (13, 2, 2, N'Pirates of the Caribbean 1', CAST(N'2003-06-28' AS Date), N'PG-13', NULL)
GO
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (14, 2, 2, N'Pirates of the Caribbean 2', CAST(N'2006-07-07' AS Date), N'PG-13', NULL)
GO
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (15, 2, 2, N'Pirates of the Caribbean 3', CAST(N'2007-05-25' AS Date), N'PG-13', NULL)
GO
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (16, 3, 3, N'The Matrix', CAST(N'1999-03-31' AS Date), N'R', NULL)
GO
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (17, 4, 1, N'Jurassic Park', CAST(N'1993-06-11' AS Date), N'PG-13', NULL)
GO
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (18, 5, 6, N'Titanic', CAST(N'1997-12-19' AS Date), N'PG-13', NULL)
GO
SET IDENTITY_INSERT [dbo].[DVDCatalog] OFF
GO
