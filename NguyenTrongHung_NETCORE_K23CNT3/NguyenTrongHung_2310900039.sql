USE [NguyenTrongHung_2310900039]
GO
/****** Object:  Table [dbo].[NthEmployee]    Script Date: 02/07/2025 09:39:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NthEmployee](
	[nthEmpId] [int] IDENTITY(1,1) NOT NULL,
	[nthEmpName] [nvarchar](100) NULL,
	[nthEmpLevel] [nvarchar](50) NULL,
	[nthEmpStartDate] [date] NULL,
	[nthEmpStatus] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[nthEmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[NthEmployee] ON 

INSERT [dbo].[NthEmployee] ([nthEmpId], [nthEmpName], [nthEmpLevel], [nthEmpStartDate], [nthEmpStatus]) VALUES (1, N'Nguyễn Trọng Hưng', N'Cao cấp', CAST(N'2005-02-01' AS Date), 0)
INSERT [dbo].[NthEmployee] ([nthEmpId], [nthEmpName], [nthEmpLevel], [nthEmpStartDate], [nthEmpStatus]) VALUES (2, N'Nguyễn Thị B', N'Trung cấp', CAST(N'2023-01-15' AS Date), 0)
INSERT [dbo].[NthEmployee] ([nthEmpId], [nthEmpName], [nthEmpLevel], [nthEmpStartDate], [nthEmpStatus]) VALUES (3, N'Lê Văn C', N'Sơ cấp', CAST(N'2024-03-10' AS Date), 1)
SET IDENTITY_INSERT [dbo].[NthEmployee] OFF
GO
