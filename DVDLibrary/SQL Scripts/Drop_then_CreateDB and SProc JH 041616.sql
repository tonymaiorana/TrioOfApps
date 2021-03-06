USE [DVD]
GO
/****** Object:  StoredProcedure [dbo].[DeleteDVD]    Script Date: 4/16/2016 3:49:34 PM ******/
DROP PROCEDURE [dbo].[DeleteDVD]
GO
ALTER TABLE [dbo].[DVDCatalog] DROP CONSTRAINT [FK_DVDCatalog_Studio]
GO
ALTER TABLE [dbo].[DVDCatalog] DROP CONSTRAINT [FK_DVDCatalog_Director]
GO
ALTER TABLE [dbo].[DvdActor] DROP CONSTRAINT [FK_DvdActor_DVDCatalog]
GO
ALTER TABLE [dbo].[DvdActor] DROP CONSTRAINT [FK_DvdActor_Actor]
GO
ALTER TABLE [dbo].[BorrowInfo] DROP CONSTRAINT [FK_BorrowerInfo_DVDCatalog]
GO
ALTER TABLE [dbo].[BorrowInfo] DROP CONSTRAINT [FK_BorrowerInfo_BorrowerName]
GO
/****** Object:  Index [IX_DVDCatalog]    Script Date: 4/16/2016 3:49:35 PM ******/
DROP INDEX [IX_DVDCatalog] ON [dbo].[DVDCatalog]
GO
/****** Object:  Table [dbo].[Studio]    Script Date: 4/16/2016 3:49:35 PM ******/
DROP TABLE [dbo].[Studio]
GO
/****** Object:  Table [dbo].[DVDCatalog]    Script Date: 4/16/2016 3:49:35 PM ******/
DROP TABLE [dbo].[DVDCatalog]
GO
/****** Object:  Table [dbo].[DvdActor]    Script Date: 4/16/2016 3:49:35 PM ******/
DROP TABLE [dbo].[DvdActor]
GO
/****** Object:  Table [dbo].[Director]    Script Date: 4/16/2016 3:49:35 PM ******/
DROP TABLE [dbo].[Director]
GO
/****** Object:  Table [dbo].[BorrowInfo]    Script Date: 4/16/2016 3:49:35 PM ******/
DROP TABLE [dbo].[BorrowInfo]
GO
/****** Object:  Table [dbo].[Borrower]    Script Date: 4/16/2016 3:49:35 PM ******/
DROP TABLE [dbo].[Borrower]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 4/16/2016 3:49:35 PM ******/
DROP TABLE [dbo].[Actor]
GO
USE [master]
GO
/****** Object:  Database [DVD]    Script Date: 4/16/2016 3:49:35 PM ******/
DROP DATABASE [DVD]
GO
/****** Object:  Database [DVD]    Script Date: 4/16/2016 3:49:35 PM ******/
CREATE DATABASE [DVD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DVD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\DVD.mdf' , SIZE = 5056KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DVD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\DVD_log.ldf' , SIZE = 5056KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DVD] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DVD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DVD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DVD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DVD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DVD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DVD] SET ARITHABORT OFF 
GO
ALTER DATABASE [DVD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DVD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DVD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DVD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DVD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DVD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DVD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DVD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DVD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DVD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DVD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DVD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DVD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DVD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DVD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DVD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DVD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DVD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DVD] SET  MULTI_USER 
GO
ALTER DATABASE [DVD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DVD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DVD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DVD] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DVD] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DVD]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 4/16/2016 3:49:35 PM ******/
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
/****** Object:  Table [dbo].[Borrower]    Script Date: 4/16/2016 3:49:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Borrower](
	[BorrowerID] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[BorrowInfo]    Script Date: 4/16/2016 3:49:35 PM ******/
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
	[BorrowerRating] [smallint] NULL,
	[UserComments] [varchar](500) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_BorrowerInfo] PRIMARY KEY CLUSTERED 
