USE [CarDealership]
GO
/****** Object:  Table [dbo].[RequestForm]    Script Date: 4/18/2016 12:01:15 AM ******/
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
	[LastContacted] [datetime2](7) NULL,
	[RequestFormStatus] [varchar](max) NOT NULL,
 CONSTRAINT [PK_RequestForm] PRIMARY KEY CLUSTERED 
(
	[RequestFormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 4/18/2016 12:01:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[VehicleId] [int] IDENTITY(1,1) NOT NULL,
	[Make] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Year] [smallint] NOT NULL,
	[Mileage] [int] NOT NULL,
	[AdTitle] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](20, 2) NOT NULL,
	[PictureUrl] [nvarchar](max) NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[IsNew] [bit] NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[RequestForm] ON 

INSERT [dbo].[RequestForm] ([RequestFormId], [VehicleId], [FirstName], [LastName], [EmailAddress], [PhoneNumber], [BestTimeToCall], [PreferedContactMethod], [DateNeedToPurchaseBy], [AdditionalInfo], [LastContacted], [RequestFormStatus]) VALUES (1, 1, N'Kirkland', N'Brown', N'Blahblehblah@gmail.com', N'330-330-3303', N'Never plox', N'Email', CAST(N'2016-04-30' AS Date), N'Give me the car.', CAST(N'2016-04-17 00:00:00.0000000' AS DateTime2), N'FutureProspect')
SET IDENTITY_INSERT [dbo].[RequestForm] OFF
SET IDENTITY_INSERT [dbo].[Vehicle] ON 

INSERT [dbo].[Vehicle] ([VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]) VALUES (1, N'Porsche', N'Cayman GTS', 2015, 0, N'New - 2015 Porsche Cayman', N'Best Car Ever!', CAST(50000.00 AS Decimal(20, 2)), N'C:\Repos\ubs\CarDealership\CarDealership\CarDealership.Data\Images\2015PorscheCayman.jpg', 1, 1)
INSERT [dbo].[Vehicle] ([VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]) VALUES (5, N'Tesla', N'Model S', 2017, 0, N'New - 2017 Tesla Model S 90D - Available in 2017!', N'Best Car Everrrr!', CAST(70000.00 AS Decimal(20, 2)), N'\2017TeslaModelS.jpg', 0, 1)
INSERT [dbo].[Vehicle] ([VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]) VALUES (8, N'Honda', N'Accord', 2016, 1500, N'Barely Used - 2016 Honda Accord', N'You should buy this, fr fr.', CAST(24000.00 AS Decimal(20, 2)), N'\2016HondaAccord.jpg', 1, 0)
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
