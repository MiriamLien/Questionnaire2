USE [Questionnaire]
GO
/****** Object:  Table [dbo].[AccountChecks]    Script Date: 2022/5/11 下午 06:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountChecks](
	[CheckID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [uniqueidentifier] NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[Checks] [bit] NOT NULL,
 CONSTRAINT [PK_AccountCheck] PRIMARY KEY CLUSTERED 
(
	[CheckID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 2022/5/11 下午 06:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [uniqueidentifier] NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[PWD] [varchar](50) NOT NULL,
	[UserLevel] [int] NOT NULL,
	[IsEnable] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommonQues]    Script Date: 2022/5/11 下午 06:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommonQues](
	[CQID] [int] IDENTITY(1,1) NOT NULL,
	[CQTitle] [nvarchar](200) NOT NULL,
	[QuesTypeID] [int] NOT NULL,
	[CQChoices] [nvarchar](max) NULL,
	[CQIsEnable] [bit] NOT NULL,
 CONSTRAINT [PK_CommonQues] PRIMARY KEY CLUSTERED 
(
	[CQID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contents]    Script Date: 2022/5/11 下午 06:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contents](
	[ID] [uniqueidentifier] NOT NULL,
	[TitleID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[IsEnable] [bit] NOT NULL,
 CONSTRAINT [PK_Contents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuesDetails]    Script Date: 2022/5/11 下午 06:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuesDetails](
	[QuesID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[QuesTitle] [nvarchar](200) NOT NULL,
	[QuesChoices] [nvarchar](max) NULL,
	[QuesTypeID] [int] NOT NULL,
	[IsEnable] [bit] NOT NULL,
	[Count] [int] NULL,
 CONSTRAINT [PK_QuesDetail] PRIMARY KEY CLUSTERED 
(
	[QuesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuesTypes]    Script Date: 2022/5/11 下午 06:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuesTypes](
	[QuesTypeID] [int] IDENTITY(1,1) NOT NULL,
	[QuesType] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_QuesType] PRIMARY KEY CLUSTERED 
(
	[QuesTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfos]    Script Date: 2022/5/11 下午 06:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfos](
	[UserID] [uniqueidentifier] NOT NULL,
	[AccountID] [uniqueidentifier] NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Age] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserInfos_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserQuesDetails]    Script Date: 2022/5/11 下午 06:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserQuesDetails](
	[AnsID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[QuesID] [int] NOT NULL,
	[Answer] [nvarchar](max) NOT NULL,
	[AccountID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_UserQuesDetails] PRIMARY KEY CLUSTERED 
(
	[AnsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccountChecks] ADD  CONSTRAINT [DF_AccountCheck_Checks]  DEFAULT ('FALSE') FOR [Checks]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_ID]  DEFAULT (newid()) FOR [AccountID]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_IsEnable]  DEFAULT ('TRUE') FOR [IsEnable]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[CommonQues] ADD  CONSTRAINT [DF_CommonQues_CQIsEnable]  DEFAULT ('TRUE') FOR [CQIsEnable]
GO
ALTER TABLE [dbo].[Contents] ADD  CONSTRAINT [DF_Contents_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Contents] ADD  CONSTRAINT [DF_Contents_IsEnable]  DEFAULT ('TRUE') FOR [IsEnable]
GO
ALTER TABLE [dbo].[QuesDetails] ADD  CONSTRAINT [DF_QuesDetails_IsEnable]  DEFAULT ('TRUE') FOR [IsEnable]
GO
ALTER TABLE [dbo].[UserInfos] ADD  CONSTRAINT [DF_UserInfos_UserID]  DEFAULT (newid()) FOR [UserID]
GO
ALTER TABLE [dbo].[UserInfos] ADD  CONSTRAINT [DF_UserInfos_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[AccountChecks]  WITH CHECK ADD  CONSTRAINT [FK_AccountCheck_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
ALTER TABLE [dbo].[AccountChecks] CHECK CONSTRAINT [FK_AccountCheck_Accounts]
GO
ALTER TABLE [dbo].[CommonQues]  WITH CHECK ADD  CONSTRAINT [FK_CommonQues_QuesTypes] FOREIGN KEY([QuesTypeID])
REFERENCES [dbo].[QuesTypes] ([QuesTypeID])
GO
ALTER TABLE [dbo].[CommonQues] CHECK CONSTRAINT [FK_CommonQues_QuesTypes]
GO
ALTER TABLE [dbo].[QuesDetails]  WITH CHECK ADD  CONSTRAINT [FK_QuesDetails_Contents] FOREIGN KEY([ID])
REFERENCES [dbo].[Contents] ([ID])
GO
ALTER TABLE [dbo].[QuesDetails] CHECK CONSTRAINT [FK_QuesDetails_Contents]
GO
ALTER TABLE [dbo].[QuesDetails]  WITH CHECK ADD  CONSTRAINT [FK_QuesDetails_QuesTypes] FOREIGN KEY([QuesTypeID])
REFERENCES [dbo].[QuesTypes] ([QuesTypeID])
GO
ALTER TABLE [dbo].[QuesDetails] CHECK CONSTRAINT [FK_QuesDetails_QuesTypes]
GO
ALTER TABLE [dbo].[UserInfos]  WITH CHECK ADD  CONSTRAINT [FK_UserInfos_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
ALTER TABLE [dbo].[UserInfos] CHECK CONSTRAINT [FK_UserInfos_Accounts]
GO
ALTER TABLE [dbo].[UserInfos]  WITH CHECK ADD  CONSTRAINT [FK_UserInfos_Contents] FOREIGN KEY([ID])
REFERENCES [dbo].[Contents] ([ID])
GO
ALTER TABLE [dbo].[UserInfos] CHECK CONSTRAINT [FK_UserInfos_Contents]
GO
ALTER TABLE [dbo].[UserQuesDetails]  WITH CHECK ADD  CONSTRAINT [FK_UserQuesDetails_QuesDetails] FOREIGN KEY([QuesID])
REFERENCES [dbo].[QuesDetails] ([QuesID])
GO
ALTER TABLE [dbo].[UserQuesDetails] CHECK CONSTRAINT [FK_UserQuesDetails_QuesDetails]
GO
ALTER TABLE [dbo].[UserQuesDetails]  WITH CHECK ADD  CONSTRAINT [FK_UserQuesDetails_UserInfos] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserInfos] ([UserID])
GO
ALTER TABLE [dbo].[UserQuesDetails] CHECK CONSTRAINT [FK_UserQuesDetails_UserInfos]
GO
