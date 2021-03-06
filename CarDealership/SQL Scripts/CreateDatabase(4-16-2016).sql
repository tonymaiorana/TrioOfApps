USE [master]
GO
/****** Object:  Database [CarDealership]    Script Date: 4/16/2016 9:18:23 PM ******/
CREATE DATABASE [CarDealership]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarDealership', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\CarDealership.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CarDealership_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\CarDealership_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CarDealership] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarDealership].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarDealership] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarDealership] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarDealership] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarDealership] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarDealership] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarDealership] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarDealership] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarDealership] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarDealership] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarDealership] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarDealership] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarDealership] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarDealership] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarDealership] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarDealership] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarDealership] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarDealership] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarDealership] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarDealership] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarDealership] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarDealership] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarDealership] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarDealership] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarDealership] SET  MULTI_USER 
GO
ALTER DATABASE [CarDealership] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarDealership] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarDealership] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarDealership] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CarDealership] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CarDealership]
GO
/****** Object:  Table [dbo].[RequestForm]    Script Date: 4/16/2016 9:18:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RequestForm](
	[RequestFormId] [smallint] IDENTITY(1,1) NOT NULL,
	[VehicleId] [smallint] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[BestTimeToCall] [nvarchar](max) NULL,
	[PreferedContactMethod] [nvarchar](50) NOT NULL,
	[DateNeedToPurchaseBy] [date] NULL,
	[AdditionalInfo] [nvarchar](max) NULL,
	[LastContacted] [datetime2](7) NOT NULL,
	[RequestFormStatus] [varchar](max) NOT NULL,
	[UserAccountId] [smallint] NOT NULL,
 CONSTRAINT [PK_RequestForm] PRIMARY KEY CLUSTERED 
(
	[RequestFormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 4/16/2016 9:18:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[AccountId] [smallint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 4/16/2016 9:18:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[VehicleId] [int] IDENTITY(1,1) NOT NULL,
	[Make] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Year] [date] NOT NULL,
	[Mileage] [int] NOT NULL,
	[AdTitle] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](20, 2) NOT NULL,
	[PictureUrl] [nvarchar](max) NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[IsNew] [bit] NOT NULL,
	[AdminAccountId] [smallint] NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [CarDealership] SET  READ_WRITE 
GO
