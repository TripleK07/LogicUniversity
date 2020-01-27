USE [ADTeam6]
GO
INSERT [dbo].[Department] ([DepartmentID], [Departmentname], [DepartmentHead], [CollectionPoint], [ContactName], [ContactNumber], [FaxNo]) VALUES (N'1', N'IT', N'IT', N'Admin', N'John', N'01', NULL)
GO
INSERT [dbo].[Users] ([UserID], [Username], [Passcode], [EmailID], [role], [SessionID], [DeptID_FK]) VALUES (1, N'kkk', N'kkk', N'kkk', N'master', NULL, N'1')
GO
INSERT [dbo].[RequisitionList] ([RequisitionID], [statusOfRequest], [DateofSubmission], [Comments], [DeptID_FK], [UserID_FK]) VALUES (1, N'Approved', N'2020-01-25', NULL, N'1', 1)
GO
INSERT [dbo].[RequisitionList] ([RequisitionID], [statusOfRequest], [DateofSubmission], [Comments], [DeptID_FK], [UserID_FK]) VALUES (2, N'Rejected', N'2020-01-26', NULL, N'1', 1)
GO
INSERT [dbo].[RequisitionList] ([RequisitionID], [statusOfRequest], [DateofSubmission], [Comments], [DeptID_FK], [UserID_FK]) VALUES (3, N'None', N'2020-01-27', NULL, N'1', 1)
GO
