USE [DVD]
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
SET IDENTITY_INSERT [dbo].[DvdCatalog] ON 

GO
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating]) VALUES (13, 2, 2, N'Pirates of the Caribbean 1', CAST(N'2003-06-28' AS Date), N'3')
GO
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating]) VALUES (14, 2, 2, N'Pirates of the Caribbean 2', CAST(N'2006-07-07' AS Date), N'3')
GO
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating]) VALUES (15, 2, 2, N'Pirates of the Caribbean 3', CAST(N'2007-05-25' AS Date), N'3')
GO
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating]) VALUES (16, 3, 3, N'The Matrix', CAST(N'1999-03-31' AS Date), N'4')
GO
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating]) VALUES (17, 4, 1, N'Jurassic Park', CAST(N'1993-06-11' AS Date), N'3')
GO
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating]) VALUES (18, 5, 6, N'Titanic', CAST(N'1997-12-19' AS Date), N'2')
GO
INSERT [dbo].[DvdCatalog] ([DvdID], [DirectorID], [StudioID], [DvdTitle], [ReleaseDate], [MPAARating]) VALUES (19, 1, 4, N'Frozen', CAST(N'1990-10-19' AS Date), N'1')
GO
SET IDENTITY_INSERT [dbo].[DvdCatalog] OFF
GO
SET IDENTITY_INSERT [dbo].[BorrowInfo] ON 

GO
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerComment], [BorrowerRating]) VALUES (2, 14, 2, CAST(N'2016-04-12' AS Date), NULL, N'Movie was awful', CAST(4.5 AS Decimal(2, 1)))
GO
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [BorrowerComment], [BorrowerRating]) VALUES (3, 17, 1, CAST(N'2016-04-11' AS Date), CAST(N'2016-04-12' AS Date), N'Movie was amazing!', CAST(1.2 AS Decimal(2, 1)))
GO
SET IDENTITY_INSERT [dbo].[BorrowInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Actor] ON 

GO
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (1, N'Johnny', N'Depp')
GO
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (2, N'Keanu', N'Reeves')
GO
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (3, N'Leonardo', N'DiCaprio')
GO
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (4, N'Kate', N'Winslet')
GO
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (5, N'Laurence', N'Fishburne')
GO
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (6, N'Jeff', N'Goldblum')
GO
INSERT [dbo].[Actor] ([ActorId], [FirstName], [LastName]) VALUES (7, N'Sam', N'Neill')
GO
SET IDENTITY_INSERT [dbo].[Actor] OFF
GO
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (N'1         ', 13)
GO
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (N'1         ', 14)
GO
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (N'1         ', 15)
GO
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (N'2         ', 16)
GO
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (N'3         ', 18)
GO
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (N'5         ', 16)
GO
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (N'6         ', 17)
GO
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (N'7         ', 17)
GO
