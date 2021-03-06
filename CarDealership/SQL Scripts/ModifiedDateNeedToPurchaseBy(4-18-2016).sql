USE [CarDealership]
GO
/****** Object:  Table [dbo].[RequestForm]    Script Date: 4/18/2016 11:57:19 AM ******/
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
	[DateNeedToPurchaseBy] [datetime2](7) NULL,
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
SET IDENTITY_INSERT [dbo].[RequestForm] ON 

INSERT [dbo].[RequestForm] ([RequestFormId], [VehicleId], [FirstName], [LastName], [EmailAddress], [PhoneNumber], [BestTimeToCall], [PreferedContactMethod], [DateNeedToPurchaseBy], [AdditionalInfo], [LastContacted], [RequestFormStatus]) VALUES (1, 1, N'Kirkland', N'Brown', N'Blahblehblah@gmail.com', N'330-330-3303', N'Never plox', N'Email', CAST(N'2016-04-30 00:00:00.0000000' AS DateTime2), N'Give me the car.', CAST(N'2016-04-17 00:00:00.0000000' AS DateTime2), N'FutureProspect')
SET IDENTITY_INSERT [dbo].[RequestForm] OFF
