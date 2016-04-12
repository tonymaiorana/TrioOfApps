USE [DVD]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 4/12/2016 9:57:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Actor](
	[ActorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Actor] PRIMARY KEY CLUSTERED 
(
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Borrower]    Script Date: 4/12/2016 9:57:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Borrower](
	[BorrowerID] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_BorrowerName] PRIMARY KEY CLUSTERED 
(
	[BorrowerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BorrowInfo]    Script Date: 4/12/2016 9:57:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BorrowInfo](
	[BorrowInfoID] [int] IDENTITY(1,1) NOT NULL,
	[DvdID] [int] NOT NULL,
	[BorrowerID] [int] NOT NULL,
	[DateBorrowed] [date] NOT NULL,
	[DateReturned] [date] NULL,
	[BorrowerComments] [varchar](500) NULL,
	[BorrowerRating] [decimal](2, 1) NULL,
 CONSTRAINT [PK_BorrowerInfo] PRIMARY KEY CLUSTERED 
(
	[BorrowInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Director]    Script Date: 4/12/2016 9:57:37 AM ******/
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
/****** Object:  Table [dbo].[DvdActor]    Script Date: 4/12/2016 9:57:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DvdActor](
	[ActorID] [int] NOT NULL,
	[DvdID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DvdCatalog]    Script Date: 4/12/2016 9:57:37 AM ******/
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
	[AverageRating] [decimal](2, 1) NULL,
 CONSTRAINT [PK_DVDCatalog] PRIMARY KEY CLUSTERED 
(
	[DvdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Studio]    Script Date: 4/12/2016 9:57:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Studio](
	[StudioID] [int] IDENTITY(1,1) NOT NULL,
	[StudioName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Studio] PRIMARY KEY CLUSTERED 
(
	[StudioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Actor] ON 

INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (1, N'Johnny', N'Depp')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (2, N'Keanu', N'Reeves')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (3, N'Leonardo', N'DiCaprio')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (4, N'Kate', N'Winslet')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (5, N'Laurence', N'Fishburne')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (6, N'Jeff', N'Goldblum')
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (7, N'Sam', N'Neill')
SET IDENTITY_INSERT [dbo].[Actor] OFF
INSERT [dbo].[Borrower] ([BorrowerID], [FirstName], [LastName], [PhoneNumber], [IsActive]) VALUES (1, N'Rocco', N'Riccardi', N'555-555-5555', 1)
INSERT [dbo].[Borrower] ([BorrowerID], [FirstName], [LastName], [PhoneNumber], [IsActive]) VALUES (2, N'Jeane', N'Hong', N'333-333-3333', 1)
SET IDENTITY_INSERT [dbo].[BorrowInfo] ON 

INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerComments], [BorrowerRating]) VALUES (2, 14, 2, CAST(N'2016-04-12' AS Date), NULL, N'Movie was awful', CAST(4.5 AS Decimal(2, 1)))
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerComments], [BorrowerRating]) VALUES (3, 17, 1, CAST(N'2016-04-11' AS Date), CAST(N'2016-04-12' AS Date), N'Movie was amazing!', CAST(1.2 AS Decimal(2, 1)))
SET IDENTITY_INSERT [dbo].[BorrowInfo] OFF
SET IDENTITY_INSERT [dbo].[Director] ON 

INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (1, N'Jennifer', N'Lee')
INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (2, N'Gore', N'Verbinski')
INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (3, N'Wachowski', N'Bros.')
INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (4, N'Steven', N'Spielberg')
INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (5, N'James', N'Cameron')
SET IDENTITY_INSERT [dbo].[Director] OFF
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 13)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 14)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 15)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (2, 16)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (3, 18)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (4, 12)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (5, 16)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (6, 17)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (7, 17)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 13)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 14)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 15)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (2, 16)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (3, 18)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (4, 12)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (5, 16)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (6, 17)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (7, 17)
SET IDENTITY_INSERT [dbo].[DvdCatalog] ON 

INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments], [AverageRating]) VALUES (12, 1, 2, N'Frozen', CAST(N'2013-11-19' AS Date), N'2', N'Yo, dis movie ain''t no good.', CAST(4.8 AS Decimal(2, 1)))
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments], [AverageRating]) VALUES (13, 2, 2, N'Pirates of the Caribbean 1', CAST(N'2003-06-28' AS Date), N'3', NULL, NULL)
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments], [AverageRating]) VALUES (14, 2, 2, N'Pirates of the Caribbean 2', CAST(N'2006-07-07' AS Date), N'3', NULL, NULL)
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments], [AverageRating]) VALUES (15, 2, 2, N'Pirates of the Caribbean 3', CAST(N'2007-05-25' AS Date), N'3', N'Movie was too cute.', CAST(1.2 AS Decimal(2, 1)))
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments], [AverageRating]) VALUES (16, 3, 3, N'The Matrix', CAST(N'1999-03-31' AS Date), N'4', N'Spoiler: Harry dies!', CAST(4.0 AS Decimal(2, 1)))
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments], [AverageRating]) VALUES (17, 4, 1, N'Jurassic Park', CAST(N'1993-06-11' AS Date), N'3', N'Movie was hilarious!', CAST(5.0 AS Decimal(2, 1)))
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [BorrowerComments], [AverageRating]) VALUES (18, 5, 6, N'Titanic', CAST(N'1997-12-19' AS Date), N'PG-13', N'Wasn''t even that scary.', CAST(3.0 AS Decimal(2, 1)))
SET IDENTITY_INSERT [dbo].[DvdCatalog] OFF
SET IDENTITY_INSERT [dbo].[Studio] ON 

INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (1, N'NBC Universal')
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (2, N'Walt Disney Studios')
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (3, N'Warner Bros.')
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (4, N'Fox Films')
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (5, N'Sony Pictures')
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (6, N'Paramount Motion Pictures')
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (7, N'LionsGate')
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (8, N'Regal Entertainment')
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (9, N'MGM')
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (10, N'Dreamworks')
SET IDENTITY_INSERT [dbo].[Studio] OFF
ALTER TABLE [dbo].[BorrowInfo]  WITH CHECK ADD  CONSTRAINT [FK_BorrowerInfo_BorrowerName] FOREIGN KEY([BorrowerID])
REFERENCES [dbo].[Borrower] ([BorrowerID])
GO
ALTER TABLE [dbo].[BorrowInfo] CHECK CONSTRAINT [FK_BorrowerInfo_BorrowerName]
GO
ALTER TABLE [dbo].[BorrowInfo]  WITH CHECK ADD  CONSTRAINT [FK_BorrowerInfo_DVDCatalog] FOREIGN KEY([DvdID])
REFERENCES [dbo].[DvdCatalog] ([DvdID])
GO
ALTER TABLE [dbo].[BorrowInfo] CHECK CONSTRAINT [FK_BorrowerInfo_DVDCatalog]
GO
ALTER TABLE [dbo].[DvdActor]  WITH CHECK ADD  CONSTRAINT [FK_DvdActor_Actor] FOREIGN KEY([ActorID])
REFERENCES [dbo].[Actor] ([ActorId])
GO
ALTER TABLE [dbo].[DvdActor] CHECK CONSTRAINT [FK_DvdActor_Actor]
GO
ALTER TABLE [dbo].[DvdActor]  WITH CHECK ADD  CONSTRAINT [FK_DvdActor_DVDCatalog] FOREIGN KEY([DvdID])
REFERENCES [dbo].[DvdCatalog] ([DvdID])
GO
ALTER TABLE [dbo].[DvdActor] CHECK CONSTRAINT [FK_DvdActor_DVDCatalog]
GO
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