(
	[BorrowInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Director]    Script Date: 4/16/2016 3:49:35 PM ******/
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
/****** Object:  Table [dbo].[DvdActor]    Script Date: 4/16/2016 3:49:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DvdActor](
	[ActorID] [int] NOT NULL,
	[DvdID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DVDCatalog]    Script Date: 4/16/2016 3:49:35 PM ******/
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
/****** Object:  Table [dbo].[Studio]    Script Date: 4/16/2016 3:49:35 PM ******/
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
SET IDENTITY_INSERT [dbo].[Borrower] ON 

INSERT [dbo].[Borrower] ([BorrowerID], [FirstName], [LastName], [PhoneNumber], [IsActive]) VALUES (1, N'ROCCO', N'RICCARDI', N'5555555', 1)
INSERT [dbo].[Borrower] ([BorrowerID], [FirstName], [LastName], [PhoneNumber], [IsActive]) VALUES (2, N'JEANE', N'HONG', N'3333333', 1)
INSERT [dbo].[Borrower] ([BorrowerID], [FirstName], [LastName], [PhoneNumber], [IsActive]) VALUES (3, N'JANE', N'SMITH', N'1111111', 1)
INSERT [dbo].[Borrower] ([BorrowerID], [FirstName], [LastName], [PhoneNumber], [IsActive]) VALUES (4, N'JOHN', N'SMITH', N'2222222', 1)
INSERT [dbo].[Borrower] ([BorrowerID], [FirstName], [LastName], [PhoneNumber], [IsActive]) VALUES (5, N'JJ', N'Smith', N'6666666', 0)
INSERT [dbo].[Borrower] ([BorrowerID], [FirstName], [LastName], [PhoneNumber], [IsActive]) VALUES (6, N'Sally', N'Smith', N'7777777', 0)
INSERT [dbo].[Borrower] ([BorrowerID], [FirstName], [LastName], [PhoneNumber], [IsActive]) VALUES (7, N'Rick', N'Smith', N'8888888', 0)
INSERT [dbo].[Borrower] ([BorrowerID], [FirstName], [LastName], [PhoneNumber], [IsActive]) VALUES (8, N'CRAIG', N'MIN', N'2222222', 0)
INSERT [dbo].[Borrower] ([BorrowerID], [FirstName], [LastName], [PhoneNumber], [IsActive]) VALUES (9, N'MARY', N'SMITH', N'9999999', 0)
SET IDENTITY_INSERT [dbo].[Borrower] OFF
SET IDENTITY_INSERT [dbo].[BorrowInfo] ON 

INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerRating], [UserComments], [IsActive]) VALUES (2, 14, 2, CAST(N'2016-04-12' AS Date), CAST(N'2016-04-14' AS Date), 4, N'Movie was awful', 0)
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerRating], [UserComments], [IsActive]) VALUES (3, 17, 1, CAST(N'2016-04-11' AS Date), CAST(N'2016-04-15' AS Date), 1, N'Movie was amazing!', 0)
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerRating], [UserComments], [IsActive]) VALUES (4, 12, 2, CAST(N'2016-04-14' AS Date), CAST(N'2016-04-15' AS Date), 0, NULL, 0)
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerRating], [UserComments], [IsActive]) VALUES (5, 14, 2, CAST(N'2016-04-14' AS Date), CAST(N'2016-04-15' AS Date), 0, NULL, 0)
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerRating], [UserComments], [IsActive]) VALUES (6, 14, 2, CAST(N'2016-04-14' AS Date), CAST(N'2016-04-15' AS Date), 0, NULL, 0)
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerRating], [UserComments], [IsActive]) VALUES (7, 16, 5, CAST(N'2016-04-15' AS Date), NULL, NULL, NULL, 1)
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerRating], [UserComments], [IsActive]) VALUES (8, 16, 2, CAST(N'2016-04-15' AS Date), CAST(N'2016-04-15' AS Date), NULL, NULL, 0)
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerRating], [UserComments], [IsActive]) VALUES (9, 12, 2, CAST(N'2016-04-15' AS Date), CAST(N'2016-04-15' AS Date), NULL, NULL, 0)
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerRating], [UserComments], [IsActive]) VALUES (10, 13, 2, CAST(N'2016-04-15' AS Date), NULL, NULL, NULL, 1)
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerRating], [UserComments], [IsActive]) VALUES (11, 14, 2, CAST(N'2016-04-15' AS Date), NULL, NULL, NULL, 1)
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerRating], [UserComments], [IsActive]) VALUES (12, 15, 2, CAST(N'2016-04-15' AS Date), NULL, NULL, NULL, 1)
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
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (5, 16)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (6, 17)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (7, 17)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 13)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 14)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 15)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (2, 16)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (3, 18)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (5, 16)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (6, 17)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (7, 17)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 13)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 14)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 15)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (2, 16)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (3, 18)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (5, 16)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (6, 17)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (7, 17)
SET IDENTITY_INSERT [dbo].[DVDCatalog] ON 

INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (12, 1, 2, N'Frozen', CAST(N'2013-11-19' AS Date), N'PG', NULL)
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (13, 2, 2, N'Pirates of the Caribbean 1', CAST(N'2003-06-28' AS Date), N'PG13', NULL)
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (14, 2, 2, N'Pirates of the Caribbean 2', CAST(N'2006-07-07' AS Date), N'PG13', NULL)
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (15, 2, 2, N'Pirates of the Caribbean 3', CAST(N'2007-05-25' AS Date), N'PG13', NULL)
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (16, 3, 3, N'The Matrix', CAST(N'1999-03-31' AS Date), N'R', NULL)
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (17, 4, 1, N'Jurassic Park', CAST(N'1993-06-11' AS Date), N'PG13', NULL)
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (18, 5, 6, N'Titanic', CAST(N'1997-12-19' AS Date), N'PG13', NULL)
INSERT [dbo].[DVDCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating], [UserComments]) VALUES (19, 1, 4, N'Frozen', CAST(N'1990-10-19' AS Date), N'1', NULL)
SET IDENTITY_INSERT [dbo].[DVDCatalog] OFF
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
/****** Object:  Index [IX_DVDCatalog]    Script Date: 4/16/2016 3:49:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_DVDCatalog] ON [dbo].[DVDCatalog]
(
	[DvdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BorrowInfo]  WITH CHECK ADD  CONSTRAINT [FK_BorrowerInfo_BorrowerName] FOREIGN KEY([BorrowerID])
REFERENCES [dbo].[Borrower] ([BorrowerID])
GO
ALTER TABLE [dbo].[BorrowInfo] CHECK CONSTRAINT [FK_BorrowerInfo_BorrowerName]
GO
ALTER TABLE [dbo].[BorrowInfo]  WITH CHECK ADD  CONSTRAINT [FK_BorrowerInfo_DVDCatalog] FOREIGN KEY([DvdID])
REFERENCES [dbo].[DVDCatalog] ([DvdID])
GO
ALTER TABLE [dbo].[BorrowInfo] CHECK CONSTRAINT [FK_BorrowerInfo_DVDCatalog]
GO
ALTER TABLE [dbo].[DvdActor]  WITH CHECK ADD  CONSTRAINT [FK_DvdActor_Actor] FOREIGN KEY([ActorID])
REFERENCES [dbo].[Actor] ([ActorId])
GO
ALTER TABLE [dbo].[DvdActor] CHECK CONSTRAINT [FK_DvdActor_Actor]
GO
ALTER TABLE [dbo].[DvdActor]  WITH CHECK ADD  CONSTRAINT [FK_DvdActor_DVDCatalog] FOREIGN KEY([DvdID])
REFERENCES [dbo].[DVDCatalog] ([DvdID])
GO
ALTER TABLE [dbo].[DvdActor] CHECK CONSTRAINT [FK_DvdActor_DVDCatalog]
GO
ALTER TABLE [dbo].[DVDCatalog]  WITH CHECK ADD  CONSTRAINT [FK_DVDCatalog_Director] FOREIGN KEY([DirectorID])
REFERENCES [dbo].[Director] ([DirectorID])
GO
ALTER TABLE [dbo].[DVDCatalog] CHECK CONSTRAINT [FK_DVDCatalog_Director]
GO
ALTER TABLE [dbo].[DVDCatalog]  WITH CHECK ADD  CONSTRAINT [FK_DVDCatalog_Studio] FOREIGN KEY([StudioID])
REFERENCES [dbo].[Studio] ([StudioID])
GO
ALTER TABLE [dbo].[DVDCatalog] CHECK CONSTRAINT [FK_DVDCatalog_Studio]
GO
/****** Object:  StoredProcedure [dbo].[DeleteDVD]    Script Date: 4/16/2016 3:49:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kaz
-- Create date: 04/08/2016
-- Description:	RemoveDVD
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDVD] 
	-- Add the parameters for the stored procedure here
	@DvdID int 
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM DvdActor
	WHERE DvdID = @DvdID

	DELETE FROM BorrowInfo
	WHERE DvdID = @DvdID

	DELETE FROM DVDCatalog
	WHERE DvdID = @DvdID

END


GO
USE [master]
GO
ALTER DATABASE [DVD] SET  READ_WRITE 
GO
