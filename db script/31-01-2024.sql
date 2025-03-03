USE [StudentManagementDB]
GO
/****** Object:  Table [dbo].[MstNationalities]    Script Date: 31-Jan-25 12:09:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstNationalities](
	[NationalityAID] [int] IDENTITY(1,1) NOT NULL,
	[Nationality] [nvarchar](100) NOT NULL,
	[OrderIndex] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_MstNationalities] PRIMARY KEY CLUSTERED 
(
	[NationalityAID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstStudents]    Script Date: 31-Jan-25 12:09:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstStudents](
	[StudentAID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[DOB] [datetime] NULL,
	[NationalityID] [int] NULL,
	[IsDeleted] [bit] NULL,
	[EntDate] [datetime] NULL,
 CONSTRAINT [PK_MstStudents] PRIMARY KEY CLUSTERED 
(
	[StudentAID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewStudents]    Script Date: 31-Jan-25 12:09:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW  [dbo].[ViewStudents] AS
SELECT  Stud.StudentAID, Stud.FirstName, Stud.LastName, Stud.DOB, Stud.NationalityID, Nat.Nationality
FROM    MstStudents AS Stud LEFT OUTER JOIN
        MstNationalities AS Nat ON Stud.NationalityID = Nat.NationalityAID
WHERE   ISNULL(Stud.IsDeleted,0)=0
GO
/****** Object:  Table [dbo].[MstRelationship]    Script Date: 31-Jan-25 12:09:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstRelationship](
	[RelationAID] [int] IDENTITY(1,1) NOT NULL,
	[Relation] [nvarchar](50) NULL,
	[OrderIndex] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_MstRelationships] PRIMARY KEY CLUSTERED 
(
	[RelationAID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamilyMember]    Script Date: 31-Jan-25 12:09:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyMember](
	[MemberAID] [int] IDENTITY(1,1) NOT NULL,
	[MemberFirstName] [nvarchar](100) NULL,
	[MemberLastName] [nvarchar](100) NULL,
	[DateOfBirth] [datetime] NULL,
	[RelationshipID] [int] NULL,
	[NationalityID] [int] NULL,
	[StudentID] [int] NULL,
	[IsDeleted] [bit] NULL,
	[EntDate] [datetime] NULL,
 CONSTRAINT [PK_MstFamilyMembers] PRIMARY KEY CLUSTERED 
(
	[MemberAID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewStudentRelatives]    Script Date: 31-Jan-25 12:09:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW  [dbo].[ViewStudentRelatives] AS
SELECT        Fam.MemberAID, Fam.MemberFirstName, 
              Fam.MemberLastName, Fam.DateOfBirth , Fam.RelationshipID AS RelativeRelationID,Relation.Relation,
			  Fam.NationalityID AS RelativeNationalityID,  Nat.Nationality RelativeNationality,Fam.StudentID
			  -- , Stud.FirstName StudFirstName, Stud.LastName StudLastName, Stud.DOB StudDOB,
			  --Stud.NationalityID AS StudNationalityID, Stud.Nationality AS StudNationality
              
FROM          FamilyMember AS Fam  LEFT OUTER JOIN ViewStudents AS Stud
              ON Stud.StudentAID = Fam.StudentID LEFT OUTER JOIN
              MstNationalities AS Nat ON Fam.NationalityID = Nat.NationalityAID LEFT OUTER JOIN
              MstRelationship AS Relation ON Fam.RelationshipID = Relation.RelationAID
WHERE        (ISNULL(Fam.IsDeleted, 0) = 0)
        
GO
SET IDENTITY_INSERT [dbo].[FamilyMember] ON 

INSERT [dbo].[FamilyMember] ([MemberAID], [MemberFirstName], [MemberLastName], [DateOfBirth], [RelationshipID], [NationalityID], [StudentID], [IsDeleted], [EntDate]) VALUES (1, N'asd', N'rwerew', CAST(N'2025-01-31T07:41:54.503' AS DateTime), 2, 2, 1, 0, CAST(N'2025-01-31T09:56:53.710' AS DateTime))
SET IDENTITY_INSERT [dbo].[FamilyMember] OFF
GO
SET IDENTITY_INSERT [dbo].[MstNationalities] ON 

INSERT [dbo].[MstNationalities] ([NationalityAID], [Nationality], [OrderIndex], [IsActive]) VALUES (1, N'United Arab Emirates', 1, 1)
INSERT [dbo].[MstNationalities] ([NationalityAID], [Nationality], [OrderIndex], [IsActive]) VALUES (2, N'Bahrain', 2, 1)
INSERT [dbo].[MstNationalities] ([NationalityAID], [Nationality], [OrderIndex], [IsActive]) VALUES (3, N'Kuwait', 3, 1)
INSERT [dbo].[MstNationalities] ([NationalityAID], [Nationality], [OrderIndex], [IsActive]) VALUES (4, N'Oman', 4, 1)
INSERT [dbo].[MstNationalities] ([NationalityAID], [Nationality], [OrderIndex], [IsActive]) VALUES (5, N'India', 5, 1)
INSERT [dbo].[MstNationalities] ([NationalityAID], [Nationality], [OrderIndex], [IsActive]) VALUES (6, N'China', 6, 1)
SET IDENTITY_INSERT [dbo].[MstNationalities] OFF
GO
SET IDENTITY_INSERT [dbo].[MstRelationship] ON 

INSERT [dbo].[MstRelationship] ([RelationAID], [Relation], [OrderIndex], [IsActive]) VALUES (1, N'Parent', 1, 1)
INSERT [dbo].[MstRelationship] ([RelationAID], [Relation], [OrderIndex], [IsActive]) VALUES (2, N'Sibling', 2, 1)
INSERT [dbo].[MstRelationship] ([RelationAID], [Relation], [OrderIndex], [IsActive]) VALUES (3, N'Spouse', 3, 1)
SET IDENTITY_INSERT [dbo].[MstRelationship] OFF
GO
SET IDENTITY_INSERT [dbo].[MstStudents] ON 

INSERT [dbo].[MstStudents] ([StudentAID], [FirstName], [LastName], [DOB], [NationalityID], [IsDeleted], [EntDate]) VALUES (1, N'shamna', N'ap', CAST(N'2001-01-31T07:46:15.987' AS DateTime), 1, 0, CAST(N'2025-01-31T09:54:23.523' AS DateTime))
INSERT [dbo].[MstStudents] ([StudentAID], [FirstName], [LastName], [DOB], [NationalityID], [IsDeleted], [EntDate]) VALUES (2, N'asd', N'dsa', CAST(N'2025-01-31T07:45:48.503' AS DateTime), NULL, 0, CAST(N'2025-01-31T11:46:00.533' AS DateTime))
SET IDENTITY_INSERT [dbo].[MstStudents] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__MstNatio__2062829385D913FE]    Script Date: 31-Jan-25 12:09:02 PM ******/
ALTER TABLE [dbo].[MstNationalities] ADD  CONSTRAINT [UQ__MstNatio__2062829385D913FE] UNIQUE NONCLUSTERED 
(
	[Nationality] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__MstRelat__92ED18E14EE3452A]    Script Date: 31-Jan-25 12:09:02 PM ******/
