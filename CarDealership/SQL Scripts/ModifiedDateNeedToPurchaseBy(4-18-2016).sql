USE [CarDealership]
GO
/****** Object:  Table [dbo].[RequestForm]    Script Date: 4/18/2016 11:46:23 AM ******/
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
