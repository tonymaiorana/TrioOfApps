USE [CarDealership]
GO
SET IDENTITY_INSERT [dbo].[RequestForm] ON 

INSERT [dbo].[RequestForm] ([RequestFormId], [VehicleId], [FirstName], [LastName], [EmailAddress], [PhoneNumber], [BestTimeToCall], [PreferedContactMethod], [DateNeedToPurchaseBy], [AdditionalInfo], [LastContacted], [RequestFormStatus]) VALUES (1, 1, N'Kirkland', N'Brown', N'Blahblehblah@gmail.com', N'330-330-3303', N'Never plox', N'Email', CAST(N'2016-04-30 00:00:00.0000000' AS DateTime2), N'Give me the car.', CAST(N'2016-04-17 00:00:00.0000000' AS DateTime2), N'FutureProspect')
SET IDENTITY_INSERT [dbo].[RequestForm] OFF
