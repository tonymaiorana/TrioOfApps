USE [CarDealership]
GO
SET IDENTITY_INSERT [dbo].[RequestForm] ON 

INSERT [dbo].[RequestForm] ([RequestFormId], [VehicleId], [FirstName], [LastName], [EmailAddress], [PhoneNumber], [BestTimeToCall], [PreferedContactMethod], [DateNeedToPurchaseBy], [AdditionalInfo], [LastContacted], [RequestFormStatus]) VALUES (1, 1, N'Kirkland', N'Brown', N'Blahblehblah@gmail.com', N'330-330-3303', N'Never plox', N'Email', CAST(N'2016-04-30' AS Date), N'Give me the car.', CAST(N'2016-04-17 00:00:00.0000000' AS DateTime2), N'FutureProspect')
SET IDENTITY_INSERT [dbo].[RequestForm] OFF
SET IDENTITY_INSERT [dbo].[Vehicle] ON 

INSERT [dbo].[Vehicle] ([VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]) VALUES (1, N'Porsche', N'Cayman GTS', 2015, 30, N'New - 2015 Porsche Cayman', N'Best Car Ever!', CAST(50000.00 AS Decimal(20, 2)), N'C:\Repos\ubs\CarDealership\CarDealership\CarDealership.Data\Images\2015PorscheCayman.jpg', 1, 1)
INSERT [dbo].[Vehicle] ([VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]) VALUES (5, N'Tesla', N'Model S', 2017, 253, N'New - 2017 Tesla Model S 90D - Available in 2017!', N'Best Car Everrrr!', CAST(70000.00 AS Decimal(20, 2)), N'\2017TeslaModelS.jpg', 0, 1)
INSERT [dbo].[Vehicle] ([VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]) VALUES (8, N'Honda', N'Accord', 2016, 32, N'Barely Used - 2016 Honda Accord', N'You should buy this, fr fr.', CAST(24000.00 AS Decimal(20, 2)), N'\2016HondaAccord.jpg', 1, 0)
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
