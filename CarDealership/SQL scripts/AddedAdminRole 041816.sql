USE [CarDealership]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Admin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'User')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ed80fc96-f579-4b0b-806a-f89fdb5c42e4', N'hisuida@me.com', 0, N'ADG+oi75wfeNy9NRDtLsn1wSLE1R6VZlWIDZMJXfHTmMY8ZSxCxTBvdsdccHLEoUXA==', N'e8555e6a-9b84-4ed3-a208-0efc28614109', NULL, 0, 0, NULL, 1, 0, N'hisuida@me.com')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ed80fc96-f579-4b0b-806a-f89fdb5c42e4', N'1')
GO
