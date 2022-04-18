USE [master]
GO
/****** Object:  Database [Questionnaire]    Script Date: 2022/4/18 下午 02:45:55 ******/
CREATE DATABASE [Questionnaire]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Questionnaire', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Questionnaire.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Questionnaire_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Questionnaire_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Questionnaire] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Questionnaire].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Questionnaire] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Questionnaire] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Questionnaire] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Questionnaire] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Questionnaire] SET ARITHABORT OFF 
GO
ALTER DATABASE [Questionnaire] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Questionnaire] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Questionnaire] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Questionnaire] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Questionnaire] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Questionnaire] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Questionnaire] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Questionnaire] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Questionnaire] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Questionnaire] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Questionnaire] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Questionnaire] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Questionnaire] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Questionnaire] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Questionnaire] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Questionnaire] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Questionnaire] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Questionnaire] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Questionnaire] SET  MULTI_USER 
GO
ALTER DATABASE [Questionnaire] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Questionnaire] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Questionnaire] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Questionnaire] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Questionnaire] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Questionnaire]
GO
/****** Object:  Table [dbo].[AccountCheck]    Script Date: 2022/4/18 下午 02:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountCheck](
	[CheckID] [int] NOT NULL,
	[AccountID] [uniqueidentifier] NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AccountCheck] PRIMARY KEY CLUSTERED 
(
	[CheckID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 2022/4/18 下午 02:45:55 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommonQues]    Script Date: 2022/4/18 下午 02:45:55 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contents]    Script Date: 2022/4/18 下午 02:45:55 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuesDetails]    Script Date: 2022/4/18 下午 02:45:55 ******/
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
 CONSTRAINT [PK_QuesDetail] PRIMARY KEY CLUSTERED 
(
	[QuesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuesTypes]    Script Date: 2022/4/18 下午 02:45:55 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
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
ALTER TABLE [dbo].[AccountCheck]  WITH CHECK ADD  CONSTRAINT [FK_AccountCheck_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
ALTER TABLE [dbo].[AccountCheck] CHECK CONSTRAINT [FK_AccountCheck_Accounts]
GO
ALTER TABLE [dbo].[AccountCheck]  WITH CHECK ADD  CONSTRAINT [FK_AccountCheck_Contents] FOREIGN KEY([ID])
REFERENCES [dbo].[Contents] ([ID])
GO
ALTER TABLE [dbo].[AccountCheck] CHECK CONSTRAINT [FK_AccountCheck_Contents]
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
USE [master]
GO
ALTER DATABASE [Questionnaire] SET  READ_WRITE 
GO
