USE [DVD]
GO
SET IDENTITY_INSERT [dbo].[BorrowInfo] ON 

INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [UserComments], [UserRating]) VALUES (2, 14, 2, CAST(N'2016-04-12' AS Date), NULL, N'Movie was awful', CAST(4.5 AS Decimal(2, 1)))
INSERT [dbo].[BorrowInfo] ([BorrowInfoID], [DvdID], [BorrowerID], [DateBorrowed], [DateReturned], [UserComments], [UserRating]) VALUES (3, 17, 1, CAST(N'2016-04-11' AS Date), CAST(N'2016-04-12' AS Date), N'Movie was amazing!', CAST(1.2 AS Decimal(2, 1)))
SET IDENTITY_INSERT [dbo].[BorrowInfo] OFF
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 13)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 14)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (1, 15)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (2, 16)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (3, 18)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (4, 12)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (5, 16)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (6, 17)
INSERT [dbo].[DvdActor] ([ActorID], [DvdID]) VALUES (7, 17)
