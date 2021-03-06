USE [CarDealership]
GO
SET IDENTITY_INSERT [dbo].[RequestForm] ON 

GO
INSERT [dbo].[RequestForm] ([RequestFormId], [VehicleId], [FirstName], [LastName], [EmailAddress], [PhoneNumber], [BestTimeToCall], [PreferedContactMethod], [DateNeedToPurchaseBy], [AdditionalInfo], [LastContacted], [RequestFormStatus]) VALUES (1, 1, N'Kirkland', N'Brown', NULL, N'330-330-3303', NULL, N'0', NULL, NULL, NULL, N'2')
GO
INSERT [dbo].[RequestForm] ([RequestFormId], [VehicleId], [FirstName], [LastName], [EmailAddress], [PhoneNumber], [BestTimeToCall], [PreferedContactMethod], [DateNeedToPurchaseBy], [AdditionalInfo], [LastContacted], [RequestFormStatus]) VALUES (2, 9, N'Jeane', N'Hong', NULL, N'3333333', N'after 6pm', N'0', CAST(N'2016-04-28' AS Date), NULL, CAST(N'2016-04-18 00:00:00.0000000' AS DateTime2), N'1')
GO
SET IDENTITY_INSERT [dbo].[RequestForm] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicle] ON 

GO
INSERT [dbo].[Vehicle] ([VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]) VALUES (1, N'Porsche', N'Cayman GTS', 2015, 0, N'New - 2015 Porsche Cayman', N'Best Car Ever!', CAST(50000.00 AS Decimal(20, 2)), N'2015PorscheCayman.jpg', 1, 1)
GO
INSERT [dbo].[Vehicle] ([VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]) VALUES (5, N'Tesla', N'Model S', 2017, 0, N'New - 2017 Tesla Model S 90D - Available in 2017!', N'Best Car Everrrr!', CAST(70000.00 AS Decimal(20, 2)), N'2017TeslaModelS.jpg', 1, 1)
GO
INSERT [dbo].[Vehicle] ([VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]) VALUES (8, N'Honda', N'Accord', 2016, 1500, N'Barely Used - 2016 Honda Accord', N'You should buy this, fr fr.', CAST(24000.00 AS Decimal(20, 2)), N'2016HondaAccord.jpg', 1, 0)
GO
INSERT [dbo].[Vehicle] ([VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]) VALUES (9, N'Toyota', N'Corolla', 1997, 60000, N'Piece o Crap', N'It runs. ', CAST(5000.00 AS Decimal(20, 2)), N'1997ToyotaCorolla.jpg', 1, 0)
GO
INSERT [dbo].[Vehicle] ([VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]) VALUES (10, N'Honda', N'Civic', 1995, 100000, N'A huge paper weight', N'Pretty much a paperweight. Probably best not to buy it', CAST(1000.00 AS Decimal(20, 2)), N'1995HondaCivic.jpg', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
GO
