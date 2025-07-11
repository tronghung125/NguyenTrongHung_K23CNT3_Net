USE [NthK23CNT3_Lesson10db]
GO
/****** Object:  Table [dbo].[NthPost]    Script Date: 26/06/2025 16:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NthPost](
	[nthId] [int] IDENTITY(1,1) NOT NULL,
	[nthTitle] [nvarchar](50) NULL,
	[nthImage] [nvarchar](250) NULL,
	[nthContent] [ntext] NULL,
	[nthStatus] [bit] NULL,
 CONSTRAINT [PK_NthPost] PRIMARY KEY CLUSTERED 
(
	[nthId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[NthPost] ON 

INSERT [dbo].[NthPost] ([nthId], [nthTitle], [nthImage], [nthContent], [nthStatus]) VALUES (1, N'Nguyễn Trọng Hưng', N'image/tronghung.jpg', N'K23CNT3 - NETCORE', 1)
INSERT [dbo].[NthPost] ([nthId], [nthTitle], [nthImage], [nthContent], [nthStatus]) VALUES (2, N'Giới thiệu NETCORE', N'image/netcore.jpg', N'Tốt', 0)
SET IDENTITY_INSERT [dbo].[NthPost] OFF
GO
