USE [DVD]
GO
/****** Object:  StoredProcedure [dbo].[DeleteDVD]    Script Date: 4/11/2016 8:17:20 AM ******/
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
/****** Object:  Index [IX_DVDCatalog]    Script Date: 4/11/2016 8:17:20 AM ******/
DROP INDEX [IX_DVDCatalog] ON [dbo].[DVDCatalog]
GO
/****** Object:  Table [dbo].[Studio]    Script Date: 4/11/2016 8:17:20 AM ******/
DROP TABLE [dbo].[Studio]
GO
/****** Object:  Table [dbo].[DVDCatalog]    Script Date: 4/11/2016 8:17:20 AM ******/
DROP TABLE [dbo].[DVDCatalog]
GO
/****** Object:  Table [dbo].[DvdActor]    Script Date: 4/11/2016 8:17:20 AM ******/
DROP TABLE [dbo].[DvdActor]
GO
/****** Object:  Table [dbo].[Director]    Script Date: 4/11/2016 8:17:20 AM ******/
DROP TABLE [dbo].[Director]
GO
/****** Object:  Table [dbo].[BorrowInfo]    Script Date: 4/11/2016 8:17:20 AM ******/
DROP TABLE [dbo].[BorrowInfo]
GO
/****** Object:  Table [dbo].[Borrower]    Script Date: 4/11/2016 8:17:20 AM ******/
DROP TABLE [dbo].[Borrower]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 4/11/2016 8:17:20 AM ******/
DROP TABLE [dbo].[Actor]
GO
USE [master]
GO
/****** Object:  Database [DVD]    Script Date: 4/11/2016 8:17:20 AM ******/
DROP DATABASE [DVD]
GO
/****** Object:  Database [DVD]    Script Date: 4/11/2016 8:17:20 AM ******/
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
/****** Object:  Table [dbo].[Actor]    Script Date: 4/11/2016 8:17:20 AM ******/
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
/****** Object:  Table [dbo].[Borrower]    Script Date: 4/11/2016 8:17:20 AM ******/
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
/****** Object:  Table [dbo].[BorrowInfo]    Script Date: 4/11/2016 8:17:20 AM ******/
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
	[UserRating] [smallint] NULL,
	[UserComments] [varchar](500) NULL,
 CONSTRAINT [PK_BorrowerInfo] PRIMARY KEY CLUSTERED 
(
	[BorrowInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Director]    Script Date: 4/11/2016 8:17:20 AM ******/
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
/****** Object:  Table [dbo].[DvdActor]    Script Date: 4/11/2016 8:17:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DvdActor](
	[ActorID] [int] NOT NULL,
	[DvdID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DVDCatalog]    Script Date: 4/11/2016 8:17:20 AM ******/
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
/****** Object:  Table [dbo].[Studio]    Script Date: 4/11/2016 8:17:20 AM ******/
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
INSERT [dbo].[Borrower] ([BorrowerID], [FirstName], [LastName], [PhoneNumber], [IsActive]) VALUES (1, N'Rocco', N'Riccardi', N'555-555-5555', 1)
GO
INSERT [dbo].[Borrower] ([BorrowerID], [FirstName], [LastName], [PhoneNumber], [IsActive]) VALUES (2, N'Jeane', N'Hong', N'333-333-3333', 1)
GO
SET IDENTITY_INSERT [dbo].[Director] ON 

GO
INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (1, N'Jennifer', N'Lee')
GO
INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (2, N'Gore', N'Verbinski')
GO
INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (3, N'Wachowski', N'Bros.')
GO
INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (4, N'Steven', N'Spielberg')
GO
INSERT [dbo].[Director] ([DirectorID], [FirstName], [LastName]) VALUES (5, N'James', N'Cameron')
GO
SET IDENTITY_INSERT [dbo].[Director] OFF
GO
SET IDENTITY_INSERT [dbo].[Studio] ON 

GO
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (1, N'NBC Universal')
GO
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (2, N'Walt Disney Studios')
GO
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (3, N'Warner Bros.')
GO
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (4, N'Fox Films')
GO
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (5, N'Sony Pictures')
GO
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (6, N'Paramount Motion Pictures')
GO
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (7, N'LionsGate')
GO
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (8, N'Regal Entertainment')
GO
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (9, N'MGM')
GO
INSERT [dbo].[Studio] ([StudioID], [StudioName]) VALUES (10, N'Dreamworks')
GO
SET IDENTITY_INSERT [dbo].[Studio] OFF
GO
/****** Object:  Index [IX_DVDCatalog]    Script Date: 4/11/2016 8:17:20 AM ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteDVD]    Script Date: 4/11/2016 8:17:20 AM ******/
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