ALTER TABLE [dbo].[MstRelationship] ADD UNIQUE NONCLUSTERED 
(
	[Relation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FamilyMember] ADD  CONSTRAINT [DF_MstFamilyMembers_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[FamilyMember] ADD  CONSTRAINT [DF_MstFamilyMembers_EntDate]  DEFAULT (getdate()) FOR [EntDate]
GO
ALTER TABLE [dbo].[MstNationalities] ADD  CONSTRAINT [DF_MstNationalities_OrderIndex]  DEFAULT ((0)) FOR [OrderIndex]
GO
ALTER TABLE [dbo].[MstNationalities] ADD  CONSTRAINT [DF_MstNationalities_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[MstRelationship] ADD  CONSTRAINT [DF_MstRelationships_OrderIndex]  DEFAULT ((0)) FOR [OrderIndex]
GO
ALTER TABLE [dbo].[MstRelationship] ADD  CONSTRAINT [DF_MstRelationships_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[MstStudents] ADD  CONSTRAINT [DF_MstStudents_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[MstStudents] ADD  CONSTRAINT [DF_MstStudents_EntDate]  DEFAULT (getdate()) FOR [EntDate]
GO
ALTER TABLE [dbo].[FamilyMember]  WITH CHECK ADD  CONSTRAINT [FK_MstFamilyMembers_MstRelationships] FOREIGN KEY([RelationshipID])
REFERENCES [dbo].[MstRelationship] ([RelationAID])
GO
ALTER TABLE [dbo].[FamilyMember] CHECK CONSTRAINT [FK_MstFamilyMembers_MstRelationships]
GO
